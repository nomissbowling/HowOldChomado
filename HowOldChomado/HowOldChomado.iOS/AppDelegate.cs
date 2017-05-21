﻿using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;
using Autofac;
using Prism.Autofac.Forms;
using HowOldChomado.iOS.Services;
using HowOldChomado.Services;
using ImageCircle.Forms.Plugin.iOS;

namespace HowOldChomado.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            ImageCircleRenderer.Init();
            LoadApplication(new App(new iOSInitializer()));

            return base.FinishedLaunching(app, options);
        }
    }

    public class iOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainer container)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<FileService>()
                .As<IFileService>();
            builder.Update(container);
        }
    }

}
