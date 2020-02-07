using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace FontsFontsFonts.Services
{
    public static class Bootstrapper
    {
        private static IContainer _container;

        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            if (Utility.IsInDesignMode)
            {
                builder.RegisterType<Design.SettingsServiceDesign>().As<ISettingsService>();
            }
            else
            {
                builder.RegisterType<SettingsService>().As<ISettingsService>();
            }

            builder.RegisterType<Services.Messenger>().As<Services.IMessenger>().SingleInstance();

            builder.RegisterType<ViewModels.FontViewModel>();
            builder.RegisterType<ViewModels.MainViewModel>();
            builder.RegisterType<ViewModels.SampleViewModel>();

            _container = builder.Build();
        }

        public static T Resolve<T>() {
            return _container.Resolve<T>();
        }

    }
}
