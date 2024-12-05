using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Azure.MediaServices.Services.Wams {
	public class WamsLocatorInfo {
		public  WamsLocatorInfo(string id, string url) {
			Id = id;
			Url = url;
		}

		public string Id { get; private set; }
		public string Url { get; private set; }
	}
}
