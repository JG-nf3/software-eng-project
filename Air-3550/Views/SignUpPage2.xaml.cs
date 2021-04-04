using Air_3550.Models;
using Air_3550.Services;
using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using static Air_3550.Constants.AppConstants;
using Air_3550.Utils;

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
            string firstName = App.signUpInfo["firstName"];
            string lastName = App.signUpInfo["lastName"];
            string email = App.signUpInfo["email"];
            string password = App.signUpInfo["password"];
            string phoneNumber = Phone.Text;
            string date = BirthDatePicker.Date.Value.DateTime.ToShortDateString();

            Address address = new Address()
            {
                Address1 = Add1.Text,
                Address2 = Add2.Text,
                City = City.Text,
                State = StateMap[(string)StateButton.Content],
                ZipCode = Int32.Parse(Zip.Text)
            };

            User addedUser = UserService.AddUser(
                firstName,
                lastName,
                email,
                password,
                phoneNumber,
                date,
                address,
                UserType.CUSTOMER
                );

            Email.SendEmail(
                addedUser.Email, 
                "Welcome to Air-3550 !",
                "Hi " + addedUser.FirstName + "\n Your user ID is " + addedUser.Id
                );
            App.signUpInfo.Clear();
            Frame.Navigate(typeof(SignInPage));
        }
    }
}