using System;
using System.Collections.Generic;
using System.Linq;
using Orchard.Autoroute.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Aspects;
using Orchard.ContentManagement.MetaData;
using Orchard.Core.Common.Models;
using Orchard.Core.Title.Models;
using Orchard.Data;
using Orchard.Environment.Configuration;
using Orchard.Environment.Descriptor;
using Orchard.Environment.State;
using Orchard.Logging;
using Orchard.Taxonomies.Models;
using Orchard.UI.Notify;
using Orchard.Utility.Extensions;

namespace Orchard.Taxonomies.Services {
    public class TaxonomyService : ITaxonomyService {
        private readonly IRepository<TermContentItem> _termContentItemRepository;
        private readonly IContentManager _contentManager;
        private readonly INotifier _notifier;
        private readonly IAuthorizationService _authorizationService;
        private readonly IContentDefinitionManager _contentDefinitionManager;
        private readonly IOrchardServices _services;
        private readonly IProcessingEngine _processingEngine;
        private readonly ShellSettings _shellSettings;
        private readonly IShellDescriptorManager _shellDescriptorManager;
        private readonly HashSet<int> _processedTermPartIds = new HashSet<int>();
        private Dictionary<string, TaxonomyPart> _taxonomiesByName;
        private Dictionary<string, TaxonomyPart> _taxonomiesBySlug;

        public TaxonomyService(
            IRepository<TermContentItem> termContentItemRepository,
            IContentManager contentManager,
            INotifier notifier,
            IContentDefinitionManager contentDefinitionManager,
            IAuthorizationService authorizationService,
            IOrchardServices services,
            IProcessingEngine processingEngine,
            ShellSettings shellSettings,
            IShellDescriptorManager shellDescriptorManager) {
            _termContentItemRepository = termContentItemRepository;
            _contentManager = contentManager;
            _notifier = notifier;
            _authorizationService = authorizationService;
            _contentDefinitionManager = contentDefinitionManager;
            _services = services;
            _processingEngine = processingEngine;
            _shellSettings = shellSettings;
            _shellDescriptorManager = shellDescriptorManager;
            Logger = NullLogger.Instance;
            T = NullLocalizer.Instance;
            // initialize memorization structures
            _taxonomiesByName = new Dictionary<string, TaxonomyPart>();
            _taxonomiesBySlug = new Dictionary<string, TaxonomyPart>();
        }

        public ILogger Logger { get; set; }
        public Localizer T { get; set; }

        private IEnumerable<TaxonomyPart> _taxonomies;

        public IEnumerable<TaxonomyPart> GetTaxonomies() {
            if (_taxonomies == null) {
                _taxonomies = GetTaxonomiesQuery().List();
            }
            return _taxonomies;
        }

        public virtual TaxonomyPart GetTaxonomy(int id) {
            return _contentManager.Get(id, VersionOptions.Published).As<TaxonomyPart>();
        }

        public TaxonomyPart GetTaxonomyByName(string name) {
            if (string.IsNullOrWhiteSpace(name)) {
                throw new ArgumentNullException("name");
            }
            if (!_taxonomiesByName.ContainsKey(name)) {
                var t = GetTaxonomiesQuery()
                    .Join<TitlePartRecord>()
                    .Where(r => r.Title == name)
                    .List()
                    .FirstOrDefault();
                _taxonomiesByName.Add(name, t);
            }
            return _taxonomiesByName[name];
        }

        public TaxonomyPart GetTaxonomyBySlug(string slug) {
            if (string.IsNullOrWhiteSpace(slug)) {
                throw new ArgumentNullException("slug");
            }
            if (!_taxonomiesBySlug.ContainsKey(slug)) {
                var t = GetTaxonomiesQuery()
                    .Join<AutoroutePartRecord>()
                    .Where(r => r.DisplayAlias == slug)
                    .List()
                    .FirstOrDefault();
                _taxonomiesBySlug.Add(slug, t);
            }
            return _taxonomiesBySlug[slug];
        }

        public void CreateTermContentType(TaxonomyPart taxonomy) {
            taxonomy.TermTypeName = GenerateTermTypeName(taxonomy.Name);
            _contentDefinitionManager.AlterTypeDefinition(taxonomy.TermTypeName,
                cfg => cfg
                    .WithSetting("Taxonomy", taxonomy.Name)
                    .WithPart("TermPart")
                    .WithPart("TitlePart")
                    .WithPart("AutoroutePart", builder => builder
                        .WithSetting("AutorouteSettings.AllowCustomPattern", "true")
                        .WithSetting("AutorouteSettings.AutomaticAdjustmentOnEdit", "false")
                        .WithSetting("AutorouteSettings.PatternDefinitions", "[{Name:'Taxonomy and Title', Pattern: '{Content.Container.Path}/{Content.Slug}', Description: 'my-taxonomy/my-term/sub-term'}]"))
                    .WithPart("CommonPart")
                    .DisplayedAs(taxonomy.Name + " Term")
                );
        }

        public void DeleteTaxonomy(TaxonomyPart taxonomy) {
            _contentManager.Remove(taxonomy.ContentItem);
            List<TermPart> allTerms = GetRootTerms(taxonomy.Id).ToList();
            foreach (var term in allTerms) {
                DeleteTerm(term);
            }
            if (_contentManager
                .Query<TaxonomyPart, TaxonomyPartRecord>()
                .Where(x => x.Id != taxonomy.Id && x.TermTypeName == taxonomy.TermTypeName)
                .Count() == 0) {
                _contentDefinitionManager.DeleteTypeDefinition(taxonomy.TermTypeName);
            }
        }

        public string GenerateTermTypeName(string taxonomyName) {
            var name = taxonomyName.ToSafeName() + "Term";
            int i = 2;
            while (_contentDefinitionManager.GetTypeDefinition(name) != null) {
                name = taxonomyName.ToSafeName() + i++;
            }
            return name;
        }

        public TermPart NewTerm(TaxonomyPart taxonomy) {
            return NewTerm(taxonomy, null);
        }

        public TermPart NewTerm(TaxonomyPart taxonomy, IContent parent) {
            if (taxonomy == null) {
                throw new ArgumentNullException("taxonomy");
            }
            if (parent != null) {
                var parentAsTaxonomy = parent.As<TaxonomyPart>();
                if (parentAsTaxonomy != null && parentAsTaxonomy != taxonomy) {
                    throw new ArgumentException("The parent of a term can't be a different taxonomy", "parent");
                }
                var parentAsTerm = parent.As<TermPart>();
                if (parentAsTerm != null && parentAsTerm.TaxonomyId != taxonomy.Id) {
                    throw new ArgumentException("The parent of a term can't be a from a different taxonomy", "parent");
                }
            }
            var term = _contentManager.New<TermPart>(taxonomy.TermTypeName);
            term.Container = parent ?? taxonomy;
            term.TaxonomyId = taxonomy.Id;
            ProcessPath(term);
            return term;
        }

        public IEnumerable<TermPart> GetTerms(int taxonomyId) {
            if (taxonomyId <= 0) {
                return Array.Empty<TermPart>();
            }
            var result = GetTermsQuery(taxonomyId)
                .OrderBy(x => x.FullWeight)
                .List();
            return result;
        }

        public IEnumerable<TermPart> GetRootTerms(int taxonomyId) {
            return GetTermsQuery(taxonomyId)
                .Where(x => x.Path == "/")
                .List();
        }

        public TermPart GetTermByPath(string path) {
            return GetTermsQuery()
                .Join<AutoroutePartRecord>()
                .Where(rr => rr.DisplayAlias == path)
                .List()
                .FirstOrDefault();
        }

        public IEnumerable<TermPart> GetAllTerms() {
            var result = GetTermsQuery()
                .OrderBy(x => x.TaxonomyId)
                .List();
            return result;
        }

        public int GetTermsCount(int taxonomyId) {
            if (taxonomyId <= 0) {
                return 0;
            }
            return GetTermsQuery(taxonomyId)
                .Count();
        }

        public TermPart GetTerm(int id) {
            if (id <= 0) {
                return null;
            }
            return GetTermsQuery()
                .Where(x => x.Id == id)
                .List()
                .FirstOrDefault();
        }

        public IEnumerable<TermPart> GetTermsForContentItem(
            int contentItemId, string field = null, VersionOptions versionOptions = null) {
            var termIds = string.IsNullOrEmpty(field)
                ? _termContentItemRepository
                    .Table
                    .Where(x => x.TermsPartRecord.ContentItemRecord.Id == contentItemId)
                    .Select(t => t.TermRecord.Id)
                    .ToArray()
                : _termContentItemRepository
                    .Where(x => x.TermsPartRecord.Id == contentItemId && x.Field == field)
                    .ToArray();
            return _contentManager
                .GetMany<TermPart>(termIds, versionOptions ?? VersionOptions.Published, QueryHints.Empty);
        }

        public TermPart GetTermByName(int taxonomyId, string name) {
            if (taxonomyId <= 0) {
                return null;
            }
            return GetTermsQuery()
                .Join<TitlePartRecord>()
                .Where(r => r.Title == name)
                .List()
                .FirstOrDefault();
        }

        public void CreateTerm(TermPart termPart) {
            if (GetTermByName(termPart.TaxonomyId, termPart.Name) == null) {
                _authorizationService.CheckAccess(Permissions.CreateTerm, _services.WorkContext.CurrentUser, null);
                termPart.As<ICommonPart>().Container = GetTaxonomy(termPart.TaxonomyId).ContentItem;
                _contentManager.Create(termPart);
            } else {
                _notifier.Warning(T("The term {0} already exists in this taxonomy", termPart.Name));
            }
        }

        public void DeleteTerm(TermPart termPart) {
            _contentManager.Remove(termPart.ContentItem);
            foreach (var childTerm in GetChildren(termPart)) {
                _contentManager.Remove(childTerm.ContentItem);
            }
            var termContentItems = _termContentItemRepository
                .Fetch(t => t.TermRecord == termPart.Record)
                .ToList();
            foreach (var termContentItem in termContentItems) {
                _termContentItemRepository.Delete(termContentItem);
            }
        }

        public void UpdateTerms(ContentItem contentItem, IEnumerable<TermPart> terms, string field) {
            var termsPart = contentItem.As<TermsPart>();

            var termList = termsPart.Terms
                .Select((t, i) => new { Term = t, Index = i })
                .Where(x => x.Term.Field == field)
                .OrderByDescending(i => i.Index)
                .ToList();

            foreach (var x in termList) {
                termsPart.Terms.RemoveAt(x.Index);
            }

            foreach (var term in terms) {
                termList.RemoveAll(t => t.Term.TermRecord.Id == term.Id);
                termsPart.Terms.Add(
                    new TermContentItem {
                        TermsPartRecord = termsPart.Record,
                        TermRecord = term.Record,
                        Field = field
                    });
            }

            var termPartRecordIds = termList.Select(t => t.Term.TermRecord.Id).ToArray();
            if (termPartRecordIds.Any()) {
                if (!_processedTermPartIds.Any()) {
                    _processingEngine.AddTask(_shellSettings, _shellDescriptorManager.GetShellDescriptor(), "ITermCountProcessor.Process",
                        new Dictionary<string, object> { { "termPartRecordIds", _processedTermPartIds } });
                }
                foreach (var termPartRecordId in termPartRecordIds) {
                    _processedTermPartIds.Add(termPartRecordId);
                }
            }
        }

        public IContentQuery<TermsPart, TermsPartRecord> GetContentItemsQuery(TermPart term, string fieldName = null) {
            var rootPath = term.FullPath + "/";
            var query = _contentManager
                .Query<TermsPart, TermsPartRecord>();
            if (String.IsNullOrWhiteSpace(fieldName)) {
                query = query.Where(
                    tpr => tpr.Terms.Any(tr =>
                        tr.TermRecord.Id == term.Id
                        || tr.TermRecord.Path.StartsWith(rootPath)));
            } else {
                query = query.Where(
                    tpr => tpr.Terms.Any(tr =>
                        tr.Field == fieldName
                        && (tr.TermRecord.Id == term.Id || tr.TermRecord.Path.StartsWith(rootPath))));
            }
            return query;
        }

        public long GetContentItemsCount(TermPart term, string fieldName = null) {
            return GetContentItemsQuery(term, fieldName).Count();
        }

        public IEnumerable<IContent> GetContentItems(TermPart term, int skip = 0, int count = 0, string fieldName = null) {
            return GetContentItemsQuery(term, fieldName)
                .Join<CommonPartRecord>()
                .OrderByDescending(x => x.CreatedUtc)
                .Slice(skip, count);
        }

        public IEnumerable<TermPart> GetChildren(TermPart term) {
            return GetChildren(term, false);
        }

        public IEnumerable<TermPart> GetChildren(TermPart term, bool includeParent) {
            var rootPath = term.FullPath + "/";
            var result = GetTermsQuery(term.TaxonomyId)
                .Where(x => x.Path.StartsWith(rootPath))
                .List();
            if (includeParent) {
                result = result.Concat(new[] { term });
            }
            return result;
        }

        public IEnumerable<TermPart> GetParents(TermPart term) {
            return term.Path.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Select(id => GetTerm(int.Parse(id)));
        }

        public IEnumerable<string> GetSlugs() {
            return GetAllTerms()
                .Select(t => t.Slug);
        }

        public IEnumerable<string> GetTermPaths() {
            return GetAllTerms()
                .Select(t => t.Path);
        }

        public void MoveTerm(TaxonomyPart taxonomy, TermPart term, TermPart parentTerm) {
            var children = GetChildren(term);
            if (taxonomy.Id != term.TaxonomyId) {
                if (_termFamilies == null) {
                    _termFamilies = new Dictionary<string, IEnumerable<TermPart>>();
                } else {
                    var oldKey = term.TaxonomyId.ToString() + (term.Path ?? string.Empty);
                    if (_termFamilies.ContainsKey(oldKey)) {
                        _termFamilies.Remove(oldKey);
                    }
                    foreach (var child in children) {
                        oldKey = child.TaxonomyId.ToString() + (child.Path ?? string.Empty);
                        if (_termFamilies.ContainsKey(oldKey)) {
                            _termFamilies.Remove(oldKey);
                        }
                    }
                }
            }
            term.Container = parentTerm == null ? taxonomy.ContentItem : parentTerm.ContentItem;
            foreach (var child in children) {
                child.TaxonomyId = taxonomy.Id;
                ProcessPath(child);
            }
        }

        public void ProcessPath(TermPart term) {
            var parentTerm = term.Container.As<TermPart>();
            var oldPath = term.Path ?? string.Empty;
            term.Path = parentTerm != null ? parentTerm.FullPath + "/" : "/";
            if (!oldPath.Equals(term.Path, StringComparison.InvariantCultureIgnoreCase)) {
                if (_termFamilies.ContainsKey(term.TaxonomyId + oldPath)) {
                    _termFamilies.Remove(term.TaxonomyId + oldPath);
                }
                if (_termFamilies.ContainsKey(term.TaxonomyId + term.Path)) {
                    _termFamilies.Remove(term.TaxonomyId + term.Path);
                }
            }
            if (!string.IsNullOrWhiteSpace(oldPath)) {
                ProcessFullWeight(term);
            }
        }

        private void ProcessFullWeight(TermPart term) {
            var litter = OrderedSiblings(term)
                .Where(sib => sib.Weight == term.Weight);
            foreach (var tp in litter) {
                var newWeight = ComputeFullWeight(tp);
                if (!newWeight.Equals(tp.FullWeight, StringComparison.InvariantCultureIgnoreCase)) {
                    tp.FullWeight = newWeight;
                    PublishTerm(tp);
                    UpdateChildren(tp);
                }
            }
        }

        private void UpdateChildren(TermPart part) {
            foreach (var childTerm in GetChildren(part)) {
                ProcessPath(childTerm);
            }
        }

        protected virtual void PublishTerm(TermPart term) {
            var contentItem = _contentManager.Get(term.ContentItem.Id, VersionOptions.DraftRequired);
            _contentManager.Publish(contentItem);
        }

        public void CreateHierarchy(IEnumerable<TermPart> terms, Action<TermPartNode, TermPartNode> append) {
            var root = new TermPartNode();
            var stack = new Stack<TermPartNode>(new[] { root });
            foreach (var term in terms) {
                var current = CreateNode(term);
                var previous = stack.Pop();
                while (previous.Level + 1 != current.Level) {
                    previous = stack.Pop();
                }
                if (append != null) {
                    append(previous, current);
                }
                previous.Items.Add(current);
                current.Parent = previous;
                stack.Push(previous);
                stack.Push(current);
            }
        }

        private static TermPartNode CreateNode(TermPart part) {
            return new TermPartNode {
                TermPart = part,
                Level = part.Path.Count(x => x == '/')
            };
        }

        public virtual IContentQuery<TaxonomyPart, TaxonomyPartRecord> GetTaxonomiesQuery() {
            return _contentManager.Query<TaxonomyPart, TaxonomyPartRecord>();
        }

        public virtual IContentQuery<TermPart, TermPartRecord> GetTermsQuery() {
            return _contentManager.Query<TermPart, TermPartRecord>();
        }

        public IContentQuery<TermPart, TermPartRecord> GetTermsQuery(int taxonomyId) {
            return GetTermsQuery().Where(x => x.TaxonomyId == taxonomyId);
        }

        public string ComputeFullWeight(TermPart part) {
            if (part == null) {
                throw new ArgumentNullException("part");
            }
            var parent = part.Container.As<TermPart>();
            var parentWeight = parent == null
                ? string.Empty
                : parent.FullWeight;
            var partWeight = (524288 - part.Weight).ToString("X5");
            var siblingsIds = OrderedSiblings(part)
                .Where(sib => sib.Weight == part.Weight)
                .Select(tp => tp.Id)
                .ToArray();
            var siblingsWeight = (1048575).ToString("X5");
            for (int i = 0; i < siblingsIds.Length; i++) {
                if (siblingsIds[i] == part.Id) {
                    siblingsWeight = i.ToString("X5");
                    break;
                }
            }
            return $"{parentWeight}{partWeight}.{siblingsWeight}.{part.Id}/";
        }

        private Dictionary<string, IEnumerable<TermPart>> _termFamilies;

        public IEnumerable<TermPart> OrderedSiblings(TermPart part) {
            if (_termFamilies == null) {
                _termFamilies = new Dictionary<string, IEnumerable<TermPart>>();
            }
            var key = part.TaxonomyId + part.Path;
            if (!_termFamilies.ContainsKey(key)) {
                _termFamilies.Add(key, GetTermsQuery(part.TaxonomyId)
                    .Where(tpr => tpr.Path == part.Path)
                    .OrderBy(tp => tp.Name, StringComparer.OrdinalIgnoreCase)
                    .ToList());
            }
            return _termFamilies[key];
        }
    }
}
