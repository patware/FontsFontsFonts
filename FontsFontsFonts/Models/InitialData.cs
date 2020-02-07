using System.Collections.ObjectModel;

namespace FontsFontsFonts.Models
{
    public class InitialData
    {
        public InitialData()
        {
            Allfonts = new ObservableCollection<OneFont>();
        }
        public ObservableCollection<OneFont> Allfonts { get; internal set; }
        public decimal LastFontSize { get; internal set; }
        public string Message { get; internal set; }
    }
}