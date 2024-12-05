using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using System.ComponentModel.DataAnnotations;
using Orchard.ContentManagement.FieldStorage.InfosetStorage;

namespace Orchard.SecureSocketsLayer.Models {
    public class SslSettings {
        public bool Enabled { get; set; }
        public bool UsePermanentRedirect { get; set; }
        public string Urls { get; set; }
        public bool SecureEverything { get; set; }
        public bool CustomEnabled { get; set; }
        public string SecureHostName { get; set; }
        public string InsecureHostName { get; set; }
    }
    public class SslSettingsPart : ContentPart {
        public const string CacheKey = "SslSettingsPart";
        public string Urls {
            get { return this.As<InfosetPart>().Get<SslSettingsPart>("Urls"); }
            set { this.As<InfosetPart>().Set<SslSettingsPart>("Urls", value); }
        }
        public bool SecureEverything {
            get {
                var attributeValue = this.As<InfosetPart>().Get<SslSettingsPart>("SecureEverything");
                return !String.IsNullOrWhiteSpace(attributeValue) && Convert.ToBoolean(attributeValue);
            }
            set { this.As<InfosetPart>().Set<SslSettingsPart>("SecureEverything", value.ToString()); }
        public bool Enabled {
                var attributeValue = this.As<InfosetPart>().Get<SslSettingsPart>("Enabled");
            set { this.As<InfosetPart>().Set<SslSettingsPart>("Enabled", value.ToString()); }
        public bool UsePermanentRedirect {
                var attributeValue = this.As<InfosetPart>().Get<SslSettingsPart>("UsePermanentRedirect");
            set { this.As<InfosetPart>().Set<SslSettingsPart>("UsePermanentRedirect", value.ToString()); }
        public bool CustomEnabled {
                var attributeValue = this.As<InfosetPart>().Get<SslSettingsPart>("CustomEnabled");
            set { this.As<InfosetPart>().Set<SslSettingsPart>("CustomEnabled", value.ToString()); }
        [Required]
        public string SecureHostName {
            get { return this.As<InfosetPart>().Get<SslSettingsPart>("SecureHostName"); }
            set { this.As<InfosetPart>().Set<SslSettingsPart>("SecureHostName", value); }
        public string InsecureHostName {
            get { return this.As<InfosetPart>().Get<SslSettingsPart>("InsecureHostName"); }
            set { this.As<InfosetPart>().Set<SslSettingsPart>("InsecureHostName", value); }
        public bool SendStrictTransportSecurityHeaders {
            get { return this.Retrieve(x => x.SendStrictTransportSecurityHeaders); }
            set { this.Store(x => x.SendStrictTransportSecurityHeaders, value); }
        public bool StrictTransportSecurityIncludeSubdomains {
            get { return this.Retrieve(x => x.StrictTransportSecurityIncludeSubdomains); }
            set { this.Store(x => x.StrictTransportSecurityIncludeSubdomains, value); }
        public int StrictTransportSecurityMaxAge {
            get { return this.Retrieve(x => x.StrictTransportSecurityMaxAge, 31536000); }
            set { this.Store(x => x.StrictTransportSecurityMaxAge, value); }
        public bool StrictTransportSecurityPreload {
            get { return this.Retrieve(x => x.StrictTransportSecurityPreload); }
            set { this.Store(x => x.StrictTransportSecurityPreload, value); }
}
