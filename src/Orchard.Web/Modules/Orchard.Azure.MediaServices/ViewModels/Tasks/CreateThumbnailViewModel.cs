using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.ComponentModel.DataAnnotations;

namespace Orchard.Azure.MediaServices.ViewModels.Tasks {
	public class CreateThumbnailViewModel {
		public CreateThumbnailViewModel() {
			FileName = "{OriginalFilename}_{Size}_{ThumbnailTime}_{ThumbnailIndex}.{DefaultExtension}";
			Width = "*";
			Height = "80";
			StartTime = "0:0:0";
			Type = "Jpeg";
		}
		[Required]
		public string Width {
			get;
			set;
		public string Height {
		public string Type {
		public string FileName {
		public string StartTime {
		public string StopTime {
		public string Step {
	}
}
