using System;
using Foundation;
using WebEngageXamariniOS;

namespace WebEngageTest
{
    public class InAppNotificationDelegate : WEGInAppNotificationProtocol
    {
        public override NSMutableDictionary NotificationPrepared(NSMutableDictionary inAppNotificationData, bool stopRendering)
        {
            Console.WriteLine("in-app notification prepared: " + stopRendering);
            return inAppNotificationData;
        }

        public override void NotificationShown(NSMutableDictionary inAppNotificationData)
        {
            Console.WriteLine("in-app notification shown");
        }

        public override void Notification(NSMutableDictionary inAppNotificationData, string actionId)
        {
            Console.WriteLine("in-app notification clicked");
        }

        public override void NotificationDismissed(NSMutableDictionary inAppNotificationData)
        {
            Console.WriteLine("in-app notification dismissed");
        }
    }
}
