// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace WebEngageTest
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField EventTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton LoginButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton TestButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton TrackButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField UserIdTextField { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (EventTextField != null) {
                EventTextField.Dispose ();
                EventTextField = null;
            }

            if (LoginButton != null) {
                LoginButton.Dispose ();
                LoginButton = null;
            }

            if (TestButton != null) {
                TestButton.Dispose ();
                TestButton = null;
            }

            if (TrackButton != null) {
                TrackButton.Dispose ();
                TrackButton = null;
            }

            if (UserIdTextField != null) {
                UserIdTextField.Dispose ();
                UserIdTextField = null;
            }
        }
    }
}