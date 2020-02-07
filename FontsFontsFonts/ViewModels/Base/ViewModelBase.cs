using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FontsFontsFonts.ViewModels.Base
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

#pragma warning disable CA1030 // Use events where appropriate
        protected virtual void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
#pragma warning restore CA1030 // Use events where appropriate
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
