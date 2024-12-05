using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Web;

namespace Orchard.DisplayManagement.Shapes {
    [DebuggerTypeProxy(typeof(ShapeDebugView))]
    public class Shape : Composite, IShape, IPositioned, IEnumerable<object> {
        private const string DefaultPosition = "5";
        private readonly IList<object> _items = new List<object>();
        private readonly IList<string> _classes = new List<string>();
        private readonly IDictionary<string, string> _attributes = new Dictionary<string, string>();
        public ShapeMetadata Metadata { get; set; }
        public virtual string Id { get; set; }
        public virtual IList<string> Classes { get { return _classes; } }
        public virtual IDictionary<string, string> Attributes { get { return _attributes; } }
        public virtual IEnumerable<dynamic> Items { get { return _items; } }
        public string Position {
            get {
                return Metadata.Position;
            }
        }
        public Shape() {
            Metadata = new ShapeMetadata();
        public virtual Shape Add(object item, string position = null) {
            // pszmyd: Ignoring null shapes 
            if (item == null) {
                return this;
            try {
                if (position != null && item is IHtmlString) {
                    item = new PositionWrapper((IHtmlString)item, position);
                }
                else if (position != null && item is string) {
                    item = new PositionWrapper((string)item, position);
                else if (item is IShape) {
                    ((IShape)item).Metadata.Position = position;
            catch {
                // need to implement positioned wrapper for non-shape objects
            _items.Add(item); // not messing with position at the moment
            return this;
        public virtual Shape AddRange(IEnumerable<object> items, string position = DefaultPosition) {
            foreach (var item in items)
                Add(item, position);
        IEnumerator<object> IEnumerable<object>.GetEnumerator() {
            return _items.GetEnumerator();
        public virtual IEnumerator GetEnumerator() {
        public override bool TryConvert(ConvertBinder binder, out object result) {
            result = Items;
            if (binder.ReturnType == typeof(IEnumerable<object>)
                || binder.ReturnType == typeof(IEnumerable<dynamic>)) {
                return true;
            return base.TryConvert(binder, out result);
        //public class ShapeBehavior : ClayBehavior {
        public override bool TrySetIndex(SetIndexBinder binder, object[] indexes, object value) {
            if (indexes.Count() == 1) {
                var name = indexes.Single().ToString();
                if (name.Equals("Id")) {
                    // need to mutate the actual type
                    Id = Convert.ToString(value);
                    return true;
                if (name.Equals("Classes")) {
                    var args = Arguments.From(new[] { value }, Enumerable.Empty<string>());
                    MergeClasses(args, Classes);
                if (name.Equals("Attributes")) {
                    MergeAttributes(args, Attributes);
                if (name.Equals("Items")) {
                    MergeItems(args, this);
            return base.TrySetIndex(binder, indexes, value);
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result) {
            var name = binder.Name;
            var arguments = Arguments.From(args, binder.CallInfo.ArgumentNames);
            if (name.Equals("Id")) {
                // need to mutate the actual type
                Id = Convert.ToString(args.FirstOrDefault());
                result = this;
            if (name.Equals("Classes") && !arguments.Named.Any()) {
                MergeClasses(arguments, Classes);
            if (name.Equals("Attributes") && arguments.Positional.Count() <= 1) {
                MergeAttributes(arguments, Attributes);
            if (name.Equals("Items")) {
                MergeItems(arguments, this);
            return base.TryInvokeMember(binder, args, out result);
        private static void MergeAttributes(INamedEnumerable<object> args, IDictionary<string, string> attributes) {
            var arg = args.Positional.SingleOrDefault();
            if (arg != null) {
                if (arg is IDictionary) {
                    var dictionary = arg as IDictionary;
                    foreach (var key in dictionary.Keys) {
                        attributes[Convert.ToString(key)] = Convert.ToString(dictionary[key]);
                    }
                else {
                    foreach (var prop in arg.GetType().GetProperties()) {
                        attributes[TranslateIdentifier(prop.Name)] = Convert.ToString(prop.GetValue(arg, null));
            foreach (var named in args.Named) {
                attributes[named.Key] = Convert.ToString(named.Value);
        private static string TranslateIdentifier(string name) {
            // Allows for certain characters in an identifier to represent different
            // characters in an HTML attribute (mimics MVC behavior):
            // data_foo ==> data-foo
            // @keyword ==> keyword
            return name.Replace("_", "-").Replace("@", "");
        private static void MergeClasses(INamedEnumerable<object> args, IList<string> classes) {
            foreach (var arg in args) {
                // look for string first, because the "string" type is also an IEnumerable of char
                if (arg is string) {
                    classes.Add(arg as string);
                else if (arg is IEnumerable) {
                    foreach (var item in arg as IEnumerable) {
                        classes.Add(Convert.ToString(item));
                    classes.Add(Convert.ToString(arg));
        private static void MergeItems(INamedEnumerable<object> args, dynamic shape) {
                    shape.Add(arg as string);
                        shape.Add(item);
                    shape.Add(Convert.ToString(arg));
        
    }
}
