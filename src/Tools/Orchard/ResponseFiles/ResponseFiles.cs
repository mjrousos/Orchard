using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.ResponseFiles {
    public class ResponseFiles {
        public IEnumerable<ResponseLine> ReadFiles(IEnumerable<string> filenames) {
            foreach (var filename in filenames) {
                foreach(var line in new ResponseFileReader().ReadLines(filename))
                {
                    yield return line;
                }
            }
        }
    }
}
