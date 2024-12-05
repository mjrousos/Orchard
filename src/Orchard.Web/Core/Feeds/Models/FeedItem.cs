using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Xml.Linq;

namespace Orchard.Core.Feeds.Models {
    public class FeedItem {
        private object _item;
        public object Item { get { return _item; } set { SetItem(value); } }
        public XElement Element { get; set; }
        
        protected virtual void SetItem(object item) {
            _item = item;
        }
    }
    public class FeedItem<TItem> : FeedItem {
        private TItem _item;
        public new TItem Item { get { return _item; } set { SetItem(value); } }
        protected override void SetItem(object item) {
            _item = (TItem) item;
            base.SetItem(item);
}
