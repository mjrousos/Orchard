using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.Data {
    /// <summary>
    /// Mark a property to be excluded from NHibernate mapping
    /// </summary>
    public class DoNotMapAttribute : Attribute {
    }
}
//usage:
//
//public class PersonRecord {
//    public virtual int Id { get; set; }
//    public virtual string FirstName { get; set; }
//    public virtual string LastName { get; set; }
//    [DoNotMap]
//    public virtual string FullName { get {return Fullname+", "+LastName;} }
//}
