using Windows.UI.Xaml.Controls;
using Air_3550.Data;
using System;
using Air_3550.Services;

namespace Air_3550.Views
{
    /// <summary>
    /// Sign In Page
    /// </summary>
    public sealed partial class SignInPage : Page
    {
        public SignInPage()
        {
            this.InitializeComponent();
            TextBlock forgotCredential = new TextBlock { Text = "Forgot Credential ?" };
            ForgotCredLink.Content = forgotCredential;

            TextBlock signUp = new TextBlock { Text = "Create One" };
            SignUpLink.Content = signUp;
        }

        private void OnForgotCredential(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }

        private void OnSignUp(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SignUpPage));
        }

        private void OnSignIn(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            UserService.SignIn(Int32.Parse(UserId.Text), UserPassword.Password);
            Frame.Navigate(typeof(HomePage));
        }
    }
}