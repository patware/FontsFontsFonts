using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FontsFontsFonts.Model
{
    public class FontDetail
    {
        private System.Windows.Media.FontFamily _fontFamily;

        public FontDetail()
        {

        }
        public FontDetail(System.Windows.Media.FontFamily fontFamily)
        {
            _fontFamily = fontFamily;
        }

        public string Name { get { return _fontFamily.ToString(); } }
        public double Baseline { get { return _fontFamily.Baseline; } }
        public string BaseUri { get { return (_fontFamily.BaseUri == null) ? "N/A" : _fontFamily.BaseUri.ToString(); } }
        public System.Windows.Media.FontFamilyMapCollection FamilyMaps { get { return _fontFamily.FamilyMaps; } }
        public System.Collections.Generic.Dictionary<string, string> FamilyNames 
        { 
            get 
            { 
                var dic = new System.Collections.Generic.Dictionary<string, string>(_fontFamily.FamilyNames.Count);

                foreach (var fn in _fontFamily.FamilyNames) 
                {
                    dic.Add(fn.Key.ToString(), fn.Value);
                }
                return dic;
            } 
            
        }
        public System.Windows.Media.FamilyTypefaceCollection FamilyTypefaces { get { return _fontFamily.FamilyTypefaces; } }
        public double LineSpacing { get { return _fontFamily.LineSpacing; } }
        public string Source { get { return (_fontFamily.Source == null) ? "N/A" : _fontFamily.Source; } }

    }
}
