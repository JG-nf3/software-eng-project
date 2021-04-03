using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using static Air_3550.Constants.USState;
using System.Diagnostics;
using Air_3550.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Air_3550.Views
{
    /// <summary>
    /// 2nd part of SignUp Page.
    /// </summary>
    public sealed partial class SignUpPage2 : Page
    {
        public SignUpPage2()
        {
            this.InitializeComponent();
            WelcomeTxt.Text = App.signUpInfo["firstName"] + ", Welcome to Air 3550";
            for (int i=0; i < StateMap.Count; i++)
            {
                MenuFlyoutItem item = new MenuFlyoutItem();
                item.Text = StateMap.Keys.ElementAt(i);
                item.Click += OnStateSelect;
                StatesFlyout.Items.Insert(i, item);
            }
        }

        private void OnStateSelect(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem state = sender as MenuFlyoutItem;
            StateButton.Content = state.Text;
        }

        private void GetBack(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SignUpPage));
        }

        private void FinishSignUp(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(App.signUpInfo["firstName"]);
            Debug.WriteLine(App.signUpInfo["lastName"]);
            Debug.WriteLine(App.signUpInfo["password"]);
            Debug.WriteLine(Phone.Text);
            Debug.WriteLine(BirthDate.Date);
            Debug.WriteLine(Add1.Text);
            Debug.WriteLine(Add2.Text);
            Debug.WriteLine(City.Text);
            Debug.WriteLine(StateButton.Content);
            Debug.WriteLine(Zip.Text);
            Debug.WriteLine("CUSTOMERS");
            App.signUpInfo.Clear();
            Frame.Navigate(typeof(SignInPage));
        }
    }
}
