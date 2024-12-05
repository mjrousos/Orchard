using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.Azure.MediaServices.Models.Records;

namespace Orchard.Azure.MediaServices.Models.Assets {
	public class AssetUploadState {
		private readonly AssetRecord _record;
		public AssetUploadState(AssetRecord record) {
			_record = record;
		}
		public AssetUploadStatus Status {
			get {
				return _record.UploadStatus;
			}
			set {
				_record.UploadStatus = value;
		public DateTime? StartedUtc {
				return _record.UploadStartedUtc;
				_record.UploadStartedUtc = value;
		public DateTime? CompletedUtc {
				return _record.UploadCompletedUtc;
				_record.UploadCompletedUtc = value;
		public long? BytesComplete {
				return _record.UploadBytesComplete;
				_record.UploadBytesComplete = value;
		public double? PercentComplete {
				return BytesComplete.HasValue ? (double?)BytesComplete.Value / (double?)_record.LocalTempFileSize * 100 : (double?)null;
	}
}
