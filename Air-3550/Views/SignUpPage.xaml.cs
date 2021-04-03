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
using Air_3550.Services;

namespace Air_3550.Views
{
    /// <summary>
    /// 1st part of SignUp Page.
    /// </summary>
    public sealed partial class SignUpPage : Page
    {
        public SignUpPage()
        {
            this.InitializeComponent();
            if (App.signUpInfo.ContainsKey("firstName"))
            {
                FirstName.Text = App.signUpInfo["firstName"];
            }
            if (App.signUpInfo.ContainsKey("lastName"))
            {
                LastName.Text = App.signUpInfo["lastName"];
            }
            if (App.signUpInfo.ContainsKey("email"))
            {
                Email.Text = App.signUpInfo["email"];
                ConfirmEmail.Text = App.signUpInfo["email"];
            }
            App.signUpInfo.Clear();
        }

        private void ContinueSignUp(object sender, RoutedEventArgs e)
        {
            App.signUpInfo.Add("firstName", FirstName.Text);
            App.signUpInfo.Add("lastName", LastName.Text);
            App.signUpInfo.Add("email", Email.Text);
            App.signUpInfo.Add("password", Utils.GenerateSHA512(Password.Password));
            Frame.Navigate(typeof(SignUpPage2));
        }

        private void GoToSignIn(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SignInPage));
        }
    }
}
