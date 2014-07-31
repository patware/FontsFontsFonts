using System;
using GalaSoft.MvvmLight;
using System.Windows.Media;
using System.Collections.Generic;

namespace FontsFontsFonts.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class FontViewModel : ViewModelBase
    {
        public class AdjustedTypeFont 
        { 

        }

        /// <summary>
        /// Initializes a new instance of the FontViewModel class.
        /// </summary>
        public FontViewModel()
        {
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<Messaging.FontSelected>(this, onFontSelected);
            _familyMaps = new System.Collections.ObjectModel.ObservableCollection<FontFamilyMap>();
            _familyNames = new System.Collections.ObjectModel.ObservableCollection<KeyValuePair<string, string>>();
            _familyTypeFaces = new System.Collections.ObjectModel.ObservableCollection<FamilyTypeface>();
            
            if (this.IsInDesignMode)
            {
                var ff = new System.Windows.Media.FontFamily("Arial");
                loadFont(ff);
            }
            
        }

        #region Privates Don't look
        private void loadFont(System.Windows.Media.FontFamily fontFamily)
        {

            _fontName = fontFamily.ToString();
            _baseline = fontFamily.Baseline;
            _baseUri = (fontFamily.BaseUri == null) ? "N/A" : fontFamily.BaseUri.ToString();
            _familyMaps.Clear();
            foreach (var fm in fontFamily.FamilyMaps)
                _familyMaps.Add(fm);

            _familyNames.Clear();
            foreach (var fn in fontFamily.FamilyNames)
                _familyNames.Add(new KeyValuePair<string,string>(fn.Key.ToString(), fn.Value));

            _familyTypeFaces.Clear();
            foreach (var ftf in fontFamily.FamilyTypefaces)
                _familyTypeFaces.Add(ftf);

            _lineSpacing = fontFamily.LineSpacing;
            _source = fontFamily.Source;

        }
        #endregion

        #region Messaging

        private void onFontSelected(Messaging.FontSelected message)
        {
            var of = message.Font;
            var ff = new System.Windows.Media.FontFamily(of.Name);
            loadFont(ff);
        }
        #endregion

        #region Properties

        #region FontName
        /// <summary>
        /// The <see cref="FontName" /> property's name.
        /// </summary>
        public const string FontNamePropertyName = "FontName";

        private string _fontName;

        /// <summary>
        /// Sets and gets the FontName property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string FontName
        {
            get
            {
                return _fontName;
            }

            set
            {
                if (_fontName == value)
                {
                    return;
                }

                RaisePropertyChanging(FontNamePropertyName);
                _fontName = value;
                RaisePropertyChanged(FontNamePropertyName);
            }
        }
        #endregion

        #region Baseline
        /// <summary>
        /// The <see cref="Baseline" /> property's name.
        /// </summary>
        public const string BaselinePropertyName = "Baseline";

        private double _baseline;

        /// <summary>
        /// Sets and gets the Baseline property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public double Baseline
        {
            get
            {
                return _baseline;
            }

            set
            {
                if (_baseline == value)
                {
                    return;
                }

                RaisePropertyChanging(BaselinePropertyName);
                _baseline = value;
                RaisePropertyChanged(BaselinePropertyName);
            }
        }
        #endregion

        #region BaseUri
        /// <summary>
        /// The <see cref="BaseUri" /> property's name.
        /// </summary>
        public const string BaseUriPropertyName = "BaseUri";

        private string _baseUri;

        /// <summary>
        /// Sets and gets the BaseUri property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string BaseUri
        {
            get
            {
                return _baseUri;
            }

            set
            {
                if (_baseUri == value)
                {
                    return;
                }

                RaisePropertyChanging(BaseUriPropertyName);
                _baseUri = value;
                RaisePropertyChanged(BaseUriPropertyName);
            }
        }
        #endregion

        #region FamilyMaps
        /// <summary>
        /// The <see cref="FamilyMaps" /> property's name.
        /// </summary>
        public const string FamilyMapsPropertyName = "FamilyMaps";

        private System.Collections.ObjectModel.ObservableCollection<FontFamilyMap> _familyMaps;

        /// <summary>
        /// Sets and gets the FamilyMaps property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public System.Collections.ObjectModel.ObservableCollection<FontFamilyMap> FamilyMaps
        {
            get
            {
                return _familyMaps;
            }

            set
            {
                if (_familyMaps == value)
                {
                    return;
                }

                RaisePropertyChanging(FamilyMapsPropertyName);
                _familyMaps = value;
                RaisePropertyChanged(FamilyMapsPropertyName);
            }
        }
        #endregion

        #region FamilyNames
        /// <summary>
        /// The <see cref="FamilyNames" /> property's name.
        /// </summary>
        public const string FamilyNamesPropertyName = "FamilyNames";

        private System.Collections.ObjectModel.ObservableCollection<KeyValuePair<string,string>> _familyNames;

        /// <summary>
        /// Sets and gets the FamilyNames property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public System.Collections.ObjectModel.ObservableCollection<KeyValuePair<string,string>> FamilyNames
        {
            get
            {
                return _familyNames;
            }

            set
            {
                if (_familyNames == value)
                {
                    return;
                }

                RaisePropertyChanging(FamilyNamesPropertyName);
                _familyNames = value;
                RaisePropertyChanged(FamilyNamesPropertyName);
            }
        }
        #endregion
	
        #region FamilyTypeFaces
	    /// <summary>
        /// The <see cref="FamilyTypeFaces" /> property's name.
        /// </summary>
        public const string FamilyTypeFacesPropertyName = "FamilyTypeFaces";

        private System.Collections.ObjectModel.ObservableCollection<FamilyTypeface> _familyTypeFaces;

        /// <summary>
        /// Sets and gets the FamilyTypeFaces property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public System.Collections.ObjectModel.ObservableCollection<FamilyTypeface> FamilyTypeFaces
        {
            get
            {
                return _familyTypeFaces;
            }

            set
            {
                if (_familyTypeFaces == value)
                {
                    return;
                }

                RaisePropertyChanging(FamilyTypeFacesPropertyName);
                _familyTypeFaces = value;
                RaisePropertyChanged(FamilyTypeFacesPropertyName);
            }
        }
	#endregion
	
        #region LineSpacing
	    /// <summary>
        /// The <see cref="LineSpacing" /> property's name.
        /// </summary>
        public const string LineSpacingPropertyName = "LineSpacing";

        private double _lineSpacing;

        /// <summary>
        /// Sets and gets the LineSpacing property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public double LineSpacing
        {
            get
            {
                return _lineSpacing;
            }

            set
            {
                if (_lineSpacing == value)
                {
                    return;
                }

                RaisePropertyChanging(LineSpacingPropertyName);
                _lineSpacing = value;
                RaisePropertyChanged(LineSpacingPropertyName);
            }
        }
	#endregion
	
        #region Source
	    /// <summary>
        /// The <see cref="Source" /> property's name.
        /// </summary>
        public const string SourcePropertyName = "Source";

        private string _source;

        /// <summary>
        /// Sets and gets the Source property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Source
        {
            get
            {
                return _source;
            }

            set
            {
                if (_source == value)
                {
                    return;
                }

                RaisePropertyChanging(SourcePropertyName);
                _source = value;
                RaisePropertyChanged(SourcePropertyName);
            }
        }
	#endregion
	
        #endregion
    }
}