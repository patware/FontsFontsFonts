using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FontsFontsFonts.Model;

namespace FontsFontsFonts.Messaging
{
    public class FontSelected
    {
        public OneFont Font { get; set; }
        public FontSelected()
        {

        }
        public FontSelected(OneFont font)
        {
            this.Font = font;
        }
    }
}
