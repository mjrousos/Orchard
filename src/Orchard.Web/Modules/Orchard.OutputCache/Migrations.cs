using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;
using Orchard.Data.Migration;
using Orchard.OutputCache.Models;

namespace Orchard.OutputCache {
    public class Migrations : DataMigrationImpl {
        private readonly IOrchardServices _orchardServices;
        public Migrations(IOrchardServices orchardServices) {
            _orchardServices = orchardServices;
        }
        public int Create() {
            
            SchemaBuilder.CreateTable("CacheParameterRecord",
                    table => table
                        .Column<int>("Id", c => c.PrimaryKey().Identity())
                        .Column<int>("Duration")
                        .Column<int>("GraceTime")
                        .Column<string>("RouteKey", c => c.WithLength(255))
                    );
            return 7;
        public int UpdateFrom1() {
                table => table
                    .Column<int>("Id", c => c.PrimaryKey().Identity())
                    .Column<int>("Duration")
                    .Column<string>("RouteKey", c => c.WithLength(255))
                );
            return 2;
        public int UpdateFrom2() {
            return 3;
        public int UpdateFrom3() {
            SchemaBuilder.AlterTable("CacheParameterRecord",
                        .AddColumn<int>("MaxAge")
            return 4;
        
        public int UpdateFrom4() {
            return 5;
        public int UpdateFrom5() {
            return 6;
        public int UpdateFrom6() {
                    table => {
                        table.DropColumn("MaxAge");
                        table.AddColumn<int>("GraceTime");
                    });
        public int UpdateFrom7() {
            var cacheSettings = _orchardServices.WorkContext.CurrentSite.As<CacheSettingsPart>();
            if (!string.IsNullOrWhiteSpace(cacheSettings.VaryByQueryStringParameters)) {
                // Prevent behavior from changing if vary on querystring was used prior to introduction of exclusive mode
                cacheSettings.VaryByQueryStringIsExclusive = false;
            }
            else {
                cacheSettings.VaryByQueryStringIsExclusive = true; // Default mode
            };
            return 8;
    }
}
