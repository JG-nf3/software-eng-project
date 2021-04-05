using Air_3550.Utils;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Popups;
using System;

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
        
        /// <summary>
        /// Adds info in the page to SignUpInfo and Navigates to next page (Still signUp).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContinueSignUp(object sender, RoutedEventArgs e)
        {

            if (!IsInputValid())
            {
                InputWarningText.Visibility = Visibility.Visible;
                return;
            }
            App.signUpInfo.Add("firstName", FirstName.Text);
            App.signUpInfo.Add("lastName", LastName.Text);
            App.signUpInfo.Add("email", Email.Text);
            App.signUpInfo.Add("password", SHA512Generate.GenerateSHA512(Password.Password));
            Frame.Navigate(typeof(SignUpPage2));

        }

        /// <summary>
        /// Takes back to sign in and clears signUpInfo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoToSignIn(object sender, RoutedEventArgs e)
        {
            App.signUpInfo.Clear();
            Frame.Navigate(typeof(SignInPage));
        }

        /// <summary>
        /// Validate input
        /// </summary>
        /// <returns> true if all inputs are valid, false otherwise</returns>
        private bool IsInputValid()
        {
            if (
                FirstName.Text.Length > 0 && LastName.Text.Length > 0 && Email.Text.Length > 0 && Password.Password.Length > 0
                && Email.Text.Contains("@")
                && Email.Text == ConfirmEmail.Text && Password.Password == ConfirmPassword.Password)
            {
                return true;
            }
            return false;
        }
    }
}