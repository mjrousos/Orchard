using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Orchard.ContentManagement
{
    public interface IContent
    {
        ContentItem ContentItem { get; }
    }
    public class ContentItem : DynamicObject
        public int Id { get; set; }
        public int Version { get; set; }
        public string ContentType { get; set; }
        public DateTime? PublishedUtc { get; set; }
        public DateTime? CreatedUtc { get; set; }
        public DateTime? ModifiedUtc { get; set; }
        public string Owner { get; set; }
        public string Author { get; set; }
        public ContentItem()
        {
            Parts = new List<IContent>();
            Fields = new List<IContent>();
        }
        public IList<IContent> Parts { get; set; }
        public IList<IContent> Fields { get; set; }
    public interface IContentDefinitionManager
        IEnumerable<ContentTypeDefinition> ListTypeDefinitions();
        IEnumerable<ContentPartDefinition> ListPartDefinitions();
        ContentTypeDefinition GetTypeDefinition(string name);
        ContentPartDefinition GetPartDefinition(string name);
        void StoreTypeDefinition(ContentTypeDefinition contentTypeDefinition);
        void StorePartDefinition(ContentPartDefinition contentPartDefinition);
        void DeleteTypeDefinition(string name);
        void DeletePartDefinition(string name);
    public class ContentTypeDefinition
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public IList<ContentTypePartDefinition> Parts { get; set; }
        public IList<ContentTypeFieldDefinition> Fields { get; set; }
        public string Settings { get; set; }
    public class ContentPartDefinition
        public IList<ContentPartFieldDefinition> Fields { get; set; }
    public class ContentTypePartDefinition
        public ContentPartDefinition PartDefinition { get; set; }
    public class ContentTypeFieldDefinition
        public string FieldDefinition { get; set; }
    public class ContentPartFieldDefinition
    public interface IContentQuery
        IContentQuery<ContentItem> ForType(params string[] contentTypes);
        IContentQuery<ContentItem> ForVersion(VersionOptions options);
    public interface IContentQuery<T> : IContentQuery where T : class, IContent
        IEnumerable<T> List();
        T Get(int id);
}
