using System;

namespace Orchard.ContentManagement
{
    public class ContentItem
    {
        public int Id { get; set; }
        public int Version { get; set; }
    }

    public class ContentIdentity
    {
        public string Id { get; set; }
    }

    public class ContentItemMetadata
    {
        public ContentIdentity Identity { get; set; }
    }

    public class VersionOptions
    {
        public static readonly VersionOptions Latest = new VersionOptions { IsLatest = true };
        public bool IsLatest { get; set; }
    }

    public interface IContent
    {
        ContentItem ContentItem { get; }
    }

    public interface IContentQuery<T>
    {
        T Get(int id);
    }

    public interface IHqlQuery
    {
        string ToHql();
    }

    public interface IUpdateModel
    {
        bool TryUpdateModel<TModel>(TModel model) where TModel : class;
    }

    public class GroupInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public interface IDocumentIndex
    {
        int Id { get; }
    }

    public interface ImportContentSession
    {
        void Import(ContentItem contentItem);
    }
}
