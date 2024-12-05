using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Orchard.Data {
    public class Orderable<T> {
        private IQueryable<T> _queryable;
        public Orderable(IQueryable<T> enumerable) {
            _queryable = enumerable;
        }
        public IQueryable<T> Queryable {
            get { return _queryable; }
        public Orderable<T> Asc<TKey>(Expression<Func<T, TKey>> keySelector) {
            _queryable = _queryable
                .OrderBy(keySelector);
            return this;
        public Orderable<T> Asc<TKey1, TKey2>(Expression<Func<T, TKey1>> keySelector1,
                                              Expression<Func<T, TKey2>> keySelector2) {
                .OrderBy(keySelector1)
                .OrderBy(keySelector2);
        public Orderable<T> Asc<TKey1, TKey2, TKey3>(Expression<Func<T, TKey1>> keySelector1,
                                                     Expression<Func<T, TKey2>> keySelector2,
                                                     Expression<Func<T, TKey3>> keySelector3) {
                .OrderBy(keySelector2)
                .OrderBy(keySelector3);
        public Orderable<T> Desc<TKey>(Expression<Func<T, TKey>> keySelector) {
                .OrderByDescending(keySelector);
        public Orderable<T> Desc<TKey1, TKey2>(Expression<Func<T, TKey1>> keySelector1,
                                               Expression<Func<T, TKey2>> keySelector2) {
                .OrderByDescending(keySelector1)
                .OrderByDescending(keySelector2);
        public Orderable<T> Desc<TKey1, TKey2, TKey3>(Expression<Func<T, TKey1>> keySelector1,
                                                      Expression<Func<T, TKey2>> keySelector2,
                                                      Expression<Func<T, TKey3>> keySelector3) {
                .OrderByDescending(keySelector2)
                .OrderByDescending(keySelector3);
    }
}
