﻿using System.Windows;
using GalaSoft.MvvmLight;

namespace FontsFontsFonts.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class SampleViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the SampleViewModel class.
        /// </summary>
        public SampleViewModel()
        {
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<Messaging.FontSelected>(this,onFontSelected);
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<Messaging.FontStylingChanged>(this, onFontStylingChanged);
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

                RaisePropertyChanging(FontFamilyPropertyName);
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

                RaisePropertyChanging(SelectedFontSizePropertyName);
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

                RaisePropertyChanging(SelectedFontStylePropertyName);
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

                RaisePropertyChanging(SelectedFontStretchPropertyName);
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

                RaisePropertyChanging(SelectedFontWeightPropertyName);
                _selectedFontWeight = value;
                RaisePropertyChanged(SelectedFontWeightPropertyName);
            }
        }
        #endregion
	
    }
}