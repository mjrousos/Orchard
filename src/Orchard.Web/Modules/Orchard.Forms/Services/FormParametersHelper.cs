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
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Orchard.Forms.Services {
    public static class FormParametersHelper {
        public static string ToString(dynamic state) {
            var json = JsonConvert.SerializeObject(state);
            var doc = (XmlDocument)JsonConvert.DeserializeXmlNode("{ 'Form': " + json + "}");
            using (var sw = new StringWriter()) {
                doc.Save(sw);
                return sw.ToString();
            }
        }
        public static string ToString(IDictionary<string, string> parameters) {
            var doc = new XDocument();
            doc.Add(new XElement("Form"));
            var root = doc.Root;
            if (root == null) {
                return String.Empty;
            foreach (var entry in parameters) {
                if (entry.Key.StartsWith("_")) {
                    continue;
                }
                root.Add(new XElement(XmlConvert.EncodeLocalName(entry.Key), entry.Value));
            return doc.ToString(SaveOptions.DisableFormatting);
        public static IDictionary<string, string> FromString(string parameters) {
            var result = new Dictionary<string, string>();
            if (String.IsNullOrEmpty(parameters)) {
                return result;
            var doc = XDocument.Parse(parameters);
            if (doc.Root == null) {
            foreach (var element in doc.Root.Elements()) {
                result.Add(element.Name.LocalName, element.Value);
            return result;
        public static dynamic ToDynamic(string parameters) {
            var result = new JObject();
                result[element.Name.LocalName] = element.Value;
        public static dynamic FromJsonString(string state) {
            if (string.IsNullOrWhiteSpace(state)) {
                return null;
            return JObject.Parse(state);
        public static string ToJsonString(FormCollection formCollection) {
            var o = new JObject();
            foreach (var key in formCollection.AllKeys) {
                if (key.StartsWith("_")) {
                o.Add(new JProperty(key, formCollection.Get(key)));
            return JsonConvert.SerializeObject(o);
        public static string ToJsonString(object item) {
            return JsonConvert.SerializeObject(item);
    }
}
