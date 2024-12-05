using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Linq;

namespace NHibernate.Linq
{
	public interface INHibernateQueryable
	{
		QueryOptions QueryOptions { get; }
	}
	public interface INHibernateQueryable<T> : INHibernateQueryable, IOrderedQueryable<T>
		IQueryable<T> Expand(string path);
}
