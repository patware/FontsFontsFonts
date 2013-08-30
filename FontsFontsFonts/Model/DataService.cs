using System;

namespace FontsFontsFonts.Model
{
    public class DataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to connect to the actual data service

            var item = new DataItem();
            foreach (var ff in System.Windows.Media.Fonts.SystemFontFamilies)
                item.AllFonts.Add(new OneFont(ff));

            callback(item, null);
        }
    }
}