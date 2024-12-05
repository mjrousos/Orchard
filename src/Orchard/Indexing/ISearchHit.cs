using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
namespace Orchard.Indexing {
    public interface ISearchHit {
        int ContentItemId { get; }
        float Score { get; }

        int GetInt(string name);
        double GetDouble(string name);
        bool GetBoolean(string name);
        string GetString(string name);
        DateTime GetDateTime(string name);
    }
}
