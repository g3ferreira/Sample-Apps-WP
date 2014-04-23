using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ListBoxWithElipse.Resources;
using ListBoxWithElipse.Models;

namespace ListBoxWithElipse
{
    public partial class MainPage : PhoneApplicationPage
    {
        String[] Colors = { "#FFC72626","#FF2B44B6",
                              "#FF9DBD0C","#FF24BD0C"};
        List<Color> listColors = new List<Color>();
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            for(int i =0 ; i<Colors.Length; i++)
            {
                Color cor = new Color();
                cor.color = Colors[i];
            
            listColors.Add(cor);
            }
            ListElipse.ItemsSource = listColors.ToList();


            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}