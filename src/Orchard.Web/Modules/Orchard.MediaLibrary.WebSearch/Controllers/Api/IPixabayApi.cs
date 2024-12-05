using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Threading.Tasks;
using RestEase;

namespace Orchard.MediaLibrary.WebSearch.Controllers.Api {
    [Header("User-Agent", "RestEase")]
    public interface IPixabayApi {
        [Get("api/")]
        Task<string> GetImagesAsync(string key, string q);
    }
}
