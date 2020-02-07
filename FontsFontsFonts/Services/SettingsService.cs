using FontsFontsFonts.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace FontsFontsFonts.Services
{
    public class SettingsService : ISettingsService
    {
        public void GetInitialData(Action<InitialData, Exception> callback)
        {            
            if (callback == null) throw new ArgumentNullException(nameof(callback));

            var data = new InitialData();

            data.Message = Properties.Resources.SettingsServiceMessage;

            var ofl = from f in System.Windows.Media.Fonts.SystemFontFamilies
                      orderby f.ToString()
                      select f;

            foreach(var sff in ofl)
                data.Allfonts.Add(new OneFont(sff));

            data.LastFontSize = 12;

            callback(data, null);
        }
    }
}
