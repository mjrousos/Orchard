using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;

namespace Orchard.Layouts.Elements {
    public class Row : Container {
        
        public override string Category {
            get { return "Layout"; }
        }
        public override LocalizedString DisplayText {
            get { return T("Row"); }
        public override bool IsSystemElement {
            get { return true; }
        public override bool HasEditor {
            get { return false; }
        public IEnumerable<Column> Columns {
            get { return Elements.Cast<Column>(); }
        public int Size {
            get { return Columns.Sum(x => x.Size); }
    }
}
