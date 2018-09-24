using System;
using Foundation;
using UIKit;
using UserNotifications;
using WebEngageBannerPushXamariniOS;

namespace NotificationService
{
    [Register("NotificationService")]
    public class NotificationService : WEXPushNotificationService
    {
        /*Action<UNNotificationContent> ContentHandler { get; set; }
        UNMutableNotificationContent BestAttemptContent { get; set; }

        protected NotificationService(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void DidReceiveNotificationRequest(UNNotificationRequest request, Action<UNNotificationContent> contentHandler)
        {
            Console.WriteLine("DidReceiveNotificationRequest() called");
            //BestAttemptContent = (UNMutableNotificationContent)request.Content.MutableCopy();
            //base.DidReceiveNotificationRequest(request, contentHandler);
            ContentHandler = contentHandler;
            BestAttemptContent = (UNMutableNotificationContent)request.Content.MutableCopy();

            // Modify the notification content here...
            BestAttemptContent.Title = $"{BestAttemptContent.Title}[modified]";

            ContentHandler(BestAttemptContent);
        }

        public override void TimeWillExpire()
        {
            // Called just before the extension will be terminated by the system.
            // Use this as an opportunity to deliver your "best attempt" at modified content, otherwise the original push payload will be used.
            Console.WriteLine("TimeWillExpire() called");
            ContentHandler(BestAttemptContent);
        }*/
    }
}
