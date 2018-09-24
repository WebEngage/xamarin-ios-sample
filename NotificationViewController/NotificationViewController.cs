using System;
using Foundation;
using UIKit;
using UserNotifications;
using UserNotificationsUI;
using WebEngageAppExXamariniOS;

namespace NotificationViewController
{
    public partial class NotificationViewController : WEXRichPushNotificationViewController //UIViewController, IUNNotificationContentExtension
    {
        protected NotificationViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Do any required interface initialization here.
        }

        [Export("didReceiveNotification:")]
        public override void DidReceiveNotification(UNNotification notification)
        {
            base.DidReceiveNotification(notification);
        }
    }
}
