// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace NotificationViewController
{
    [Register ("NotificationViewController")]
    partial class NotificationViewController
    {
        [Outlet]
        UIKit.UILabel label { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (label != null) {
                label.Dispose ();
                label = null;
            }
        }
    }
}