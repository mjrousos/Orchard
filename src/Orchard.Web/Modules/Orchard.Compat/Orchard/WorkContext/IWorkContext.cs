using System;
using System.Web;
using Orchard.Security;
using Orchard.Settings;

namespace Orchard
{
    public interface IWorkContext
    {
        T Resolve<T>() where T : class;
        object Resolve(Type type);
        T GetState<T>(string name);
        void SetState<T>(string name, T value);
        IUser CurrentUser { get; }
        ISite CurrentSite { get; }
        HttpContextBase HttpContext { get; }
        string CurrentCulture { get; set; }
    }

    public interface IWorkContextAccessor
    {
        IWorkContext GetContext();
        IWorkContextScope CreateWorkContextScope();
    }

    public interface IWorkContextScope : IDisposable
    {
        WorkContext WorkContext { get; }
    }

    public class WorkContext : IWorkContext
    {
        public T Resolve<T>() where T : class
        {
            return default(T);
        }

        public object Resolve(Type type)
        {
            return null;
        }

        public T GetState<T>(string name)
        {
            return default(T);
        }

        public void SetState<T>(string name, T value)
        {
        }

        public IUser CurrentUser { get; set; }
        public ISite CurrentSite { get; set; }
        public HttpContextBase HttpContext { get; set; }
        public string CurrentCulture { get; set; }
    }

    public interface ISite
    {
        string SiteName { get; }
        string SiteSalt { get; }
        string SuperUser { get; }
        string BaseUrl { get; }
        string SiteCulture { get; }
        string SiteCalendar { get; }
        ResourceDebugMode ResourceDebugMode { get; }
        bool UseCdn { get; }
        int PageSize { get; }
        int MaxPageSize { get; }
        string SiteTimeZone { get; }
    }

    public enum ResourceDebugMode
    {
        FromAppSetting,
        Enabled,
        Disabled
    }
}
