using Orchard.ContentManagement;
using Orchard.DisplayManagement.Descriptors;
using Orchard.Taxonomies.Models;
using Orchard.Utility.Extensions;

namespace Orchard.Taxonomies {
    public class Shapes : IShapeTableProvider {
        public void Discover(ShapeTableBuilder builder) {
            builder.Describe("Taxonomy")
                .OnDisplaying(displaying => {
                    var shape = displaying.Shape;
                    var metadata = displaying.ShapeMetadata;
                    TaxonomyPart taxonomy = shape.ContentPart;
                    shape.Classes.Add("taxonomy-" + taxonomy.Slug.HtmlClassify());
                    shape.Classes.Add("taxonomy");
                    metadata.Alternates.Add("Taxonomy__" + FormatAlternate(taxonomy.Slug));
                });

            builder.Describe("TaxonomyItem")
                .OnDisplaying(displaying => {
                    var shape = displaying.Shape;
                    var metadata = displaying.ShapeMetadata;
                    IContent content = shape.Taxonomy;
                    var taxonomy = content.As<TaxonomyPart>();
                    metadata.Alternates.Add("TaxonomyItem__" + FormatAlternate(taxonomy.Slug));
                    TermPart term = shape.ContentPart;
                    foreach (var alternate in GetHierarchyAlternates(term).Reverse()) {
                        metadata.Alternates.Add("TaxonomyItem__" + FormatAlternate(alternate));
                    }
                });

            builder.Describe("TaxonomyItemLink")
                .OnDisplaying(displaying => {
                    var shape = displaying.Shape;
                    var metadata = displaying.ShapeMetadata;
                    IContent content = shape.Taxonomy;
                    var taxonomy = content.As<TaxonomyPart>();
                    metadata.Alternates.Add("TaxonomyItemLink__" + FormatAlternate(taxonomy.Slug));
                    TermPart term = shape.ContentPart;
                    foreach (var alternate in GetHierarchyAlternates(term).Reverse()) {
                        metadata.Alternates.Add("TaxonomyItemLink__" + FormatAlternate(alternate));
                    }
                });
        }

        private string FormatAlternate(string path) {
            return path.Replace("-", "__").Replace("/", "__");
        }

        private IEnumerable<string> GetHierarchyAlternates(TermPart part) {
            var parent = part;
            do {
                yield return parent.Slug;
            } while (null != (parent = parent.Container.As<TermPart>()));
        }
    }
}
