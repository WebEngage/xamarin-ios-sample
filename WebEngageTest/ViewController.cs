using System;
using Foundation;
using UIKit;
using WebEngageXamariniOS;

namespace WebEngageTest
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            
            NSUserDefaults plist = NSUserDefaults.StandardUserDefaults;
            string userid = plist.StringForKey("userid");
            Console.WriteLine("user id: " + userid);
            if (userid != null && !userid.Equals("")) {
                UserIdTextField.Text = userid;
                LoginButton.SetTitle("Logout", UIControlState.Normal);
            }

            LoginButton.TouchUpInside += (object sender, EventArgs e) => 
            {
                if (userid == null || userid.Equals("")) 
                {
                    // Login
                    string newUserId = UserIdTextField.Text;
                    if (newUserId != null && !newUserId.Equals("")) {
                        plist.SetString(newUserId, "userid");
                        plist.Synchronize();
                        userid = newUserId;
                        LoginButton.SetTitle("Logout", UIControlState.Normal);

                        WebEngage.SharedInstance().User.Login(newUserId);
                    }
                }
                else
                {
                    // Logout
                    plist.SetString("", "userid");
                    plist.Synchronize();
                    userid = "";
                    UserIdTextField.Text = "";
                    LoginButton.SetTitle("Login", UIControlState.Normal);

                    WebEngage.SharedInstance().User.Logout();
                }
            };

            TrackButton.TouchUpInside += (object sender, EventArgs e) =>
            {
                // Track
                string eventName = EventTextField.Text;
                if (eventName != null && !eventName.Equals("")) {
                    WebEngage.SharedInstance().Analytics.TrackEventWithName(eventName);
                }
            };

            TestButton.TouchUpInside += (object sender, EventArgs e) =>
            {
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
            };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        private void sample()
        {
            /*
             * Tracking Users
             */
            WebEngage.SharedInstance().User.Login("120543");

            WebEngage.SharedInstance().User.Logout();

            // System user attributes
            WebEngage.SharedInstance().User.SetFirstName("John");
            WebEngage.SharedInstance().User.SetLastName("Doe");

            WebEngage.SharedInstance().User.SetEmail("john.doe@gmail.com");

            WebEngage.SharedInstance().User.SetHashedEmail("144e0424883546e07dcd727057fd3b62");

            WebEngage.SharedInstance().User.SetPhone("john.doe@gmail.com");

            WebEngage.SharedInstance().User.SetHashedPhone("e0ec043b3f9e198ec09041687e4d4e8d");

            WebEngage.SharedInstance().User.SetGender("male");

            WebEngage.SharedInstance().User.SetBirthDateString("1994-04-29");

            WebEngage.SharedInstance().User.SetCompany("Alphabet Inc.");

            WebEngage.SharedInstance().User.SetOptInStatusForChannel(WEGEngagementChannel.Push, true);
            WebEngage.SharedInstance().User.SetOptInStatusForChannel(WEGEngagementChannel.InApp, true);
            WebEngage.SharedInstance().User.SetOptInStatusForChannel(WEGEngagementChannel.Sms, true);
            WebEngage.SharedInstance().User.SetOptInStatusForChannel(WEGEngagementChannel.Email, true);

            NSNumber latitude = 72.5;
            NSNumber longitude = 19.3;
            WebEngage.SharedInstance().User.SetUserLocation(latitude, longitude);

            // Custom user attributes
            WebEngage.SharedInstance().User.SetAttribute("Twitter username", "johndoe86@orig");

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

            // Delete single custom user attribute
            WebEngage.SharedInstance().User.DeleteAttribute("age");

            // Delete multiple custom user attributes
            NSObject[] attributesToDelete = new NSObject[] { new NSString("age"), new NSString("email") };
            WebEngage.SharedInstance().User.DeleteAttributes(attributesToDelete);


            /*
             * Tracking Events
             */
            WebEngage.SharedInstance().Analytics.TrackEventWithName("Product Viewed");

            // Tracking event with attributes
            var addedToCartAttributes = new NSDictionary("Product ID", 1337, 
                                                         "Price", 39.80, 
                                                         "Quantity", 1, 
                                                         "Product", "Givenchy Pour Homme Cologne",
                                                         "Category", "Fragrance",
                                                         "Currency", "USD",
                                                         "Is Premium", true
                                                        );
            WebEngage.SharedInstance().Analytics.TrackEventWithName("Added to Cart", addedToCartAttributes);

            // Tracking complex events
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


            /*
             * Tracking screen
             */
            WebEngage.SharedInstance().Analytics.NavigatingToScreenWithName("Purchase Screen");

            // Setting screen data
            var screenData = new NSDictionary("productId", "~hs7674",
                                             "price", 1200);
            WebEngage.SharedInstance().Analytics.UpdateCurrentScreenData(screenData);
        }
    }
}
