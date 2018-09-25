# WebEngage Xamarin iOS Sample

This is Xamarin.iOS sample application to demonstrate usage of Xamarin binding library of WebEngage iOS SDK.


## Installation

1. Download [WebEngage Xamarin iOS Library](https://s3-us-west-2.amazonaws.com/webengage-sdk/xamarin/ios/base/0.1.0.0/WebEngageXamariniOS.dll).

2. To consume this downloaded .DLL in your Xamarin.iOS app, you must first add a reference to your Xamarin.iOS project by right-clicking on the References node of your project and select Add Reference.


## Initialization


1. Add the following entries in info.plist file of your application.

```
	WEGLicenseCode: YOUR-WEBENGAGE-LICENSE-CODE
	WEGLogLevel: VERBOSE
```


2. Initialize WebEngage SDK from FinishedLaunching callback of your AppDelegate class as shown below.

```csharp
...
using WebEngageXamariniOS;

namespace YourNamespace
{
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
    	...
    	public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            ...
            WebEngage.SharedInstance().Application(application, launchOptions);
            return true;
        }
        ...
    }
}
```


## Tracking Users

1. Login and logout users as shown in below example.

```csharp
...
using WebEngageXamariniOS;

namespace YourNamespace
{
    ...
    public partial class YourViewController : UIViewController
    {
    	...
    	// Login
    	WebEngage.SharedInstance().User.Login("user-id");

        // Logout
        WebEngage.SharedInstance().User.Logout();
    	...
    }
    ...
}
```

2. Set system user attributes as shown below.

```csharp
using WebEngageXamariniOS;

namespace YourNamespace
{
    ...
    public partial class YourViewController : UIViewController
    {
        ...
        // First name
        WebEngage.SharedInstance().User.SetFirstName("John");

        // Last name
        WebEngage.SharedInstance().User.SetLastName("Doe");

        // Email
        WebEngage.SharedInstance().User.SetEmail("john.doe@gmail.com");

        // Hashed email
        WebEngage.SharedInstance().User.SetHashedEmail("144e0424883546e07dcd727057fd3b62");

        // Phone    
        WebEngage.SharedInstance().User.SetPhone("john.doe@gmail.com");

        // Hashed phone    
        WebEngage.SharedInstance().User.SetHashedPhone("e0ec043b3f9e198ec09041687e4d4e8d");

        // Gender    
        WebEngage.SharedInstance().User.SetGender("male");

        // Birthdate
        WebEngage.SharedInstance().User.SetBirthDateString("1994-04-29");

        // Company    
        WebEngage.SharedInstance().User.SetCompany("Alphabet Inc.");

        // Opt-in    
        WebEngage.SharedInstance().User.SetOptInStatusForChannel(WEGEngagementChannel.Push, true);
        WebEngage.SharedInstance().User.SetOptInStatusForChannel(WEGEngagementChannel.InApp, true);
        WebEngage.SharedInstance().User.SetOptInStatusForChannel(WEGEngagementChannel.Sms, true);
        WebEngage.SharedInstance().User.SetOptInStatusForChannel(WEGEngagementChannel.Email, true);

        // Location    
        NSNumber latitude = 72.5;
        NSNumber longitude = 120.5;
        WebEngage.SharedInstance().User.SetUserLocation(latitude, longitude);
        ...
    }
    ...
}
```

3. Set custom user attributes as shown below.

```csharp
...
using WebEngageXamariniOS;

namespace YourNamespace
{
    ...
    public partial class YourViewController : UIViewController
    {
        ...
        // String custom user attribute
        WebEngage.SharedInstance().User.SetAttribute("Twitter username", "johndoe86@orig");

        // Number custom user attribute
        WebEngage.SharedInstance().User.SetAttribute("age", 24);

        // Date custom user attribute
        NSDateComponents dateComponents = new NSDateComponents
        {
            Day = 29,
            Month = 4,
            Year = 2001
        };
        NSCalendar calendar = NSCalendar.CurrentCalendar;
        NSDate date = calendar.DateFromComponents(dateComponents);
        WebEngage.SharedInstance().User.SetAttribute("Last order date", date);

        // Complex custom user attributes
        NSDictionary<NSString, NSObject> dict = new NSDictionary<NSString, NSObject>();
        dict.SetValueForKey(new NSString("Z-62"), new NSString("Flat"));
        dict.SetValueForKey(new NSString("Pennant Court"), new NSString("Building"));
        dict.SetValueForKey(new NSString("Penn Road"), new NSString("Locality"));
        dict.SetValueForKey(new NSString("West Midlands"), new NSString("State"));
        dict.SetValueForKey(new NSString("WV30DT"), new NSString("PIN"));
        WebEngage.SharedInstance().User.SetAttribute("Address", dict);
        ...
    }
    ...
}
```

**Note:** WebEngage Xamarin.iOS SDK only supports the following data-types: string, NSString, NSNumber, Boolean, NSDate, NSMutableArray and NSDictionary.

4. Delete custom user attributes as shown below.

```csharp
using WebEngageXamariniOS;

    ...
    WebEngage.SharedInstance().User.DeleteAttribute("age");
```


## Tracking Events

Track custom events as shown below.

```csharp
using WebEngageXamariniOS;

    ...
    // Simple event
    WebEngage.SharedInstance().Analytics.TrackEventWithName("Product Viewed");

    // Event with attributes
    var addedToCartAttributes = new NSDictionary("Product ID", 1337, 
                                                 "Price", 39.80, 
                                                 "Quantity", 1, 
                                                 "Product", "Givenchy Pour Homme Cologne",
                                                 "Category", "Fragrance",
                                                 "Currency", "USD",
                                                 "Is Premium", true
                                                );
    WebEngage.SharedInstance().Analytics.TrackEventWithName("Added to Cart", addedToCartAttributes);

    // Complex event
    var detailsProduct1 = new NSDictionary("Size", "L");

    var product1 = new NSDictionary("SKU Code", "UHUH799",
                                    "Product Name", "Armani Jeans",
                                    "Price", 300.49,
                                    "Details", detailsProduct1
                                   );
    var detailsProduct2 = new NSDictionary("Size", "L");

    var product2 = new NSDictionary("SKU Code", "UHUH799",
                                    "Product Name", "Armani Jeans",
                                    "Price", 300.49,
                                    "Details", detailsProduct1
                                   );
    var deliveryAddress = new NSDictionary("City", "San Francisco", 
                                       "ZIP", "94121"
                                      );
    var products = new NSMutableArray<NSDictionary>(product1, product2);

    var orderPlacedAttributes = new NSDictionary("Products", products,
                                                 "Delivery Address", deliveryAddress,
                                                 "Coupons Applied", new NSMutableArray<NSString>(new NSString("BOGO17"), new NSString("BGH025"))
                                                );
    WebEngage.SharedInstance().Analytics.TrackEventWithName("Order Placed", orderPlacedAttributes);
```

**Note:** WebEngage Xamarin.iOS SDK only supports the following data-types: string, NSString, NSNumber, Boolean, NSDate, NSMutableArray and NSDictionary.


## Push Notifications

1. In order to receive push notifications from WebEngage, Log in to your WebEngage dashboard and navigate to Integrations > Channels > Push, under iOS section upload your push certificate and enter your push password.

2. Now in your Xamarin.iOS app's Entitlements.plist check Enable Push Notifications.

3. Add remote-notifications as type string under App Background Modes in your app's info.plist.

4. Set autoregister to true while initialising WebEngage SDK as shown below.

```csharp
...
using WebEngageXamariniOS;

namespace YourNamespace
{
    ...
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        ...
        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            ...
            WebEngage.SharedInstance().Application(application, launchOptions, true);
            return true;
        }
        ...
    }
    ...
}
```

For detailed instructions see our [documentation for integrating Push Notifications in iOS](https://docs.webengage.com/docs/ios-push-messaging).


### Rich Push Notifications

1. For Banner Push Notifications

    1. Add a new project named `NotificationService` with Notification Service Extension as target in your main app.

    2. Download [WebEngage Banner Push Notification Extension SDK](https://s3-us-west-2.amazonaws.com/webengage-sdk/xamarin/ios/banner-push/0.1.0.0/WebEngageBannerPushXamariniOS.dll)

    3. Add WebEngageBannerPushXamariniOS.dll to References in your NotificationService project.

2. For Rating and Carousel Push Notifications

    1. Add a new project named `NotificationViewController` with Notification Content Extension as target in your main app.

    2. Download [WebEngage Notification App Extension SDK](https://s3-us-west-2.amazonaws.com/webengage-sdk/xamarin/ios/app-extension/0.1.0.0/WebEngageAppExXamariniOS.dll)

    3. Add WebEngageAppExXamariniOS.dll to References in your NotificationViewController project.

    4. Open the `Info.plist` file for NotificationViewController. Expand NSExetnsion > NSExtensionAttributes. Look for UNNotificationExtensionCategory under NSExtensionAttributes. Add it if it is not present and set the type as Array. In its items, add the following values:

        a. `WEG_CAROUSEL_V1` for Carousel Push Notifications

        b. `WEG_RATING_V1` for Rating Push Notifications

3. Set App Groups as group.[app-bundle-id].WEGNotificationGroup in `Entitlements.plist` of all three projects (your Xamarin.iOS app, NotificationService and NotificationViewController).

For detailed explanation see our [documentation for integrating Rich Push Notification in iOS](https://docs.webengage.com/docs/ios-push-messaging#section-5-rich-push-notifications-optional).


### Push Notification Callbacks

In order to receive push notification callbacks, implement IWEGAppDelegate in your AppDelegate class as shown below.

```csharp
...
using WebEngageXamariniOS;

namespace YourNamespace
{
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate, IWEGAppDelegate
    {
        ...
        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            ...
            WebEngage.SharedInstance().Application(application, launchOptions, true);
            return true;
        }

        // Push notification callbacks
        [Export("application:didReceiveRemoteNotification:")]
        public override void ReceivedRemoteNotification(UIApplication application, NSDictionary userInfo)
        {
            ...
        }

        [Export("application:didReceiveRemoteNotification:fetchCompletionHandler:")]
        public override void DidReceiveRemoteNotification(UIApplication application, NSDictionary userInfo, Action<UIBackgroundFetchResult> completionHandler)
        {
            ...
        }

        [Export("WEGHandleDeeplink:userData:")]
        public void WEGHandleDeeplink(string deeplink, NSDictionary data)
        {
            ...
        }

        // Anonymous ID callback
        [Export("didReceiveAnonymousID:forReason:")]
        public void DidReceiveAnonymousID(string anonymousID, WEGReason reason)
        {
            ...
        }

        ...
    }
}
```


## In-app Notifications

No additional steps are required to receive in-app notifications.

### Tracking Screens

Screens can be tracked to set rules for showing in-app notifications. For example, you can create a rule in WebEngage dashboard to show in-app notification on a particular screen.

```csharp
using WebEngageXamariniOS;

    ...
    // Simple screen
    WebEngage.SharedInstance().Analytics.NavigatingToScreenWithName("Purchase Screen");

    // Setting screen data
    var screenData = new NSDictionary("productId", "~hs7674",
                                     "price", 1200);
    WebEngage.SharedInstance().Analytics.UpdateCurrentScreenData(screenData);
```

### In-app Notification Callbacks

1. Create WebEngage in-app notification callback delegate class as shown below.

```csharp
using System;
using Foundation;
using WebEngageXamariniOS;

namespace YourNamespace
{
    public class InAppNotificationDelegate : WEGInAppNotificationProtocol
    {
        public override NSMutableDictionary NotificationPrepared(NSMutableDictionary inAppNotificationData, bool stopRendering)
        {
            ...
            return inAppNotificationData;
        }

        public override void NotificationShown(NSMutableDictionary inAppNotificationData)
        {
            ...
        }

        public override void Notification(NSMutableDictionary inAppNotificationData, string actionId)
        {
            ...
        }

        public override void NotificationDismissed(NSMutableDictionary inAppNotificationData)
        {
            ...
        }
    }
}
```

2. Register the in-app notification callback delegate in your AppDelegate while initializing WebEngage SDK as shown below.

```csharp
...
using WebEngageXamariniOS;

namespace YourNamespace
{
    ...
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        ...

        private static InAppNotificationDelegate inAppNotificationDelegate;

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            ...

            inAppNotificationDelegate = new InAppNotificationDelegate();

            WebEngage.SharedInstance().Application(application, launchOptions, inAppNotificationDelegate, true);

            return true;
        }
        ...
    }
    ...
}
```


## Troubleshooting

### Banner push notification Images not shown in iOS 11 Debug mode

Do not panic, this is a bug in iOS itself. However, rich push notifications would work fine in iOS 11 Release mode.
