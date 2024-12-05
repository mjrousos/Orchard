using System;
using System.Collections.Generic;
using System.Linq;

namespace Orchard.ContentManagement
{
    public interface IContentManager
    {
        ContentItem New(string contentType);
        ContentItem Get(int id);
        ContentItem Get(int id, VersionOptions options);
        IEnumerable<ContentItem> GetAllVersions(int id);
        ContentItem Create(string contentType, VersionOptions options);
        ContentItem Create(ContentItem contentItem, VersionOptions options);
        void Remove(ContentItem contentItem);
        void Publish(ContentItem contentItem);
        void Unpublish(ContentItem contentItem);
        void Clone(ContentItem contentItem);
    }

    public class VersionOptions
    {
        public static VersionOptions Latest { get; } = new VersionOptions { IsLatest = true };
        public static VersionOptions Published { get; } = new VersionOptions { IsPublished = true };
        public static VersionOptions Draft { get; } = new VersionOptions { IsDraft = true };
        public static VersionOptions AllVersions { get; } = new VersionOptions { IsAllVersions = true };

        public bool IsLatest { get; set; }
        public bool IsPublished { get; set; }
        public bool IsDraft { get; set; }
        public bool IsAllVersions { get; set; }
    }

    public interface IContent
    {
        ContentItem ContentItem { get; }
    }

    public class ContentItem
    {
        public int Id { get; set; }
        public string ContentType { get; set; }
        public int Version { get; set; }
        public bool Latest { get; set; }
        public bool Published { get; set; }
        public DateTime? PublishedUtc { get; set; }
        public DateTime? ModifiedUtc { get; set; }
        public DateTime? CreatedUtc { get; set; }
        public string Owner { get; set; }
        public string Author { get; set; }
    }
}
