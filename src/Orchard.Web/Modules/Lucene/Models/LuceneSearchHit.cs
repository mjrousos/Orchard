using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Lucene.Net.Documents;
using Orchard.Indexing;

namespace Lucene.Models {
    public class LuceneSearchHit : ISearchHit {
        private readonly Document _doc;
        private readonly float _score;
        public float Score { get { return _score; } }
        public LuceneSearchHit(Document document, float score) {
            _doc = document;
            _score = score;
        }
        public int ContentItemId { get { return GetInt("id"); } }
        public int GetInt(string name) {
            var field = _doc.GetField(name);
            return field == null ? 0 : Int32.Parse(field.StringValue);
        public double GetDouble(string name) {
            return field == null ? 0 : double.Parse(field.StringValue);
        public bool GetBoolean(string name) {
            return GetInt(name) > 0;
        public string GetString(string name) {
            return field == null ? null : field.StringValue;
        public DateTime GetDateTime(string name) {
            return field == null ? DateTime.MinValue : DateTools.StringToDate(field.StringValue);
    }
}
