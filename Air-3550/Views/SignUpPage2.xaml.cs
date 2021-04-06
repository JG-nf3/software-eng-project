using Air_3550.Models;
using Air_3550.Services;
using Air_3550.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using static Air_3550.Constants.AppConstants;

namespace Air_3550.Views
{
    /// <summary>
    /// 2nd part of SignUp Page.
    /// </summary>
    public sealed partial class SignUpPage2 : Page
    {
        public SignUpPage2()
        {
            InitializeComponent();
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
            Dictionary<string, string> inputDict = new Dictionary<string, string>() {
                {"phoneNumber", Phone.Text.Trim() },
                {"birthDate", BirthDatePicker.Date.Value.DateTime.ToShortDateString() },
                {"city", City.Text.Trim() },
                {"address1",  Add1.Text.Trim() },
                {"address2", Add2.Text.Trim() },
                {"state", ((string) StateButton.Content).Trim() },
                {"zipCode", ZipCode.Text.Trim() },
                {"creditCardNumber", CreditCardNumber.Text.Trim() }
            };

            // validate input
            if (!Validation.ValidateInputs(inputDict))
            {
                InputWarningText.Visibility = Visibility.Visible;
                return;
            }

            Address address = new Address()
            {
                Address1 = inputDict["address1"],
                Address2 = inputDict["address2"],
                City = inputDict["city"],
                State = StateMap[inputDict["state"]],
                ZipCode = Int32.Parse(inputDict["zipCode"])
            };

            // Add user and user address
            User addedUser = UserService.AddUser(
                App.signUpInfo["firstName"],
                App.signUpInfo["lastName"],
                App.signUpInfo["email"],
                App.signUpInfo["password"],
                Int64.Parse(inputDict["phoneNumber"]),
                inputDict["birthDate"],
                Int64.Parse(inputDict["creditCardNumber"]),
                address,
                UserType.CUSTOMER
                );

            // send email with user id
            Email.SendEmail(
                addedUser.Email,
                "Welcome to Air-3550 !",
                "Hi " + addedUser.FirstName + "\n Your user ID is " + addedUser.Id
                );
            App.signUpInfo.Clear();
            ShowAccountCreatedDialog(addedUser.Id);
            Frame.Navigate(typeof(SignInPage));
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