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
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace Orchard.Azure.MediaServices.Models.Assets.EncoderMetadata {
    public class VideoTrack {
        private readonly XElement _xml;
        public VideoTrack(XElement xml) {
            _xml = xml;
        }
        /// <summary>
        /// The zero-based index of this video track. Note: this is not necessarily the TrackID as used in an MP4 file.
        /// </summary>
        public int Index {
            get {
                return XmlConvert.ToInt32(_xml.Attribute(XName.Get("Id")).Value);
            }
        /// The average video bit rate in bits per second, as calculated from the media file. Counts only the elementary stream payload, and does not include the packaging overhead.
        public int Bitrate {
                return XmlConvert.ToInt32(_xml.Attribute(XName.Get("Bitrate")).Value);
        /// The target average bitrate for this video track, as requested in the encoding preset, in bits per second.
        public int TargetBitrate {
                return XmlConvert.ToInt32(_xml.Attribute(XName.Get("TargetBitrate")).Value);
        /// The measured video frame rate in frames per second (Hz).
        public decimal Framerate {
                return XmlConvert.ToDecimal(_xml.Attribute(XName.Get("Framerate")).Value);
        /// The preset target video frame rate in frames per second (Hz).
        public decimal TargetFramerate {
                return XmlConvert.ToDecimal(_xml.Attribute(XName.Get("TargetFramerate")).Value);
        /// The video codec FourCC code.
        public string FourCc {
                return _xml.Attribute(XName.Get("FourCC")).Value;
        /// The encoded video width in pixels.
        public int Width {
                return XmlConvert.ToInt32(_xml.Attribute(XName.Get("Width")).Value);
        /// The encoded video height in pixels.
        public int Height {
                return XmlConvert.ToInt32(_xml.Attribute(XName.Get("Height")).Value);
        /// The numerator of the video display aspect ratio.
        public decimal DisplayAspectRatioX {
                return XmlConvert.ToDecimal(_xml.Attribute(XName.Get("DisplayAspectRatioNumerator")).Value);
        /// The demoninator of the video display aspect ratio.
        public decimal DisplayAspectRatioY {
                return XmlConvert.ToDecimal(_xml.Attribute(XName.Get("DisplayAspectRatioDenominator")).Value);
    }
}
