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

namespace Orchard
{
    public interface IContentManager
    {
        ContentItem New(string contentType);
        ContentItem Get(int id);
        ContentItem Get(int id, VersionOptions options);
        IEnumerable<ContentItem> GetAllVersions(int id);
        ContentItem Create(ContentItem contentItem, VersionOptions options);
        ContentItem Create(string contentType, VersionOptions options);
        void Remove(ContentItem contentItem);
        void Index(ContentItem contentItem, IDocumentIndex documentIndex);
        IContentQuery<ContentItem> Query();
        IHqlQuery HqlQuery();
        void Publish(ContentItem contentItem);
        void Unpublish(ContentItem contentItem);
        void Clone(ContentItem contentItem);
    }

    public interface IDocumentIndex
    {
        IDocumentIndex Add(string name, string value);
        IDocumentIndex Add(string name, DateTime value);
        IDocumentIndex Add(string name, int value);
        IDocumentIndex Add(string name, bool value);
        IDocumentIndex Add(string name, double value);
    }

    public interface IHqlQuery
    {
        IHqlQuery Join(Action<IAliasFactory> alias);
        IHqlQuery Where(Action<IAliasFactory> alias);
        IHqlQuery OrderBy(Action<IAliasFactory> alias);
        IEnumerable<ContentItem> List();
        int Count();
    }

    public interface IAliasFactory
    {
        IAliasFactory ContentPartRecord<TRecord>();
        IAliasFactory ContentItemRecord();
        IAliasFactory ContentItemVersionRecord();
        IAliasFactory ContentTypeRecord();
    }

    public class VersionOptions
    {
        public static VersionOptions Latest { get { return new VersionOptions { IsLatest = true }; } }
        public static VersionOptions Published { get { return new VersionOptions { IsPublished = true }; } }
        public static VersionOptions Draft { get { return new VersionOptions { IsDraft = true }; } }
        public static VersionOptions AllVersions { get { return new VersionOptions { IsAllVersions = true }; } }
        public bool IsLatest { get; set; }
        public bool IsPublished { get; set; }
        public bool IsDraft { get; set; }
        public bool IsAllVersions { get; set; }
        public int? Number { get; set; }
    }
}
