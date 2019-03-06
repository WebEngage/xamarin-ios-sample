using System;
using Foundation;
using UIKit;

using WebEngageXamariniOS;

namespace WebEngageTest
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate, IWEGAppDelegate
    {
        private static InAppNotificationDelegate inAppNotificationDelegate;

        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            inAppNotificationDelegate = new InAppNotificationDelegate();

            bool autoRegister = true;
            WebEngage.SharedInstance().Application(application, launchOptions, inAppNotificationDelegate, autoRegister);

            //WebEngage.SharedInstance().Application(application, launchOptions);

            //WebEngage.SharedInstance().Application(application, launchOptions, true);

            //WebEngage.SharedInstance().Application(application, launchOptions, inAppNotificationDelegate);

            return true;
        }

        public override void OnResignActivation(UIApplication application)
        {
            // Invoked when the application is about to move from active to inactive state.
            // This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
            // or when the user quits the application and it begins the transition to the background state.
            // Games should use this method to pause the game.
        }

        public override void DidEnterBackground(UIApplication application)
        {
            // Use this method to release shared resources, save user data, invalidate timers and store the application state.
            // If your application supports background exection this method is called instead of WillTerminate when the user quits.
        }

        public override void WillEnterForeground(UIApplication application)
        {
            // Called as part of the transiton from background to active state.
            // Here you can undo many of the changes made on entering the background.
        }

        public override void OnActivated(UIApplication application)
        {
            // Restart any tasks that were paused (or not yet started) while the application was inactive. 
            // If the application was previously in the background, optionally refresh the user interface.
        }

        public override void WillTerminate(UIApplication application)
        {
            // Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
        }

        // Push notification callbacks
        [Export("application:didReceiveRemoteNotification:")]
        public override void ReceivedRemoteNotification(UIApplication application, NSDictionary userInfo)
        {
            Console.WriteLine("push notification received: " + userInfo);
        }

        [Export("application:didReceiveRemoteNotification:fetchCompletionHandler:")]
        public override void DidReceiveRemoteNotification(UIApplication application, NSDictionary userInfo, Action<UIBackgroundFetchResult> completionHandler)
        {
            Console.WriteLine("push notification did receive: " + userInfo);
        }

        [Export("WEGHandleDeeplink:userData:")]
        public void WEGHandleDeeplink(string deeplink, NSDictionary data)
        {
            Console.WriteLine("push notification clicked: " + deeplink);
        }

        // Anonymous ID callback
        [Export("didReceiveAnonymousID:forReason:")]
        public void DidReceiveAnonymousID(string anonymousID, WEGReason reason)
        {
            Console.WriteLine("Anonymous ID: " + anonymousID + ", reason: " + reason);
        }
    }
}
