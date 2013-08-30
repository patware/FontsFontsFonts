using System.Globalization;
using System.Windows.Media;
using GalaSoft.MvvmLight;

namespace FontsFontsFonts.Model
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class OneFont : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the OneFont class.
        /// </summary>
        public OneFont()
        {
        }
        public OneFont(FontFamily family)
        {
            this.Name = family.ToString();
        }

        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }

        /* 
         * Pattern Breaker
         * This not really a ViewModelBase Property, it's there only for the Display and the "override".
         */
        private string _overrideDisplayWith;

        public string OverrideDisplayWith
        {
            get { return _overrideDisplayWith; }
            set 
            { 
                RaisePropertyChanging(DisplayPropertyName);
                _overrideDisplayWith = value;
                RaisePropertyChanged(DisplayPropertyName);

            }
        }

        #region Display
        /// <summary>
        /// The <see cref="Display" /> property's name.
        /// </summary>
        public const string DisplayPropertyName = "Display";
        
        /// <summary>
        /// Sets and gets the Display property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Display
        {
            get
            {
                return string.IsNullOrEmpty(_overrideDisplayWith) ? this.Name : _overrideDisplayWith;
            }

        }
        #endregion
	
    }
}