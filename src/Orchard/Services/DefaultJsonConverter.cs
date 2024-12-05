using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Orchard.Services {
    /// <summary>
    /// An implementation of <see cref="IJsonConverter"/> using the Newtonsoft.Json library
    /// </summary>
    public class DefaultJsonConverter : IJsonConverter {
        public string Serialize(object o) {
            return JsonConvert.SerializeObject(o);
        }
        public string Serialize(object o, JsonFormat format) {
            return JsonConvert.SerializeObject(o, format == JsonFormat.Indented ? Formatting.Indented : Formatting.None);
        public dynamic Deserialize(string json) {
            dynamic result = JObject.Parse(json);
            return result;
        public T Deserialize<T>(string json) {
            return JsonConvert.DeserializeObject<T>(json);
    }
}
