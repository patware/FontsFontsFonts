using FontsFontsFonts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FontsFontsFonts.Services.Design
{
    public class SettingsServiceDesign : Services.ISettingsService
    {
        public void GetInitialData(Action<InitialData, Exception> callback)
        {            
            if (callback == null) throw new ArgumentNullException(nameof(callback));

            var data = new InitialData();

            data.Message = Properties.Resources.SettingsServiceDesignMessage;

            data.Allfonts.Add(new OneFont(new System.Windows.Media.FontFamily("Arial")));
            data.Allfonts.Add(new OneFont(new System.Windows.Media.FontFamily("Century")));
            data.Allfonts.Add(new OneFont(new System.Windows.Media.FontFamily("Segoe Keycaps")));
                        
            data.LastFontSize = 24.5M;

            callback(data, null);
        }
    }
}
