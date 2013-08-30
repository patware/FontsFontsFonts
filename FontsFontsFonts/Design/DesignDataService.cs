using System;
using FontsFontsFonts.Model;

namespace FontsFontsFonts.Design
{
    public class DesignDataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to create design time data

            var item = new DataItem();
            item.AllFonts.Add(new OneFont(new System.Windows.Media.FontFamily("Arial")));
            item.AllFonts.Add(new OneFont(new System.Windows.Media.FontFamily("Century")));
            item.AllFonts.Add(new OneFont(new System.Windows.Media.FontFamily("Segoe Keycaps")));
            item.AllFonts.Add(new OneFont() { OverrideDisplayWith = "Lorem Ipsum" });

            item.LastFontSize = 24.5M;

            callback(item, null);
        }
    }
}