using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.Data.Migration;

namespace Orchard.Workflows {
    public class Migrations : DataMigrationImpl {
        public int Create() {
			// Creating table TransitionRecord
            SchemaBuilder.CreateTable("TransitionRecord", table => table
				.Column<int>("Id", column => column.PrimaryKey().Identity())
                .Column<string>("SourceEndpoint")
                .Column<string>("DestinationEndpoint")
                .Column<int>("SourceActivityRecord_id")
                .Column<int>("DestinationActivityRecord_id")
                .Column<int>("WorkflowDefinitionRecord_id")
			);
			// Creating table WorkflowRecord
			SchemaBuilder.CreateTable("WorkflowRecord", table => table
                .Column<int>("Id", column => column.PrimaryKey().Identity())
                .Column<string>("State", column => column.Unlimited())
                .Column<int>("ContentItemRecord_id")
            );
			// Creating table WorkflowDefinitionRecord
			SchemaBuilder.CreateTable("WorkflowDefinitionRecord", table => table
				.Column<bool>("Enabled")
                .Column<string>("Name", column => column.WithLength(1024))
			// Creating table AwaitingActivityRecord
			SchemaBuilder.CreateTable("AwaitingActivityRecord", table => table
                .Column<int>("ActivityRecord_id")
                .Column<int>("WorkflowRecord_id")
			// Creating table ActivityRecord
			SchemaBuilder.CreateTable("ActivityRecord", table => table
                .Column<string>("Name")
                .Column<int>("X")
                .Column<int>("Y")
				.Column<string>("State", c => c.Unlimited())
                .Column<bool>("Start")
            return 1;
        }
    }
}
