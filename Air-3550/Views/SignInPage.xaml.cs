using Air_3550.Services;
using Air_3550.Utils;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

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

        /// <summary>
        /// Reset password.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnForgotCredential(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// Navigate to SignUp page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSignUp(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SignUpPage));
        }

        /// <summary>
        /// Sign In User if the credential is valid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSignIn(object sender, RoutedEventArgs e)
        {
            Dictionary<string, string> inputDict = new Dictionary<string, string>()
            {
                {"userId", UserId.Text},
                {"password", UserPassword.Password}
            };

            if (
                Validation.ValidateInputs(inputDict) &&
                UserService.SignIn(Int32.Parse(UserId.Text), SHA512Generate.GenerateSHA512(UserPassword.Password))
                )
            {
                Frame.Navigate(typeof(HomePage));
                return;
            }
            SignInErrorText.Visibility = Visibility.Visible;
        }
    }
}