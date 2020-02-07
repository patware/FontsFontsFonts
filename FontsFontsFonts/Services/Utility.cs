using System;
using System.Collections.Generic;
using System.Text;

namespace FontsFontsFonts.Services
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1052:Static holder types should be Static or NotInheritable", Justification = "<Pending>")]
    public class Utility
    {
        public Utility()
        {
            System.Diagnostics.Debug.WriteLine("Utility ctor");
        }

        private static bool? _isInDesignMode;

        public static bool IsInDesignMode
        {
            get
            {
                if (!_isInDesignMode.HasValue)
                {
                    var p = System.ComponentModel.DesignerProperties.IsInDesignModeProperty;

                    _isInDesignMode = (bool)System
                        .ComponentModel
                        .DependencyPropertyDescriptor
                        .FromProperty(p, typeof(System.Windows.FrameworkElement))
                        .Metadata
                        .DefaultValue;

                }

                return _isInDesignMode.Value;
            }
        }
    }
}
