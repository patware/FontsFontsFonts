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
					this.FontSize = item.LastFontSize;
				});


			addFontStyles();

			addFontStretches();

			addFontWeights();

			this.PropertyChanged += MainViewModel_PropertyChanged;

			sendFontName();
			sendFontStyle();

		}

		void MainViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			switch (e.PropertyName)
			{
				case SelectedFontPropertyName:
					sendFontName();
					break;
				case FontSizePropertyName:
				case SelectedFontStretchPropertyName:
				case SelectedFontStylePropertyName:
				case SelectedFontWeightPropertyName:
					sendFontStyle();
					break;
			}
		}

		private void sendFontStyle()
		{
			var fsc = new Messaging.FontStylingChanged()
			{
				FontSize = this.FontSize,
				FontStretch = this.SelectedFontStretch,
				FontStyle = this.SelectedFontStyle,
				FontWeight = this.SelectedFontWeight
			};
			GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<Messaging.FontStylingChanged>(fsc);
		}

		private void sendFontName()
		{
			GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<Messaging.FontSelected>(new Messaging.FontSelected(_selectedFont));
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

		#region SelectedFont
		/// <summary>
		/// The <see cref="SelectedFont" /> property's name.
		/// </summary>
		public const string SelectedFontPropertyName = "SelectedFont";

		private OneFont _selectedFont;

		/// <summary>
		/// Sets and gets the SelectedFont property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public OneFont SelectedFont
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
		
		#endregion

		#region Messenging
		
		#endregion
	}
}