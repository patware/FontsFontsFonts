using System.Windows;

namespace FontsFontsFonts.ViewModels
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class SampleViewModel : Base.ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the SampleViewModel class.
        /// </summary>
        public SampleViewModel(Services.IMessenger messaging)
        {
            if (messaging == null) throw new System.ArgumentNullException(nameof(messaging));

            _fontFamily = "Arial";
            _selectedFontSize = 12;
            _selectedFontStretch = System.Windows.FontStretches.Normal;
            _selectedFontStyle = System.Windows.FontStyles.Normal;
            _selectedFontWeight = System.Windows.FontWeights.Normal;

            messaging.Register<Messaging.FontSelected>(onFontSelected);
            messaging.Register<Messaging.FontStylingChanged>(onFontStylingChanged);
        }


        private void onFontSelected(Messaging.FontSelected message)
        {
            this.FontFamily = message.Font.Name;
        }

        private void onFontStylingChanged(Messaging.FontStylingChanged message)
        {
            this.SelectedFontSize = message.FontSize;
            this.SelectedFontStyle = message.FontStyle;
            this.SelectedFontStretch = message.FontStretch;
            this.SelectedFontWeight = message.FontWeight;
        }

        #region FontFamily
        /// <summary>
        /// The <see cref="FontFamily" /> property's name.
        /// </summary>
        public const string FontFamilyPropertyName = "FontFamily";

        private string _fontFamily;

        /// <summary>
        /// Sets and gets the FontFamily property.
        /// Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public string FontFamily
        {
            get
            {
                return _fontFamily;
            }

            set
            {
                if (_fontFamily == value)
                {
                    return;
                }

                _fontFamily = value;
                RaisePropertyChanged(FontFamilyPropertyName);
            }
        }
        #endregion

        #region SelectedFontSize
        /// <summary>
        /// The <see cref="SelectedFontSize" /> property's name.
        /// </summary>
        public const string SelectedFontSizePropertyName = "SelectedFontSize";

        private decimal _selectedFontSize;

        /// <summary>
        /// Sets and gets the SelectedFontSize property.
        /// Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public decimal SelectedFontSize
        {
            get
            {
                return _selectedFontSize;
            }

            set
            {
                if (_selectedFontSize == value)
                {
                    return;
                }

                _selectedFontSize = value;
                RaisePropertyChanged(SelectedFontSizePropertyName);
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

        private FontStretch _selectedFontStretch;

        /// <summary>
        /// Sets and gets the SelectedFontStretch property.
        /// Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public FontStretch SelectedFontStretch
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

        private FontWeight _selectedFontWeight;

        /// <summary>
        /// Sets and gets the SelectedFontWeight property.
        /// Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public FontWeight SelectedFontWeight
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

    }
}