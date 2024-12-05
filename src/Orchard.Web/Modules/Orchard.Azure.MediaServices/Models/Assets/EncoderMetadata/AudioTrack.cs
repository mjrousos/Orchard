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
    public class AudioTrack {
        private readonly XElement _xml;
        public AudioTrack(XElement xml) {
            _xml = xml;
        }
        /// <summary>
        /// The zero-based index of the audio track. Note: this is not necessarily the TrackID as used in an MP4 file.
        /// </summary>
        public int Index {
            get {
                return XmlConvert.ToInt32(_xml.Attribute(XName.Get("Id")).Value);
            }
        /// The average audio bitrate in bits per second, as calculated from the media file. Takes into consideration only the elementary stream payload and does not include the packaging overhead.
        public int Bitrate {
                return XmlConvert.ToInt32(_xml.Attribute(XName.Get("Bitrate")).Value);
        /// The audio sampling rate in samples/sec or Hz
        public int SamplingRate {
                return XmlConvert.ToInt32(_xml.Attribute(XName.Get("SamplingRate")).Value);
        /// The bits per sample for the audio track.
        public int BitsPerSample {
                return XmlConvert.ToInt32(_xml.Attribute(XName.Get("BitsPerSample")).Value);
        /// The number of audio channels in the audio track.
        public int Channels {
                return XmlConvert.ToInt32(_xml.Attribute(XName.Get("Channels")).Value);
        /// The audio codec used for encoding the audio track.
        public string Codec {
                return _xml.Attribute(XName.Get("Codec")).Value;
        /// The optional encoder version string, required for EAC3.
        public string EncoderVersion {
                var encoderVersionAttribute = _xml.Attribute(XName.Get("EncoderVersion"));
                if (encoderVersionAttribute != null)
                    return encoderVersionAttribute.Value;
                return null;
    }
}
