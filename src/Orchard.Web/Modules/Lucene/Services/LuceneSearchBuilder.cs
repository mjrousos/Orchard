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
using System.Globalization;
using System.Linq;
using Lucene.Models;
using Lucene.Net.Analysis;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucene.Net.Util;
using Orchard.Indexing;
using Orchard.Logging;
using Lucene.Net.Documents;
using Lucene.Net.QueryParsers;
using Lucene.Net.Analysis.Tokenattributes;

namespace Lucene.Services {
    public class LuceneSearchBuilder : ISearchBuilder {
        private const int MaxResults = Int16.MaxValue;
        private readonly Directory _directory;
        private string _indexName;
        private Analyzer _analyzer;
        private ILuceneAnalyzerProvider _analyzerProvider;
        private readonly List<BooleanClause> _clauses;
        private readonly List<BooleanClause> _filters;
        private int _count;
        private int _skip;
        private string _sort;
        private int _comparer;
        private bool _sortDescending;
        private bool _asFilter;
        // pending clause attributes
        private Occur _occur;
        private bool _exactMatch;
        private bool _notAnalyzed;
        private float _boost;
        private Query _query;
        public ILogger Logger { get; set; }
        public LuceneSearchBuilder(
            Directory directory, 
            ILuceneAnalyzerProvider analyzerProvider,
            string indexName) {
            _directory = directory;
            _indexName = indexName;
            _analyzerProvider = analyzerProvider;
            _analyzer = analyzerProvider.GetAnalyzer(_indexName);
            Logger = NullLogger.Instance;
            _count = MaxResults;
            _skip = 0;
            _clauses = new List<BooleanClause>();
            _filters = new List<BooleanClause>();
            _sort = String.Empty;
            _comparer = 0;
            _sortDescending = true;
            InitPendingClause();
        }
        public ISearchBuilder Parse(string defaultField, string query, bool escape) {
            return Parse(new[] {defaultField}, query, escape);
        public ISearchBuilder Parse(string[] defaultFields, string query, bool escape) {
            if (defaultFields.Length == 0) {
                throw new ArgumentException("Default field can't be empty");
            }
            if (String.IsNullOrWhiteSpace(query)) {
                throw new ArgumentException("Query can't be empty");
            if (escape) {
                query = QueryParser.Escape(query);
            foreach (var defaultField in defaultFields) {
                CreatePendingClause();
                _query = new QueryParser(LuceneIndexProvider.LuceneVersion, defaultField, _analyzer).Parse(query);
            return this;
        public ISearchBuilder WithGroup(Action<ISearchBuilder> grouping)
        {
            CreatePendingClause();
            // a group is essentially a SearchBuilder                
            var groupSearchBuilder = new LuceneSearchBuilder(null, _analyzerProvider, _indexName);
            grouping(groupSearchBuilder);
            _query = groupSearchBuilder.CreateQuery();
        public ISearchBuilder WithField(string field, int value) {
            _query = NumericRangeQuery.NewIntRange(field, value, value, true, true);
        public ISearchBuilder WithinRange(string field, int? min, int? max, bool includeMin = true, bool includeMax = true) {
            _query = NumericRangeQuery.NewIntRange(field, min, max, includeMin, includeMax);
        public ISearchBuilder WithField(string field, double value) {
            _query = NumericRangeQuery.NewDoubleRange(field, value, value, true, true);
        public ISearchBuilder WithinRange(string field, double? min, double? max, bool includeMin = true, bool includeMax = true) {
            _query = NumericRangeQuery.NewDoubleRange(field, min, max, includeMin, includeMax);
        public ISearchBuilder WithField(string field, bool value) {
            return WithField(field, value ? 1 : 0);
        public ISearchBuilder WithField(string field, DateTime value) {
            _query = new TermQuery(new Term(field, DateTools.DateToString(value, DateTools.Resolution.MILLISECOND)));
        public ISearchBuilder WithinRange(string field, DateTime? min, DateTime? max, bool includeMin = true, bool includeMax = true) {
            _query = new TermRangeQuery(field, min.HasValue ? DateTools.DateToString(min.Value, DateTools.Resolution.MILLISECOND) : null, max.HasValue ? DateTools.DateToString(max.Value, DateTools.Resolution.MILLISECOND) : null, includeMin, includeMax);
        public ISearchBuilder WithinRange(string field, string min, string max, bool includeMin = true, bool includeMax = true) {
            _query = new TermRangeQuery(field, min != null ? QueryParser.Escape(min) : null, max != null ? QueryParser.Escape(max) : null, includeMin, includeMax);
        public ISearchBuilder WithField(string field, string value) {
            if (!String.IsNullOrWhiteSpace(value)) {
                _query = new TermQuery(new Term(field, QueryParser.Escape(value)));
        public ISearchBuilder Mandatory() {
            _occur = Occur.MUST;
        public ISearchBuilder Forbidden() {
            _occur = Occur.MUST_NOT;
        public ISearchBuilder ExactMatch() {
            _exactMatch = true;
        public ISearchBuilder NotAnalyzed() {
            _notAnalyzed = true;
        public ISearchBuilder Weighted(float weight) {
            _boost = weight;
        private void InitPendingClause() {
            _occur = Occur.SHOULD;
            _exactMatch = false;
            _notAnalyzed = false;
            _query = null;
            _boost = 0;
            _asFilter = false;
        private void CreatePendingClause() {
            if (_query == null) {
                return;
            // comparing floating-point numbers using an epsilon value
            const double epsilon = 0.001;
            if (Math.Abs(_boost - 0) > epsilon) {
                _query.Boost = _boost;
            if (!_notAnalyzed) {
                var termQuery = _query as TermQuery;
                if (termQuery != null) {
                    var term = termQuery.Term;
                    var analyzedText = AnalyzeText(_analyzer, term.Field, term.Text).FirstOrDefault();
                    _query = new TermQuery(new Term(term.Field, analyzedText));
                }
                var termRangeQuery = _query as TermRangeQuery;
                if (termRangeQuery != null) {
                    var lowerTerm = AnalyzeText(_analyzer, termRangeQuery.Field, termRangeQuery.LowerTerm).FirstOrDefault();
                    var upperTerm = AnalyzeText(_analyzer, termRangeQuery.Field, termRangeQuery.UpperTerm).FirstOrDefault();
                    _query = new TermRangeQuery(termRangeQuery.Field, lowerTerm, upperTerm, termRangeQuery.IncludesLower, termRangeQuery.IncludesUpper);
            if (!_exactMatch) {
                    _query = new PrefixQuery(new Term(term.Field, term.Text));
            if (_asFilter) {
                _filters.Add(new BooleanClause(_query, _occur));
            else {
                _clauses.Add(new BooleanClause(_query, _occur));
        private static List<string> AnalyzeText(Analyzer analyzer, string field, string text) {
            if (String.IsNullOrEmpty(text)) {
                return new List<string>();
            var result = new List<string>();
            using (var sr = new System.IO.StringReader(text)) {
                using (TokenStream stream = analyzer.TokenStream(field, sr)) {
                    while (stream.IncrementToken()) {
                        var termAttribute = stream.GetAttribute<ITermAttribute>();
                        if(termAttribute != null) {
                            result.Add(termAttribute.Term);
                        }
                    }
            return result;
        public ISearchBuilder SortBy(string name) {
            _sort = name;
        public ISearchBuilder SortByInteger(string name) {
            _comparer = SortField.INT;
        public ISearchBuilder SortByBoolean(string name) {
            return SortByInteger(name);
        public ISearchBuilder SortByString(string name) {
            _comparer = SortField.STRING;
        public ISearchBuilder SortByDouble(string name) {
            _comparer = SortField.DOUBLE;
        public ISearchBuilder SortByDateTime(string name) {
            _comparer = SortField.LONG;
        public ISearchBuilder Ascending() {
            _sortDescending = false;
        public ISearchBuilder AsFilter() {
            _asFilter = true;
        public ISearchBuilder Slice(int skip, int count) {
            if (skip < 0) {
                throw new ArgumentException("Skip must be greater or equal to zero");
            if (count <= 0) {
                throw new ArgumentException("Count must be greater than zero");
            _skip = skip;
            _count = count;
        private Query CreateQuery() {
            var booleanQuery = new BooleanQuery();
            Query resultQuery = booleanQuery;
            if (_clauses.Count == 0) {
                if (_filters.Count > 0) {
                    // only filters applieds => transform to a boolean query
                    foreach (var clause in _filters) {
                        booleanQuery.Add(clause);
                    resultQuery = booleanQuery;
                else {
                    // search all documents, without filter or clause
                    resultQuery = new MatchAllDocsQuery(null);
                foreach (var clause in _clauses)
                    booleanQuery.Add(clause);
                    var filter = new BooleanQuery();
                    foreach (var clause in _filters)
                        filter.Add(clause);
                    var queryFilter = new QueryWrapperFilter(filter);
                    resultQuery = new FilteredQuery(booleanQuery, queryFilter);
            Logger.Debug("New search query: {0}", resultQuery.ToString());
            return resultQuery;
        public IEnumerable<ISearchHit> Search() {
            var query = CreateQuery();
            IndexSearcher searcher;
            try {
                searcher = new IndexSearcher(_directory, true);
            catch {
                // index might not exist if it has been rebuilt
                Logger.Information("Attempt to read a none existing index");
                return Enumerable.Empty<ISearchHit>();
            using (searcher) {
                var sort = String.IsNullOrEmpty(_sort)
                               ? Sort.RELEVANCE
                               : new Sort(new SortField(_sort, _comparer, _sortDescending));
                var collector = TopFieldCollector.Create(
                    sort,
                    _count + _skip,
                    false,
                    true,
                    true);
                Logger.Debug("Searching: {0}", query.ToString());
                searcher.Search(query, collector);
                var results = collector.TopDocs().ScoreDocs
                                       .Skip(_skip)
                                       .Select(scoreDoc => new LuceneSearchHit(searcher.Doc(scoreDoc.Doc), scoreDoc.Score))
                                       .ToList();
                Logger.Debug("Search results: {0}", results.Count);
                return results;
        public int Count() {
                return 0;
                var hits = searcher.Search(query, Int16.MaxValue);
                Logger.Information("Search results: {0}", hits.ScoreDocs.Length);
                var length = hits.ScoreDocs.Length;
                return Math.Min(length - _skip, _count);
        public ISearchBits GetBits() {
                return null;
                var filter = new QueryWrapperFilter(query);
                var bits = filter.GetDocIdSet(searcher.IndexReader);
                var disi = new OpenBitSetDISI(bits.Iterator(), searcher.MaxDoc);
                return new SearchBits(disi);
        public ISearchHit Get(int documentId) {
            var query = new TermQuery(new Term("id", documentId.ToString(CultureInfo.InvariantCulture)));
            using (var searcher = new IndexSearcher(_directory, true)) {
                var hits = searcher.Search(query, 1);
                return hits.ScoreDocs.Length > 0 ? new LuceneSearchHit(searcher.Doc(hits.ScoreDocs[0].Doc), hits.ScoreDocs[0].Score) : null;
    }
}
