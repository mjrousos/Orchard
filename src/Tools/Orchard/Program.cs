using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.IO;

namespace Orchard {
    public class Program {
        const int ConsoleInputBufferSize = 8192;
        public static int Main(string[] args) {
            Console.SetIn(new StreamReader(Console.OpenStandardInput(ConsoleInputBufferSize)));
            return (int)new OrchardHost(Console.In, Console.Out, args).Run();
        }
    }
}
