using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;

namespace NHibernate.Linq.Expressions
{
	/// <summary>
	/// Extended node types for custom expressions
	/// </summary>
	public enum NHibernateExpressionType
	{
		QuerySource = 1000, //make sure these don't overlap with ExpressionType
		RootEntity,
		Entity,
		PropertyAccess,
		CollectionAccess
	}
}
