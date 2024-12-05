using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;

namespace Orchard.MediaLibrary {
    public class MediaDataMigration : DataMigrationImpl {
        public int Create() {
            SchemaBuilder.CreateTable("MediaPartRecord", t => t
                .ContentPartRecord()
                .Column<string>("MimeType")
                .Column<string>("Caption", c => c.Unlimited())
                .Column<string>("AlternateText", c => c.Unlimited())
                .Column<string>("FolderPath", c => c.WithLength(2048))
                .Column<string>("FileName", c => c.WithLength(2048))
            );
            SchemaBuilder.AlterTable("MediaPartRecord", t => t
                .CreateIndex("IDX_MediaPartRecord_FolderPath", "FolderPath")
            ContentDefinitionManager.AlterPartDefinition("MediaPart", part => part
                .Attachable()
                .WithDescription("Turns a content type into a Media. Note: you need to set the stereotype to \"Media\" as well.")
            ContentDefinitionManager.AlterPartDefinition("ImagePart", part => part
                .WithDescription("Provides common metadata for an Image Media.")
            ContentDefinitionManager.AlterPartDefinition("VectorImagePart", part => part
                .WithDescription("Provides common metadata for a Vector Image Media.")
            ContentDefinitionManager.AlterPartDefinition("VideoPart", part => part
                .WithDescription("Provides common metadata for a Video Media.")
            ContentDefinitionManager.AlterPartDefinition("AudioPart", part => part
                .WithDescription("Provides common metadata for an Audio Media.")
            ContentDefinitionManager.AlterPartDefinition("DocumentPart", part => part
                .WithDescription("Provides common metadata for a Document Media.")
            ContentDefinitionManager.AlterPartDefinition("OEmbedPart", part => part
                .WithDescription("Provides common metadata for an OEmbed Media.")
            ContentDefinitionManager.AlterTypeDefinition("Image", td => td
                .DisplayedAs("Image")
                .WithSetting("MediaFileNameEditorSettings.ShowFileNameEditor", "True")
                .AsImage()
                .WithIdentity()
            ContentDefinitionManager.AlterTypeDefinition("VectorImage", td => td
                .DisplayedAs("Vector Image")
                .AsVectorImage()
            ContentDefinitionManager.AlterTypeDefinition("Video", td => td
                .DisplayedAs("Video")
                .AsVideo()
            ContentDefinitionManager.AlterTypeDefinition("Audio", td => td
                .DisplayedAs("Audio")
                .AsAudio()
            ContentDefinitionManager.AlterTypeDefinition("Document", td => td
                .DisplayedAs("Document")
                .AsDocument()
            ContentDefinitionManager.AlterTypeDefinition("OEmbed", td => td
               .DisplayedAs("External Media")
               .WithSetting("Stereotype", "Media")
               .WithIdentity()
               .WithPart("CommonPart")
               .WithPart("MediaPart")
               .WithPart("OEmbedPart")
               .WithPart("TitlePart")
           );
            return 7;
        }
        public int UpdateFrom2() {
            return 3;
        public int UpdateFrom3() {
                            .Attachable()
                            .WithDescription("Provides common metadata for an Image Media.")
                        );
                            .WithDescription("Provides common metadata for a Video Media.")
                            .WithDescription("Provides common metadata for an Audio Media.")
                            .WithDescription("Provides common metadata for a Document Media.")
                            .WithDescription("Provides common metadata for an OEmbed Media.")
            return 4;
        
        public int UpdateFrom4() {
            
            return 5;
        public int UpdateFrom5() {
            return 6;
        public int UpdateFrom6() {
                .WithSetting("Stereotype", "Media")
                .WithPart("CommonPart")
                .WithPart("MediaPart")
                .WithPart("VectorImagePart")
                .WithPart("TitlePart")
    }
}
