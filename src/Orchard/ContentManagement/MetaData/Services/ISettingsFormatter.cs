using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Xml.Linq;
using Orchard.ContentManagement.MetaData.Models;

namespace Orchard.ContentManagement.MetaData.Services {
    /// <summary>
    /// Abstraction to manage settings metadata on a content.
    /// </summary>
    public interface ISettingsFormatter : IDependency {
        /// <summary>
        /// Maps an XML element to a settings dictionary.
        /// </summary>
        /// <param name="element">The XML element to be mapped.</param>
        /// <returns>The settings dictionary.</returns>
        SettingsDictionary Map(XElement element);
        /// Maps a settings dictionary to an XML element.
        /// <param name="settingsDictionary">The settings dictionary.</param>
        /// <returns>The XML element.</returns>
        XElement Map(SettingsDictionary settingsDictionary);
    }
}
