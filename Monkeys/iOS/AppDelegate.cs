using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace Monkeys.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            Syncfusion.XForms.iOS.Shimmer.SfShimmerRenderer.Init();
            Syncfusion.XForms.iOS.Core.SfAvatarViewRenderer.Init();
            LoadApplication(new App());
            ImageCircle.Forms.Plugin.iOS.ImageCircleRenderer.Init();

            return base.FinishedLaunching(app, options);
        }
    }
}

