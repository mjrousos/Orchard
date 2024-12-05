using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Collections.Generic;
using Lucene.Net.Documents;
using Orchard;
using Orchard.Indexing;
using Orchard.Utility.Extensions;

namespace Lucene.Models {
    public class LuceneDocumentIndex : IDocumentIndex {
        public List<AbstractField> Fields { get; private set; }
        private string _name;
        private string  _stringValue;
        private int _intValue;
        private double _doubleValue;
        private bool _analyze;
        private bool _store;
        private bool _removeTags;
        private TypeCode _typeCode;
        public int ContentItemId { get; private set; }
        public LuceneDocumentIndex(int documentId, Localizer t) {
            Fields = new List<AbstractField>();
            SetContentItemId(documentId);
            IsDirty = false;
            
            _typeCode = TypeCode.Empty;
            T = t;
        }
        public Localizer T { get; set; }
        public bool IsDirty { get; private set; }
        public IDocumentIndex Add(string name, string value) {
            PrepareForIndexing();
            _name = name;
            _stringValue = value;
            _typeCode = TypeCode.String;
            IsDirty = true;
            return this;
        public IDocumentIndex Add(string name, DateTime value) {
            return Add(name, DateTools.DateToString(value, DateTools.Resolution.MILLISECOND));
        public IDocumentIndex Add(string name, int value) {
            _intValue = value;
            _typeCode = TypeCode.Int32;
        public IDocumentIndex Add(string name, bool value) {
            return Add(name, value ? 1 : 0);
        public IDocumentIndex Add(string name, double value) {
            _doubleValue = value;
            _typeCode = TypeCode.Single;
        public IDocumentIndex Add(string name, object value) {
            return Add(name, value.ToString());
        public IDocumentIndex RemoveTags() {
            _removeTags = true;
        public IDocumentIndex Store() {
            _store = true;
        public IDocumentIndex Analyze() {
            _analyze = true;
        public IDocumentIndex SetContentItemId(int contentItemId) {
            ContentItemId = contentItemId;
            Fields.Add(new Field("id", contentItemId.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
        public void PrepareForIndexing() {
            switch(_typeCode) {
                case TypeCode.String:
                    if(_removeTags) {
                        _stringValue = _stringValue.RemoveTags(true);
                    }
                    Fields.Add(new Field(_name, _stringValue ?? String.Empty, 
                        _store ? Field.Store.YES : Field.Store.NO, 
                        _analyze ? Field.Index.ANALYZED : Field.Index.NOT_ANALYZED));
                    break;
                case TypeCode.Int32:
                    Fields.Add(new NumericField(_name, 
                        _store ? Field.Store.YES : Field.Store.NO,
                        true).SetIntValue(_intValue));
                case TypeCode.Single:
                    Fields.Add(new NumericField(_name,
                        true).SetDoubleValue(_doubleValue));
                case TypeCode.Empty:
                default:
                    throw new OrchardException(T("Unexpected index type"));
            }
            _removeTags = false;
            _analyze = false;
            _store = false;
    }
}
