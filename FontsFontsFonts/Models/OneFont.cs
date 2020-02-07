using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FontsFontsFonts.Models
{
    public class OneFont : INotifyPropertyChanged
    {
        public OneFont(System.Windows.Media.FontFamily family)
        {
            if (family == null)
                throw new ArgumentNullException(nameof(family));

            this.Name = family.ToString();
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }


        private string _overrideDisplayWith;
        public string OverrideDisplayWith
        {
            get { return _overrideDisplayWith; }
            set
            {
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

        private void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
