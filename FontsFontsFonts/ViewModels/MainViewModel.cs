using FontsFontsFonts.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace FontsFontsFonts.ViewModels
{
    public class MainViewModel : Base.ViewModelBase
    {
        private readonly Services.ISettingsService _settingsService;
        private readonly IMessenger _messaging;

        public MainViewModel(Services.ISettingsService settingsService, Services.IMessenger messaging)
        {
            _settingsService = settingsService ?? throw new ArgumentNullException(nameof(settingsService));
            _messaging = messaging;

            _input = "Before GetInitialData";

            _settingsService.GetInitialData((item, error) => { 
                if (error != null)
                {
                    return;
                }
                _input = item.Message;
                _fonts = new System.Collections.ObjectModel.ReadOnlyObservableCollection<Models.OneFont>(item.Allfonts);
                _fontSize = item.LastFontSize;
                SetFontOverride();
            });

            AddFontStyles();
            AddFontStretches();
            AddFontWeights();

            this.PropertyChanged += MainViewModel_PropertyChanged;

            SendFontName();
            SendFontStyle();
        }


        void MainViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case SelectedFontPropertyName:
                    SendFontName();
                    break;
                case FontSizePropertyName:
                case SelectedFontStretchPropertyName:
                case SelectedFontStylePropertyName:
                case SelectedFontWeightPropertyName:
                    SendFontStyle();
                    break;
            }
        }

        private void SendFontStyle()
        {
            var fsc = new Messaging.FontStylingChanged()
            {
                FontSize = this.FontSize,
                FontStretch = this.SelectedFontStretch,
                FontStyle = this.SelectedFontStyle,
                FontWeight = this.SelectedFontWeight
            };
            _messaging.Send<Messaging.FontStylingChanged>(fsc);
        }

        private void SendFontName()
        {
            _messaging.Send<Messaging.FontSelected>(new Messaging.FontSelected(_selectedFont));
        }
        private void AddFontStyles()
        {
            var fontstyles = new List<System.Windows.FontStyle>();
            fontstyles.Add(System.Windows.FontStyles.Normal);
            fontstyles.Add(System.Windows.FontStyles.Italic);
            fontstyles.Add(System.Windows.FontStyles.Oblique);
            _windowsFontStyles = fontstyles.ToArray();
        }

        private void AddFontStretches()
        {
            var fontstretches = new List<System.Windows.FontStretch>();
            fontstretches.Add(System.Windows.FontStretches.Condensed);
            fontstretches.Add(System.Windows.FontStretches.Expanded);
            fontstretches.Add(System.Windows.FontStretches.ExtraCondensed);
            fontstretches.Add(System.Windows.FontStretches.ExtraExpanded);
            fontstretches.Add(System.Windows.FontStretches.Medium);
            //fontstretches.Add(FontStretches.Normal);
            fontstretches.Add(System.Windows.FontStretches.SemiCondensed);
            fontstretches.Add(System.Windows.FontStretches.SemiExpanded);
            fontstretches.Add(System.Windows.FontStretches.UltraCondensed);
            fontstretches.Add(System.Windows.FontStretches.UltraExpanded);

            _windowsFontStretches = fontstretches.ToArray();
        }

        private void AddFontWeights()
        {
            var items = new List<System.Windows.FontWeight>();

            items.Add(System.Windows.FontWeights.Black);
            items.Add(System.Windows.FontWeights.Bold);
            items.Add(System.Windows.FontWeights.DemiBold);
            items.Add(System.Windows.FontWeights.ExtraBlack);
            items.Add(System.Windows.FontWeights.ExtraBold);
            items.Add(System.Windows.FontWeights.ExtraLight);
            items.Add(System.Windows.FontWeights.Heavy);
            items.Add(System.Windows.FontWeights.Light);
            items.Add(System.Windows.FontWeights.Medium);
            //items.Add(FontWeights.Normal);
            items.Add(System.Windows.FontWeights.Regular);
            items.Add(System.Windows.FontWeights.SemiBold);
            items.Add(System.Windows.FontWeights.Thin);
            items.Add(System.Windows.FontWeights.UltraBlack);
            items.Add(System.Windows.FontWeights.UltraBold);
            items.Add(System.Windows.FontWeights.UltraLight);

            _windowsFontWeights = items.ToArray();
        }
        private void SetFontOverride()
        {
            foreach (var font in Fonts)
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

                _input = value;
                SetFontOverride();
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

                _windowsFontStyles = value;
                RaisePropertyChanged(WindowsFontStylesPropertyName);
            }
        }


        #endregion

        #region Fonts

        private System.Collections.ObjectModel.ReadOnlyObservableCollection<Models.OneFont> _fonts;
        /// <summary>
        /// Sets and gets the Fonts property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public System.Collections.ObjectModel.ReadOnlyObservableCollection<Models.OneFont> Fonts
        {
            get { return _fonts; }

        }
        #endregion

        #region SelectedFont
        /// <summary>
        /// The <see cref="SelectedFont" /> property's name.
        /// </summary>
        public const string SelectedFontPropertyName = "SelectedFont";

        private Models.OneFont _selectedFont;

        /// <summary>
        /// Sets and gets the SelectedFont property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Models.OneFont SelectedFont
        {
            get
            {
                return _selectedFont;
            }

            set
            {
                if (_selectedFont == value)
                {
                    return;
                }

                _selectedFont = value;
                RaisePropertyChanged(SelectedFontPropertyName);
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

        private System.Windows.FontStretch[] _windowsFontStretches;

        /// <summary>
        /// Sets and gets the WindowsFontStretches property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public System.Windows.FontStretch[] WindowsFontStretches
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

        private System.Windows.FontWeight[] _windowsFontWeights;

        /// <summary>
        /// Sets and gets the WindowsFontWeights property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public System.Windows.FontWeight[] WindowsFontWeights
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

                _windowsFontWeights = value;
                RaisePropertyChanged(WindowsFontWeightsPropertyName);
            }
        }
        #endregion

        #region SelectedFontStyle
        /// <summary>
        /// The <see cref="SelectedFontStyle" /> property's name.
        /// </summary>
        public const string SelectedFontStylePropertyName = "SelectedFontStyle";

        private System.Windows.FontStyle _selectedFontStyle;

        /// <summary>
        /// Sets and gets the SelectedFontStyle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public System.Windows.FontStyle SelectedFontStyle
        {
            get
            {
                return _selectedFontStyle;
            }

            set
            {
                if (_selectedFontStyle == value)
                {
                    return;
                }

                _selectedFontStyle = value;
                RaisePropertyChanged(SelectedFontStylePropertyName);
            }
        }
        #endregion

        #region SelectedFontStretch
        /// <summary>
        /// The <see cref="SelectedFontStretch" /> property's name.
        /// </summary>
        public const string SelectedFontStretchPropertyName = "SelectedFontStretch";

        private System.Windows.FontStretch _selectedFontStretch;

        /// <summary>
        /// Sets and gets the SelectedFontStretch property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public System.Windows.FontStretch SelectedFontStretch
        {
            get
            {
                return _selectedFontStretch;
            }

            set
            {
                if (_selectedFontStretch == value)
                {
                    return;
                }

                _selectedFontStretch = value;
                RaisePropertyChanged(SelectedFontStretchPropertyName);
            }
        }
        #endregion

        #region SelectedFontWeight
        /// <summary>
        /// The <see cref="SelectedFontWeight" /> property's name.
        /// </summary>
        public const string SelectedFontWeightPropertyName = "SelectedFontWeight";

        private System.Windows.FontWeight _selectedFontWeight;

        /// <summary>
        /// Sets and gets the SelectedFontWeight property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public System.Windows.FontWeight SelectedFontWeight
        {
            get
            {
                return _selectedFontWeight;
            }

            set
            {
                if (_selectedFontWeight == value)
                {
                    return;
                }

                _selectedFontWeight = value;
                RaisePropertyChanged(SelectedFontWeightPropertyName);
            }
        }
        #endregion

        #endregion

        #region Messenging

        #endregion
    }
}
