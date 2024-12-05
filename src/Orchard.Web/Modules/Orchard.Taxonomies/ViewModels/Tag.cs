using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Newtonsoft.Json;

namespace Orchard.Taxonomies.ViewModels {
	public class Tag {
		[JsonProperty("label")]
		public string Label { get; set; }
		[JsonProperty("value")]
		public int Value { get; set; }
		[JsonProperty("levels")]
		public int Levels { get; set; }
		[JsonProperty("disabled")]
		public bool Disabled { get; set; }
	}
}
