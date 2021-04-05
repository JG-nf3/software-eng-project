using Windows.UI.Xaml.Controls;
using Air_3550.Data;
using System;
using Air_3550.Services;
using Air_3550.Models;
using Windows.UI.Xaml;
using Air_3550.Utils;

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
        private void OnSignUp(object sender,RoutedEventArgs e)
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
            if (!IsValidSignInInfo())
            {
                SignInErrorText.Visibility = Visibility.Visible;
                return;
            }
            UserService.SignIn(Int32.Parse(UserId.Text),  UserPassword.Password);
            Frame.Navigate(typeof(HomePage));
        }

        /// <summary>
        /// Check if User info is Valid.
        /// </summary>
        /// <returns>true if valid, false otherwise.</returns>
        private bool IsValidSignInInfo()
        {
            if (
                UserId.Text.Length == 6 && UserPassword.Password.Length > 0 &&
                Int32.TryParse(UserId.Text, out int userId)
                )
            {
                User user = UserService.FindUserById(userId);
                if (user != null && user.Password == SHA512Generate.GenerateSHA512(UserPassword.Password)) {
                    return true;
                }
            }
            return false;
        }
    }
}