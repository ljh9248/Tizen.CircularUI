﻿using System;
using Xamarin.Forms;
using Tizen.Wearable.CircularUI.Forms;
using Xamarin.Forms.Xaml;

namespace UIComponents.Samples
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupList : CirclePage
    {
        /// <summary>
        /// Constructor of PopupList class
        /// </summary>
        public PopupList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Called when item is tapped
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="args">Argument of ItemTappedEventArgs</param>
        public void OnItemTapped(object sender, ItemTappedEventArgs args)
        {
            if (args.Item == null) return;

            var desc = args.Item as Sample;
            Console.WriteLine($"OnItemTapped desc.Class:{desc.Class}");
            if (desc != null && desc.Class != null)
            {
                Type pageType = desc.Class;

                string title = desc.Title;
                // 2 buttons case
                if (title.EndsWith("2button"))
                {
                    Console.WriteLine($"title end 2button ");
                    var twoButtonPopup = Activator.CreateInstance(pageType) as TwoButtonPopup;
                    if (twoButtonPopup != null) twoButtonPopup.Show();
                }
                // Toast case - set text
                else if (title.Equals("Toast"))
                {
                    Console.WriteLine($"display Toast");
                    Toast.DisplayText("Saving Contacts to sim on sams, 1 2 3 4 5 6 7 8 9 10.", 2000);
                }
                // Graphic Toast case - set text and image
                else if (title.Equals("Graphic Toast"))
                {
                    Console.WriteLine($"display Graphic Toast");
                    Toast.DisplayIconText("Check my device and phone number", new FileImageSource { File = "b_option_list_icon_action.png" }, 2000);
                }
                // Other cases
                else
                {
                    var popup = Activator.CreateInstance(pageType) as InformationPopup;
                    if (popup != null) popup.Show();
                }
            }
        }
    }
}
