using System;

namespace FontsFontsFonts.Services
{
    public interface IMessenger
    {
        void Register<T>(Action<T> callback);
        void Send<T>(T message);
    }
}