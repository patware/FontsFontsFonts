using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace FontsFontsFonts.Messaging
{
    public class FontStylingChanged
    {
        public decimal FontSize { get; set; }
        public System.Windows.FontStyle FontStyle { get; set; }
        public FontStretch FontStretch { get; set; }
        public FontWeight FontWeight { get; set; }
    }
}
