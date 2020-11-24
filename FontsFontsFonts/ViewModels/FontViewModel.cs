using FontsFontsFonts.Messaging;
using System;
using System.Collections.Generic;

namespace FontsFontsFonts.ViewModels
{
    public class FontViewModel : Base.ViewModelBase
    {

        public FontViewModel(Services.IMessenger messaging)
        {
            if (messaging == null) throw new System.ArgumentNullException(nameof(messaging));

            messaging.Register<Messaging.FontSelected>(OnFontSelected);

            FamilyMaps = new System.Collections.ObjectModel.ObservableCollection<System.Windows.Media.FontFamilyMap>();
            FamilyNames = new System.Collections.ObjectModel.ObservableCollection<KeyValuePair<string, string>>();
            FamilyTypeFaces = new System.Collections.ObjectModel.ObservableCollection<System.Windows.Media.FamilyTypeface>();
        }

        private void OnFontSelected(FontSelected selectedFont)
        {
            var of = selectedFont.Font;
            var ff = new System.Windows.Media.FontFamily(of.Name);
            LoadFont(ff);
        }

        private void LoadFont(System.Windows.Media.FontFamily fontFamily)
        {

            FontName = fontFamily.ToString();
            Baseline = fontFamily.Baseline;
            BaseUri = (fontFamily.BaseUri == null) ? "N/A" : fontFamily.BaseUri.ToString();
            FamilyMaps.Clear();
            foreach (var fm in fontFamily.FamilyMaps)
                FamilyMaps.Add(fm);

            FamilyNames.Clear();
            foreach (var fn in fontFamily.FamilyNames)
                FamilyNames.Add(new KeyValuePair<string, string>(fn.Key.ToString(), fn.Value));

            FamilyTypeFaces.Clear();
            foreach (var ftf in fontFamily.FamilyTypefaces)
                FamilyTypeFaces.Add(ftf);

            LineSpacing = fontFamily.LineSpacing;
            Source = fontFamily.Source;

        }


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
#pragma warning disable CA1056 // Uri properties should not be strings
        public string BaseUri
#pragma warning restore CA1056 // Uri properties should not be strings
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

        /// <summary>
        /// Sets and gets the FamilyMaps property.
        /// Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public System.Collections.ObjectModel.ObservableCollection<System.Windows.Media.FontFamilyMap> FamilyMaps
        {
            get;
        }
        #endregion

        #region FamilyNames
        /// <summary>
        /// The <see cref="FamilyNames" /> property's name.
        /// </summary>
        public const string FamilyNamesPropertyName = "FamilyNames";

        /// <summary>
        /// Sets and gets the FamilyNames property.
        /// Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public System.Collections.ObjectModel.ObservableCollection<KeyValuePair<string, string>> FamilyNames
        {
            get;
        }
        #endregion

        #region FamilyTypeFaces
        /// <summary>
        /// The <see cref="FamilyTypeFaces" /> property's name.
        /// </summary>
        public const string FamilyTypeFacesPropertyName = "FamilyTypeFaces";

        /// <summary>
        /// Sets and gets the FamilyTypeFaces property.
        /// Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public System.Collections.ObjectModel.ObservableCollection<System.Windows.Media.FamilyTypeface> FamilyTypeFaces
        {
            get;
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

                _source = value;
                RaisePropertyChanged(SourcePropertyName);
            }
        }
        #endregion

        #endregion
    }
}
