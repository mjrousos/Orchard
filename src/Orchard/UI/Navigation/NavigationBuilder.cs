using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Orchard.UI.Navigation {
    public class NavigationBuilder {
        private readonly IList<string> _imageSets = new List<string>();
        List<MenuItem> Contained { get; set; }
        public NavigationBuilder() {
            Contained = new List<MenuItem>();
        }
        public NavigationBuilder Add(LocalizedString caption, string position, Action<NavigationItemBuilder> itemBuilder, IEnumerable<string> classes = null) {
            var childBuilder = new NavigationItemBuilder();
            
            childBuilder.Caption(caption);
            childBuilder.Position(position);
            itemBuilder(childBuilder);
            Contained.AddRange(childBuilder.Build());
            if (classes != null) {
                foreach (var className in classes) 
                    childBuilder.AddClass(className);
            }
            return this;
        public NavigationBuilder Add(LocalizedString caption, Action<NavigationItemBuilder> itemBuilder, IEnumerable<string> classes = null) {
            return Add(caption, null, itemBuilder, classes);
        public NavigationBuilder Add(Action<NavigationItemBuilder> itemBuilder, IEnumerable<string> classes = null) {
            return Add(null, null, itemBuilder, classes);
        public NavigationBuilder Add(LocalizedString caption, string position, IEnumerable<string> classes = null) {
            return Add(caption, position, x=> { }, classes);
        public NavigationBuilder Add(LocalizedString caption, IEnumerable<string> classes = null) {
            return Add(caption, null, x => { }, classes);
        public NavigationBuilder Remove(MenuItem item) {
            Contained.Remove(item);
        public NavigationBuilder AddImageSet(string imageSet) {
            _imageSets.Add(imageSet);
        public IEnumerable<MenuItem> Build() {
            return (Contained ?? Enumerable.Empty<MenuItem>()).ToList();
        public IEnumerable<string> BuildImageSets() {
            return _imageSets.Distinct();
    }
}
