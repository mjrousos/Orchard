﻿using System;
using System.Linq;
using Orchard.ContentManagement;
using Orchard.ContentPicker.Fields;
using Orchard.Events;
using Orchard.Localization;

namespace Orchard.ContentPicker.Tokens {
    public interface ITokenProvider : IEventHandler {
        void Describe(dynamic context);
        void Evaluate(dynamic context);
    }

    public class ContentPickerFieldTokens : ITokenProvider {
        private readonly IContentManager _contentManager;

        public ContentPickerFieldTokens(IContentManager contentManager) {
            _contentManager = contentManager;
        }

        public Localizer T { get; set; }

        public void Describe(dynamic context) {
            context.For("ContentPickerField", T("Content Picker Field"), T("Tokens for Content Picker Fields"))
                .Token("Content", T("Content Item"), T("The content item."))
                ;
        }

        public void Evaluate(dynamic context) {
            context.For<ContentPickerField>("ContentPickerField")
                .Token("Content", (Func<ContentPickerField, object>)(field => field.Ids[0]))
                .Chain("Content", "Content", (Func<ContentPickerField, object>)(field => {
                    var id = field.Ids.Any() ? field.Ids[0] : 0;
                    return _contentManager.Get(id);
                }))
                ;
        }
    }
}