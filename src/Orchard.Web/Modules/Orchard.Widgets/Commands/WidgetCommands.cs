using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Commands;
using Orchard.Widgets.Services;

namespace Orchard.Widgets.Commands {
    public class WidgetCommands : DefaultOrchardCommandHandler {
        private readonly IWidgetCommandsService _widgetCommandsService;
        public WidgetCommands(
            IWidgetCommandsService widgetCommandsService) {
            _widgetCommandsService = widgetCommandsService;            
            RenderTitle = true;
        }
        [OrchardSwitch]
        public string Title { get; set; }
        public string Name { get; set; }
        public bool RenderTitle { get; set; }
        public string Zone { get; set; }
        public string Position { get; set; }
        public string Layer { get; set; }
        public string Identity { get; set; }
        public string Owner { get; set; }
        public string Text { get; set; }
        public bool UseLoremIpsumText { get; set; }
        public bool Publish { get; set; }
        public string MenuName { get; set; }
        [CommandName("widget create")]
        [CommandHelp("widget create <type> /Title:<title> /Name:<name> /Zone:<zone> /Position:<position> /Layer:<layer> [/Identity:<identity>] [/RenderTitle:true|false] [/Owner:<owner>] [/Text:<text>] [/UseLoremIpsumText:true|false] [/MenuName:<name>]\r\n\t" + "Creates a new widget")]
        [OrchardSwitches("Title,Name,Zone,Position,Layer,Identity,Owner,Text,UseLoremIpsumText,MenuName,RenderTitle")]
        public void Create(string type) {
            var widget = _widgetCommandsService.CreateBaseWidget(
                Context, type, Title, Name, Zone, Position, Layer, Identity, RenderTitle, Owner, Text, UseLoremIpsumText, MenuName);
            if (widget == null) {
                return;
            }
            _widgetCommandsService.Publish(widget);
            Context.Output.WriteLine(T("Widget created successfully.").Text);
    }
}
