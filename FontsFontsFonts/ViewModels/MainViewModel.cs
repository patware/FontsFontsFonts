using FontsFontsFonts.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FontsFontsFonts.ViewModels
{
    public class MainViewModel : Base.ViewModelBase
    {
        ///private readonly Services.ISettingsService _settingsService;
        private readonly IMessenger _messaging;

        public MainViewModel(Services.ISettingsService settingsService, Services.IMessenger messaging)
        {
            if (settingsService == null)
                throw new ArgumentNullException(nameof(settingsService));

            _messaging = messaging;

            _input = "Before GetInitialData";

            settingsService.GetInitialData((item, error) => {
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
                case WindowsFontStretcheSelectedPropertyName:
                case WindowsFontStyleSelectedPropertyName:
                case WindowsFontWeightSelectedPropertyName:
                    SendFontStyle();
                    break;
            }
        }

        private void SendFontStyle()
        {
            var fsc = new Messaging.FontStylingChanged()
            {
                FontSize = this.FontSize,
                FontStretch = this.WindowsFontStretcheSelected,
                FontStyle = this.WindowsFontStyleSelected,
                FontWeight = this.WindowsFontWeightSelected
            };
            _messaging.Send<Messaging.FontStylingChanged>(fsc);
        }

        private void SendFontName()
        {
            _messaging.Send<Messaging.FontSelected>(new Messaging.FontSelected(_selectedFont));
        }
        private void AddFontStyles()
        {
            var fontstyles = new List<System.Windows.FontStyle>
            {
                System.Windows.FontStyles.Normal,
                System.Windows.FontStyles.Italic,
                System.Windows.FontStyles.Oblique
            };
            _windowsFontStyles = new ObservableCollection<System.Windows.FontStyle>(fontstyles);
        }

        private void AddFontStretches()
        {
            var fontstretches = new List<System.Windows.FontStretch>
            {
                System.Windows.FontStretches.Condensed,
                System.Windows.FontStretches.Expanded,
                System.Windows.FontStretches.ExtraCondensed,
                System.Windows.FontStretches.ExtraExpanded,
                System.Windows.FontStretches.Medium,
                ///fontstretches.Add(FontStretches.Normal);
                System.Windows.FontStretches.SemiCondensed,
                System.Windows.FontStretches.SemiExpanded,
                System.Windows.FontStretches.UltraCondensed,
                System.Windows.FontStretches.UltraExpanded
            };

            _windowsFontStretches = new ObservableCollection<System.Windows.FontStretch>(fontstretches);
        }

        private void AddFontWeights()
        {
            var items = new List<System.Windows.FontWeight>
            {
                System.Windows.FontWeights.Black,
                System.Windows.FontWeights.Bold,
                System.Windows.FontWeights.DemiBold,
                System.Windows.FontWeights.ExtraBlack,
                System.Windows.FontWeights.ExtraBold,
                System.Windows.FontWeights.ExtraLight,
                System.Windows.FontWeights.Heavy,
                System.Windows.FontWeights.Light,
                System.Windows.FontWeights.Medium,
                ///items.Add(FontWeights.Normal);
                System.Windows.FontWeights.Regular,
                System.Windows.FontWeights.SemiBold,
                System.Windows.FontWeights.Thin,
                System.Windows.FontWeights.UltraBlack,
                System.Windows.FontWeights.UltraBold,
                System.Windows.FontWeights.UltraLight
            };

            _windowsFontWeights = new ObservableCollection<System.Windows.FontWeight>(items);
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

        private ObservableCollection<System.Windows.FontStyle> _windowsFontStyles;

        /// <summary>
        /// Sets and gets the WindowsFontStyles property.
        /// Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public ObservableCollection<System.Windows.FontStyle> WindowsFontStyles
        {
            get
            {
                return _windowsFontStyles;
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

        private ObservableCollection<System.Windows.FontStretch> _windowsFontStretches;

        /// <summary>
        /// Sets and gets the WindowsFontStretches property.
        /// Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public ObservableCollection<System.Windows.FontStretch> WindowsFontStretches
        {
            get
            {
                return _windowsFontStretches;
            }
        }
        #endregion

        #region WindowsFontWeights
        /// <summary>
        /// The <see cref="WindowsFontWeights" /> property's name.
        /// </summary>
        public const string WindowsFontWeightsPropertyName = "WindowsFontWeights";

        private ObservableCollection<System.Windows.FontWeight> _windowsFontWeights;

        /// <summary>
        /// Sets and gets the WindowsFontWeights property.
        /// Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public ObservableCollection<System.Windows.FontWeight> WindowsFontWeights
        {
            get
            {
                return _windowsFontWeights;
            }
        }
        #endregion

        #region WindowsFontStyleSelected
        /// <summary>
        /// The <see cref="WindowsFontStyleSelected" /> property's name.
        /// </summary>
        public const string WindowsFontStyleSelectedPropertyName = "WindowsFontStyleSelected";

        private System.Windows.FontStyle _WindowsFontStyleSelected;

        /// <summary>
        /// Sets and gets the WindowsFontStyleSelected property.
        /// Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public System.Windows.FontStyle WindowsFontStyleSelected
        {
            get
            {
                return _WindowsFontStyleSelected;
            }

            set
            {
                if (_WindowsFontStyleSelected == value)
                {
                    return;
                }

                _WindowsFontStyleSelected = value;
                RaisePropertyChanged(WindowsFontStyleSelectedPropertyName);
            }
        }
        #endregion

        #region WindowsFontStretcheSelected
        /// <summary>
        /// The <see cref="WindowsFontStretcheSelected" /> property's name.
        /// </summary>
        public const string WindowsFontStretcheSelectedPropertyName = "WindowsFontStretcheSelected";

        private System.Windows.FontStretch _WindowsFontStretcheSelected;

        /// <summary>
        /// Sets and gets the WindowsFontStretcheSelected property.
        /// Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public System.Windows.FontStretch WindowsFontStretcheSelected
        {
            get
            {
                return _WindowsFontStretcheSelected;
            }

            set
            {
                if (_WindowsFontStretcheSelected == value)
                {
                    return;
                }

                _WindowsFontStretcheSelected = value;
                RaisePropertyChanged(WindowsFontStretcheSelectedPropertyName);
            }
        }
        #endregion

        #region WindowsFontWeightSelected
        /// <summary>
        /// The <see cref="WindowsFontWeightSelected" /> property's name.
        /// </summary>
        public const string WindowsFontWeightSelectedPropertyName = "WindowsFontWeightSelected";

        private System.Windows.FontWeight _WindowsFontWeightSelected;

        /// <summary>
        /// Sets and gets the SelectedFontWeight property.
        /// Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public System.Windows.FontWeight WindowsFontWeightSelected
        {
            get
            {
                return _WindowsFontWeightSelected;
            }

            set
            {
                if (_WindowsFontWeightSelected == value)
                {
                    return;
                }

                _WindowsFontWeightSelected = value;
                RaisePropertyChanged(WindowsFontWeightSelectedPropertyName);
            }
        }
        #endregion

        #endregion

        #region Messenging

        #endregion
    }
}
