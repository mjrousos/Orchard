using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Orchard.Azure.MediaServices.ViewModels.Tasks {
	public class EncodeViewModel {
		public IEnumerable<string> EncodingPresets {
			get;
			set;
		}
		[Required]
		public string SelectedEncodingPreset {
	}
}
