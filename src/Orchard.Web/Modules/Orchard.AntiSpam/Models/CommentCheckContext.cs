using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.AntiSpam.Models {
    public class CommentCheckContext {
        /// <summary>
        /// The front page or home URL of the instance making the request. For a blog 
        /// or wiki this would be the front page. Note: Must be a full URI, including http://.
        /// </summary>
        public string Url { get; set; }

        /// IP address of the comment submitter.
        public string UserIp { get; set; }
        
        /// User agent string of the web browser submitting the comment - typically 
        /// the HTTP_USER_AGENT cgi variable. Not to be confused with the user agent 
        /// of your Akismet library.
        public string UserAgent { get; set; }
        /// The content of the HTTP_REFERER header should be sent here.
        public string Referrer { get; set; }
        /// The permanent location of the entry the comment was submitted to.
        public string Permalink { get; set; }
        /// May be blank, comment, trackback, pingback, or a made up value like "registration".
        public string CommentType { get; set; }
        /// Name submitted with the comment
        public string CommentAuthor { get; set; }
        /// Email address submitted with the comment
        public string CommentAuthorEmail { get; set; }
        /// URL submitted with comment
        public string CommentAuthorUrl { get; set; }
        /// The content that was submitted.
        public string CommentContent { get; set; }
    }
}
