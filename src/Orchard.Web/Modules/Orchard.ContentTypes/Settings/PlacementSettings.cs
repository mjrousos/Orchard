using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.ContentTypes.Settings {
    public class PlacementSettings : IEquatable<PlacementSettings> {
        /// <summary>
        /// e.g., Parts_Title_Summary
        /// </summary>
        public string ShapeType { get; set; }
        /// e.g., Header, /Navigation
        public string Zone { get; set; }
        
        /// e.g, 5, after.7
        public string Position { get; set; }
        /// e.g, 5, MyTextField
        public string Differentiator { get; set; }
        public bool IsSameAs(PlacementSettings other) {
            return (ShapeType ?? String.Empty) == (other.ShapeType ?? String.Empty)
                && (Differentiator ?? String.Empty) == (other.Differentiator ?? String.Empty);
        }
        public bool Equals(PlacementSettings other) {
            if(other == this) {
                return true;
            }
            if(other == null) {
                return false;
                   && (Zone ?? String.Empty) == (other.Zone ?? String.Empty)
                   && (Position ?? String.Empty) == (other.Position ?? String.Empty)
                   && (Differentiator ?? String.Empty) == (other.Differentiator ?? String.Empty);
    }
}
