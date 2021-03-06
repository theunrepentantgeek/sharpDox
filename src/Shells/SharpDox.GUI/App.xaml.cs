﻿using System.Diagnostics;
using System.Windows;
using System.Windows.Threading;
using Autofac;
using log4net.Config;
using SharpDox.Core;

namespace SharpDox.GUI
{
    public partial class App
    {
        public App()
        {
            XmlConfigurator.Configure();
            Dispatcher.UnhandledException += OnDispatcherUnhandledException;
        }

        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            Trace.TraceError(e.Exception.ToString());
            MessageBox.Show("Unhandled exception! Please check log!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            e.Handled = true;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            
            var mainContainerConfig = new MainContainerConfig();
            mainContainerConfig.RegisterAsSelf<Shell>();
            mainContainerConfig.RegisterStrings<SDGuiStrings>();
            var mainContainer = mainContainerConfig.BuildContainer();

            mainContainer.Resolve<Shell>().Show();
        }
    }
}
