using System;
using System.Linq;

namespace FontsFontsFonts.Model
{
    public class DataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to connect to the actual data service

            var item = new DataItem();
            var ofl = from f in System.Windows.Media.Fonts.SystemFontFamilies
                     orderby f.ToString()
                     select f;
            
            foreach (var ff in ofl)
                item.AllFonts.Add(new OneFont(ff));

            callback(item, null);
        }
    }
}