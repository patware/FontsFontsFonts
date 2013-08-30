using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace FontsFontsFonts.Model
{
    public class DataItem
    {
        public System.Collections.ObjectModel.ObservableCollection<OneFont> AllFonts = new System.Collections.ObjectModel.ObservableCollection<OneFont>();

        public DataItem()
        {
            this.LastFontSize = 10.5M;
        }

        public decimal LastFontSize { get; set; }
    }
}
