using Air_3550.Models;
using Air_3550.Services;
using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using static Air_3550.Constants.AppConstants;
using Air_3550.Utils;

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
            WelcomeText.Text = "Hello, " + App.signUpInfo["firstName"] + " !";
            for (int i = 0; i < StateMap.Count; i++)
            {
                MenuFlyoutItem item = new MenuFlyoutItem
                {
                    Text = StateMap.Keys.ElementAt(i)
                };
                item.Click += OnStateSelect;
                StatesFlyout.Items.Insert(i, item);
            }
        }

        /// <summary>
        /// Create State MenuFly Selection Item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnStateSelect(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem state = sender as MenuFlyoutItem;
            StateButton.Content = state.Text;
        }

        /// <summary>
        /// Navigate back to signUp1 page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetBack(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SignUpPage));
        }

        /// <summary>
        /// Finish SignUp and Clear SignUpInfo. Also Navigates to Sign In Page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FinishSignUp(object sender, RoutedEventArgs e)
        {
            if (!IsInputValid())
            {
                InputWarningText.Visibility = Visibility.Visible;
                return;
            }

            string firstName = App.signUpInfo["firstName"];
            string lastName = App.signUpInfo["lastName"];
            string email = App.signUpInfo["email"];
            string password = App.signUpInfo["password"];
            string phoneNumber = Phone.Text;
            string date = BirthDatePicker.Date.Value.DateTime.ToShortDateString();
            string creditCardNumber = CreditCardNumber.Text;

            Address address = new Address()
            {
                Address1 = Add1.Text,
                Address2 = Add2.Text,
                City = City.Text,
                State = StateMap[(string) StateButton.Content],
                ZipCode = Int32.Parse(Zip.Text)
            };

            User addedUser = UserService.AddUser(
                firstName,
                lastName,
                email,
                password,
                phoneNumber,
                date,
                creditCardNumber,
                address,
                UserType.CUSTOMER
                );

            Email.SendEmail(
                addedUser.Email, 
                "Welcome to Air-3550 !",
                "Hi " + addedUser.FirstName + "\n Your user ID is " + addedUser.Id
                );
            App.signUpInfo.Clear();
            ShowAccountCreatedDialog(addedUser.Id);
            Frame.Navigate(typeof(SignInPage));
        }

        /// <summary>
        /// Validate user input
        /// </summary>
        /// <returns></returns>
        private bool IsInputValid()
        {
            if (
                int.TryParse(Phone.Text, out _) &&
                Add1.Text.Length > 0 && City.Text.Length > 0 && (string) StateButton.Content != "State" &&
                Zip.Text.Length == 5 && int.TryParse(Zip.Text, out _) &&

                int.TryParse(CreditCardNumber.Text, out _)
                )
            {
                return true;
            }
            return false;
        }

        private async void ShowAccountCreatedDialog(int userId)
        {
            ContentDialog noWifiDialog = new ContentDialog()
            {
                Title = "Account Created",
                Content = "Your User Id is " + userId + "\n Your user id is also sent to your Email.",
                CloseButtonText = "Ok"
            };

            await noWifiDialog.ShowAsync();
        }
    }
}
