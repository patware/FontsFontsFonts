using System;
using System.Collections.Generic;
using System.Text;

namespace FontsFontsFonts.Services
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            Services.Bootstrapper.RegisterDependencies();
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public ViewModels.MainViewModel Main => Bootstrapper.Resolve<ViewModels.MainViewModel>();
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public ViewModels.FontViewModel Font => Bootstrapper.Resolve<ViewModels.FontViewModel>();

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public ViewModels.SampleViewModel Sample => Bootstrapper.Resolve<ViewModels.SampleViewModel>();
    }
}
