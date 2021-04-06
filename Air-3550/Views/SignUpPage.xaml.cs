using Air_3550.Utils;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

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
            Dictionary<string, string> inputDict = new Dictionary<string, string>() {
                {"firstName", FirstName.Text.Trim() },
                {"lastName", LastName.Text.Trim() },
                {"email",  Email.Text.Trim() },
                {"password", Password.Password }
            };

            if (
                Email.Text != ConfirmEmail.Text || Password.Password != ConfirmPassword.Password ||
                !Validation.ValidateInputs(inputDict)
                )
            {
                InputWarningText.Visibility = Visibility.Visible;
                return;
            }
            inputDict["password"] = SHA512Generate.GenerateSHA512(Password.Password);

            App.signUpInfo = inputDict;

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
    }
}