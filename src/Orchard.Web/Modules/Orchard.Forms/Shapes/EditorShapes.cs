using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using Orchard.DisplayManagement.Descriptors;
using Orchard.DisplayManagement.Shapes;
using Orchard.UI;

// ReSharper disable InconsistentNaming
namespace Orchard.Forms.Shapes {
    public class EditorShapes : IShapeTableProvider {
        private readonly ITagBuilderFactory _tagBuilderFactory;
        public EditorShapes(ITagBuilderFactory tagBuilderFactory) {
            _tagBuilderFactory = tagBuilderFactory;
        }
        public void Discover(ShapeTableBuilder builder) {
            // hack: This is important when using the Input shape directly, but it doesn't come into play
            // when using a 'master' shape yet.
            builder.Describe("Input").Configure(descriptor => descriptor.Wrappers.Add("InputWrapper"));
            builder.Describe("SelectList").Configure(descriptor => descriptor.Wrappers.Add("InputWrapper"));
            builder.Describe("Textarea").Configure(descriptor => descriptor.Wrappers.Add("InputWrapper"));
            builder.Describe("Form").OnCreating(ctx => ctx.Create = () => new PropertiesAreItems());
            builder.Describe("Fieldset").OnCreating(ctx => ctx.Create = () => new PropertiesAreItems());
        [Shape]
        public void InputLabel(HtmlHelper Html, TextWriter Output, dynamic Shape, string For, object Title) {
            if (Title != null) {
                var label = _tagBuilderFactory.Create(Shape, "label");
                label.MergeAttribute("for", For);
                label.InnerHtml = Html.Encode(Title);
                Output.WriteLine(label.ToString());
            }
        public void InputHint(dynamic Display, dynamic Shape, HtmlHelper Html, TextWriter Output, object Description/*, object ActionLinkValue, object ActionLink*/) {
            // <span class="hint">
            if (Description != null) {
                var span = _tagBuilderFactory.Create(Shape, "span");
                span.AddCssClass("hint");
                var html = Html.Encode(Description);
                html = html.Replace("\n", "</span><span class=\"hint\">");
                span.InnerHtml = html;
                Output.WriteLine(span.ToString(TagRenderMode.Normal));
            // action link
            if (Shape.ActionLinkValue != null) {
                if (Shape.ActionLink is string) {
                    Shape.ActionLink = new { Action = Shape.ActionLink };
                }
                Output.WriteLine("<p>" + Display.Link(RouteValues: Shape.ActionLink, Value: Shape.ActionLinkValue) + "</p>");
        public void InputRequiredMarker(TextWriter Output, HtmlHelper Html, dynamic Shape, object ErrorMessage, bool? IsValid) {
            if (!IsValid.GetValueOrDefault(true) && ErrorMessage != null) {
                span.AddCssClass(HtmlHelper.ValidationMessageCssClassName);
                span.InnerHtml = Html.Encode(Shape.ErrorMessage);
                Output.WriteLine(span.ToString());
        public void InputWrapper(
            HtmlHelper Html,
            TextWriter Output,
            dynamic Display,
            dynamic Shape,
            string Type,
            string Id,
            string Name,
            object Title,
            string TitleDisplay,
            string EnabledBy,
            bool? EnableWrapper) {
            /* 
             * #id #type #name #title #title_display #field_prefix #field_suffix #description #required
             * #title_display=={before,after,invisible,attribute,none}
             * 
             *  {form_element} ==InputWrapper
             *      <div attributes id="#id" class="form-type-#type form-item-#name">
             *          {form_element_label} ==InputLabel
             *              <label class="option?#title_display==after element-invisible?#title_display==invisible" for="#id">
             *                  #title 
             *                  {form_required_marker}  ==InputRequiredMarker
             *                      <span class='form-required'>This field is required.</span>
             *                  {/form_required_marker}?#required
             *              </label>
             *          {/form_element_label}?#title
             *          <span class="field-prefix">#field_prefix</span>?#field_prefix
             *          #child_content
             *          <span class="field-suffix">#field_suffix</span>?#field_suffix
             *          {form_element_label/}?#title_display==after
             *          <div class="description">#description</div>?
             *      </div>
             *  {/form_element}
             */
            // Wraps an input with metadata as follows (most of it is optional and won't render if not present):
            /*
            <div data-controllerid="{EnabledByInputId}">
                <label for="inputfieldname">{DisplayName}</label>
                {ChildContent}
                {ValidationMessage}
                <span class="hint">{Description}</span>
                <p><a href="{ActionLinkRouteUrl}">{ActionLinkText}</a></p>
            </div>
             * Note: For a checkbox, the label comes after
             * Note: Localizable strings should already be localized by this point.
             * When using this via an html.editor() call, the content has already been localized
             * by the generic MVC template.
            if (!EnableWrapper.GetValueOrDefault(true)) {
                Output.WriteLine(Shape.Metadata.ChildContent);
                return;
            // surrounding div
            var div = new TagBuilder("div");
            if (TitleDisplay == "attribute") {
                if (Title != null) {
                    div.MergeAttribute("title", Display(Title).ToString());
            if (!string.IsNullOrEmpty(EnabledBy)) {
                // note: the value should be the html ID of the input.
                // When using this via html.editor() the id is automatically converted from the property name
                // to the field id before it gets to the shape.
                div.MergeAttribute("data-controllerid", EnabledBy);
            Output.WriteLine(div.ToString(TagRenderMode.StartTag));
            var isCheckbox = new [] {"checkbox", "radio"}.Any(x => x.Equals(Type, StringComparison.OrdinalIgnoreCase));
            IHtmlString labelHtml = null;
                labelHtml = Display.InputLabel(For: Id, Title: Title, Input: Shape, Classes: isCheckbox ? new[] { "forcheckbox" } : null);
                if (TitleDisplay == "before" || (string.IsNullOrEmpty(TitleDisplay) && !isCheckbox)) {
                    Output.Write(labelHtml);
            Output.WriteLine(Shape.Metadata.ChildContent);
            if (Title != null && (TitleDisplay == "after" || (string.IsNullOrEmpty(TitleDisplay) && isCheckbox))) {
                Output.Write(labelHtml);
            Output.WriteLine(Display.InputRequiredMarker(Input: Shape));
            Output.WriteLine(Display.InputHint(Input: Shape, Description: Shape.Description, ActionLink: Shape.ActionLink, ActionLinkValue: Shape.ActionLinkValue));
            Output.WriteLine(div.ToString(TagRenderMode.EndTag));
        public void Form(HtmlHelper Html, Action<object> Output, dynamic Display, dynamic Shape, string Method, string Action) {
            // (todo) design markup
            OrchardTagBuilder tag = _tagBuilderFactory.Create(Shape, "form");
            tag.MergeAttribute("action", Action ?? Html.ViewContext.HttpContext.Request.Url.PathAndQuery);
            tag.MergeAttribute("method", Method ?? "POST");
            Output(tag.ToString(TagRenderMode.StartTag));
            foreach (var item in Ordered(Shape.Items)) {
                Output(Display(item));
            Output(tag.ToString(TagRenderMode.EndTag));
        public IHtmlString Hidden(dynamic Display, dynamic Shape) {
            return DisplayShapeAsInput(Display, Shape, "hidden");
        public void Fieldset(Action<object> Output, dynamic Display, dynamic Shape, object Title) {
            OrchardTagBuilder tag = _tagBuilderFactory.Create(Shape, "fieldset");
                Output("<legend>");
                Output(Display(Title));
                Output("</legend>");
        private static Tuple<string, object> Positionify(dynamic item, int naturalIndex) {
            if (item is IShape) {
                return new Tuple<string, object>(((IShape)item).Metadata.Position, item);
            if (item is Tuple<string, object>) {
                return item;
            else {
                // non-shape items are given a position equal to their index in the list, giving the shapes a way of mingling among them
                return new Tuple<string, object>(naturalIndex.ToString(CultureInfo.InvariantCulture), item);
        private static IEnumerable<object> Ordered(IEnumerable<object> items) {
            return items.Select(Positionify).OrderBy(p => p.Item1, new FlatPositionComparer()).Select(p => p.Item2);
        public IHtmlString Textbox(dynamic Display, dynamic Shape) {
            Shape.Classes.Add("text");
            return DisplayShapeAsInput(Display, Shape, "text");
        public IHtmlString Numberbox(dynamic Display, dynamic Shape) {
            Shape.Classes.Add("number");
            return DisplayShapeAsInput(Display, Shape, "number");
        public IHtmlString Password(dynamic Display, dynamic Shape) {
            Shape.Classes.Add("password");
            return DisplayShapeAsInput(Display, Shape, "password");
        public void Textarea(
            dynamic Shape, string Name, string Value, int Size = 0, int Rows = 0) {
            var textarea = (TagBuilder)_tagBuilderFactory.Create(Shape, "textarea");
            textarea.AddCssClass("text");
            if (Name != null) {
                textarea.MergeAttribute("name", Name, false);
            if (Size > 0) {
                textarea.MergeAttribute("size", Size.ToString(), false);
            if (Rows > 0) {
                textarea.MergeAttribute("rows", Rows.ToString(), false);
            Output.Write(textarea.ToString(TagRenderMode.StartTag));
            Output.Write(Value);
            Output.WriteLine(textarea.ToString(TagRenderMode.EndTag));
        public IHtmlString Submit(dynamic Display, dynamic Shape) {
            Shape.Classes.Add("primaryAction button");
            // (todo) this might not need full wrapper in hindsight?
            return DisplayShapeAsInput(Display, Shape, "submit");
        public IHtmlString Markup(dynamic Display, dynamic Shape, string Value) {
            return new MvcHtmlString(Value);
        public IHtmlString Button(dynamic Display, dynamic Shape) {
            return DisplayShapeAsInput(Display, Shape, "button");
        public IHtmlString Input(HtmlHelper Html, dynamic Shape, dynamic Display, string Type, string Name, dynamic Value, bool? Checked) {
            var tag = (TagBuilder)_tagBuilderFactory.Create(Shape, "input");
            tag.MergeAttribute("type", Type, false);
                tag.MergeAttribute("name", Name, false);
            if (Value != null) {
                Value = Value is string ? Value : Display(Value);
                tag.MergeAttribute("value", Convert.ToString(Value), false);
            if (Checked.GetValueOrDefault()) {
                tag.MergeAttribute("checked", "checked");
            return new HtmlString(tag.ToString(TagRenderMode.SelfClosing));
        private static IHtmlString DisplayShapeAsInput(dynamic Display, dynamic Shape, string inputType) {
            Shape.Metadata.Alternates.Clear();
            Shape.Type = inputType;
            Shape.Metadata.Type = "Input";
            // HACK: This code shouldn't know about this, but cascading shapes doesn't work well with wrappers and other metadata yet
            // todo: alternates, etc?
            Shape.Metadata.Wrappers.Clear();
            Shape.Metadata.Wrappers.Add("InputWrapper");
            var display = Display(Shape);
            // hack: so that InputWrapper doesn't render a 2nd time on the master shape
            return display;
        private static string ListItemToOption(SelectListItem item) {
            var option = new TagBuilder("option");
            option.InnerHtml = HttpUtility.HtmlEncode(item.Text);
            if (item.Value != null) {
                option.Attributes["value"] = item.Value;
            if (item.Selected) {
                option.Attributes["selected"] = "selected";
            return option.ToString(TagRenderMode.Normal);
        private static string ListGroupToOption(string name = null, bool isFirstGroup = false, bool finalize = false) {
            var option = new TagBuilder("optgroup");
            option.Attributes["label"] = name;
            if(isFirstGroup)
                return option.ToString(TagRenderMode.StartTag);
            if(finalize)
                return option.ToString(TagRenderMode.EndTag);
            return String.Concat(option.ToString(TagRenderMode.EndTag), option.ToString(TagRenderMode.StartTag));
        private static object GetSelectProperty(object obj, string propertyName) {
            if (string.IsNullOrEmpty(propertyName)) {
                return obj.ToString();
            var pi = obj.GetType().GetProperty(propertyName);
            return pi.GetValue(obj, new object[] { });
        public void SelectList(
            IEnumerable<object> Items,
            string DataTextField,
            string DataValueField,
            int Size = 0,
            bool Multiple = false
            ) {
            var select = (TagBuilder)_tagBuilderFactory.Create(Shape, "select");
                select.MergeAttribute("name", Name, false);
            if (Size > 1) {
                select.MergeAttribute("size", Size.ToString(), false);
            if (Multiple) {
                select.MergeAttribute("multiple", "multiple", false);
            Output.WriteLine(select.ToString(TagRenderMode.StartTag));
            string selectedValue = Convert.ToString(Shape.Value) ?? "";
            var selectedValues = selectedValue.Split(new[] { ',' });
            var isFirstGroup = true;
            var hasGroups = false;
            foreach (var item in Items) {
                var selectItem = item as SelectListItem;
                var selectGroup = item as SelectListGroup;
                if (selectItem == null && selectGroup == null) {
                    selectItem = new SelectListItem();
                    if (item is string) {
                        var itemStr = (string)item;
                        selectItem.Text = itemStr;
                        selectItem.Selected = (itemStr == Convert.ToString(Shape.Value));
                    }
                    else {
                        selectItem.Text = Convert.ToString(GetSelectProperty(item, DataTextField));
                        if (DataValueField != null) {
                            var value = GetSelectProperty(item, DataValueField);
                            selectItem.Value = Convert.ToString(value);
                            selectItem.Selected = (value == Shape.Value);
                        }
                else if (selectItem != null) {
                    selectItem.Selected = selectedValues.Any(x => x == selectItem.Value);
                if (selectGroup != null) {
                    isFirstGroup = isFirstGroup == false;
                    hasGroups = true;
                    Output.WriteLine(ListGroupToOption(selectGroup.Name, isFirstGroup));
                else
                    Output.WriteLine(ListItemToOption(selectItem));
            if(hasGroups)
                Output.WriteLine(ListGroupToOption(finalize: true));
            Output.WriteLine(select.ToString(TagRenderMode.EndTag));
        public IHtmlString Checkbox(dynamic Display, dynamic Shape) {
            return DisplayShapeAsInput(Display, Shape, "checkbox");
        public IHtmlString Radio(dynamic Display, dynamic Shape) {
            return DisplayShapeAsInput(Display, Shape, "radio");
        static TagBuilder GetTagBuilder(string tagName, string id, IEnumerable<string> classes, IDictionary<string, string> attributes) {
            var tagBuilder = new TagBuilder(tagName);
            tagBuilder.MergeAttributes(attributes, false);
            foreach (var cssClass in classes ?? Enumerable.Empty<string>())
                tagBuilder.AddCssClass(cssClass);
            if (!string.IsNullOrWhiteSpace(id))
                tagBuilder.GenerateId(id);
            return tagBuilder;
    }
}
