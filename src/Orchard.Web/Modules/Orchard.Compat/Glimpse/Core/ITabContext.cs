using System;

namespace Glimpse.Core.Extensibility
{
    public interface ITabContext
    {
        object GetRequestContext();
        T GetMessage<T>() where T : class;
    }

    public interface ITabSetupContext
    {
        object GetRequestContext();
        void SetupFor<T>() where T : class;
    }
}
