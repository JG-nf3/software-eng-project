using Air_3550.Utils;
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
    }
}