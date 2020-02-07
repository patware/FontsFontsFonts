using System;
using System.Collections.Generic;
using System.Text;

namespace FontsFontsFonts.Services
{
    public interface ISettingsService
    {
        void GetInitialData(Action<Models.InitialData, Exception> callback);
    }
}
