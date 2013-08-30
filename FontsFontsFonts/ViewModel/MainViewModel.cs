using GalaSoft.MvvmLight;
using FontsFontsFonts.Model;
using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace FontsFontsFonts.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    _fonts = new ReadOnlyObservableCollection<OneFont>(item.AllFonts);                    
                    _fontSize = item.LastFontSize;
                });


            addFontStyles();

            addFontStretches();

            addFontWeights();
        }
        private void addFontStyles()
        {
            var fontstyles = new List<FontStyle>();
            fontstyles.Add(System.Windows.FontStyles.Normal);
            fontstyles.Add(System.Windows.FontStyles.Italic);
            fontstyles.Add(System.Windows.FontStyles.Oblique);
            _windowsFontStyles = fontstyles.ToArray();
        }

        private void addFontStretches()
        {
            var fontstretches = new List<FontStretch>();
            fontstretches.Add(FontStretches.Condensed);
            fontstretches.Add(FontStretches.Expanded);
            fontstretches.Add(FontStretches.ExtraCondensed);
            fontstretches.Add(FontStretches.ExtraExpanded);
            fontstretches.Add(FontStretches.Medium);
            //fontstretches.Add(FontStretches.Normal);
            fontstretches.Add(FontStretches.SemiCondensed);
            fontstretches.Add(FontStretches.SemiExpanded);
            fontstretches.Add(FontStretches.UltraCondensed);
            fontstretches.Add(FontStretches.UltraExpanded);

            _windowsFontStretches = fontstretches.ToArray();
        }

        private void addFontWeights()
        {
            var items = new List<FontWeight>();

            items.Add(FontWeights.Black);
            items.Add(FontWeights.Bold);
            items.Add(FontWeights.DemiBold);
            items.Add(FontWeights.ExtraBlack);
            items.Add(FontWeights.ExtraBold);
            items.Add(FontWeights.ExtraLight);
            items.Add(FontWeights.Heavy);
            items.Add(FontWeights.Light);
            items.Add(FontWeights.Medium);
            //items.Add(FontWeights.Normal);
            items.Add(FontWeights.Regular);
            items.Add(FontWeights.SemiBold);
            items.Add(FontWeights.Thin);
            items.Add(FontWeights.UltraBlack);
            items.Add(FontWeights.UltraBold);
            items.Add(FontWeights.UltraLight);

            _windowsFontWeights = items.ToArray();
        }

        private void setFontOverride()
        {
            foreach (var font in _fonts)
            {
                font.OverrideDisplayWith = _input;
            }
        }

        #region Properties

        #region Input
        /// <summary>
        /// The <see cref="Input" /> property's name.
        /// </summary>
        public const string InputPropertyName = "Input";

        private string _input;

        /// <summary>
        /// Sets and gets the Input property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Input
        {
            get
            {
                return _input;
            }

            set
            {
                if (_input == value)
                {
                    return;
                }

                RaisePropertyChanging(InputPropertyName);
                _input = value;
                setFontOverride();
                RaisePropertyChanged(InputPropertyName);
            }
        }

        #endregion

        #region WindowsFontStyles
        /// <summary>
        /// The <see cref="WindowsFontStyles" /> property's name.
        /// </summary>
        public const string WindowsFontStylesPropertyName = "WindowsFontStyles";

        private System.Windows.FontStyle[] _windowsFontStyles;

        /// <summary>
        /// Sets and gets the WindowsFontStyles property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public System.Windows.FontStyle[] WindowsFontStyles
        {
            get
            {
                return _windowsFontStyles;
            }

            set
            {
                if (_windowsFontStyles == value)
                {
                    return;
                }

                RaisePropertyChanging(WindowsFontStylesPropertyName);
                _windowsFontStyles = value;
                RaisePropertyChanged(WindowsFontStylesPropertyName);
            }
        }
        #endregion
        
        #region Fonts
        /// <summary>
        /// The <see cref="Fonts" /> property's name.
        /// </summary>
        public const string FontsPropertyName = "Fonts";

        private ReadOnlyObservableCollection<OneFont> _fonts;

        /// <summary>
        /// Sets and gets the Fonts property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ReadOnlyObservableCollection<OneFont> Fonts
        {
            get
            {
                return _fonts;
            }

        }
        #endregion

        #region FontSize
        /// <summary>
        /// The <see cref="FontSize" /> property's name.
        /// </summary>
        public const string FontSizePropertyName = "FontSize";

        private decimal _fontSize;

        /// <summary>
        /// Sets and gets the FontSize property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal FontSize
        {
            get
            {
                return _fontSize;
            }

            set
            {
                if (_fontSize == value)
                {
                    return;
                }

                RaisePropertyChanging(FontSizePropertyName);
                _fontSize = value;
                RaisePropertyChanged(FontSizePropertyName);
            }
        }
        #endregion

        #region WindowsFontStretches
        /// <summary>
        /// The <see cref="WindowsFontStretches" /> property's name.
        /// </summary>
        public const string WindowsFontStretchesPropertyName = "WindowsFontStretches";

        private FontStretch[] _windowsFontStretches;

        /// <summary>
        /// Sets and gets the WindowsFontStretches property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public FontStretch[] WindowsFontStretches
        {
            get
            {
                return _windowsFontStretches;
            }

            set
            {
                if (_windowsFontStretches == value)
                {
                    return;
                }

                RaisePropertyChanging(WindowsFontStretchesPropertyName);
                _windowsFontStretches = value;
                RaisePropertyChanged(WindowsFontStretchesPropertyName);
            }
        }
        #endregion

        #region WindowsFontWeights
        /// <summary>
        /// The <see cref="WindowsFontWeights" /> property's name.
        /// </summary>
        public const string WindowsFontWeightsPropertyName = "WindowsFontWeights";

        private FontWeight[] _windowsFontWeights;

        /// <summary>
        /// Sets and gets the WindowsFontWeights property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public FontWeight[] WindowsFontWeights
        {
            get
            {
                return _windowsFontWeights;
            }

            set
            {
                if (_windowsFontWeights == value)
                {
                    return;
                }

                RaisePropertyChanging(WindowsFontWeightsPropertyName);
                _windowsFontWeights = value;
                RaisePropertyChanged(WindowsFontWeightsPropertyName);
            }
        }
        #endregion
	
	    
        #endregion
    }
}