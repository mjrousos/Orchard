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
using System.Linq;

namespace Orchard.Indexing {
    public class NullSearchBuilder : ISearchBuilder {
        public ISearchBuilder Parse(string defaultField, string query, bool escape) {
            return this; 
        }
        public ISearchBuilder Parse(string[] defaultFields, string query, bool escape) {
            return this;
        public ISearchBuilder WithGroup(Action<ISearchBuilder> groupSearchBuilder) {
        public ISearchBuilder WithField(string field, bool value) {
        public ISearchBuilder WithField(string field, DateTime value) {
        public ISearchBuilder WithField(string field, string value) {
        public ISearchBuilder WithField(string field, int value) {
        public ISearchBuilder WithField(string field, double value) {
        public ISearchBuilder WithinRange(string field, int? min, int? max, bool includeMin = true, bool includeMax = true) {
        public ISearchBuilder WithinRange(string field, double? min, double? max, bool includeMin = true, bool includeMax = true) {
        public ISearchBuilder WithinRange(string field, DateTime? min, DateTime? max, bool includeMin = true, bool includeMax = true) {
        public ISearchBuilder WithinRange(string field, string min, string max, bool includeMin = true, bool includeMax = true) {
        /// <summary>
        /// Mark a clause as a mandatory match. By default all clauses are optional.
        /// </summary>
        public ISearchBuilder Mandatory() {
        /// Mark a clause as a forbidden match.
        public ISearchBuilder Forbidden() {
        /// Applied on string clauses, it removes the default Prefix mecanism. Like 'broadcast' won't
        /// return 'broadcasting'. 
        public ISearchBuilder ExactMatch() {
        public ISearchBuilder NotAnalyzed() {
        /// Apply a specific boost to a clause.
        /// <param name="weight">A value greater than zero, by which the score will be multiplied. 
        /// If greater than 1, it will improve the weight of a clause</param>
        public ISearchBuilder Weighted(float weight) {
        /// Defines a clause as a filter, so that it only affect the results of the other clauses.
        /// For instance, if the other clauses returns nothing, even if this filter has matches the
        /// end result will be empty. It's like a two-pass query
        public ISearchBuilder AsFilter() {
        public ISearchBuilder SortBy(string name) {
        public ISearchBuilder SortByInteger(string name) {
        public ISearchBuilder SortByBoolean(string name) {
        public ISearchBuilder SortByString(string name) {
        public ISearchBuilder SortByDouble(string name) {
        public ISearchBuilder SortByDateTime(string name) {
        public ISearchBuilder Ascending()
        {
        public ISearchBuilder Slice(int skip, int count) {
        public IEnumerable<ISearchHit> Search() {
            return Enumerable.Empty<ISearchHit>();
        public ISearchHit Get(int documentId) {
            return null;
        public ISearchBits GetBits() {
            throw new NotImplementedException();
        public int Count() {
            return 0;
    }
}
