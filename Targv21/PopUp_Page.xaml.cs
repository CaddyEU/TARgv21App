using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Targv21
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopUp_Page : ContentPage
    {
        Button getName;
        Button alertListButton;
        Button alertQuestionButton;
        Label label;
        public PopUp_Page()
        {
            label = new Label
            {
                Text = "",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.End,
                Margin = 10
            };

            getName = new Button
            {
                Text = "Start game",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center
            };
            getName.Clicked += GetName_ClickedAsync;

            Button alertButton = new Button
            {
                Text = "Message",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center
            };

            alertButton.Clicked += AlertButton_Clicked;

            Button alertYesOrCancel = new Button
            {
                Text = "Yes or Cancel",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center
            };

            alertYesOrCancel.Clicked += AlertYesOrCancel_Clicked;

            alertListButton = new Button
            {
                Text = "Select",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center
            };

            alertListButton.Clicked += AlertListButton_Clicked;

            alertQuestionButton = new Button
            {
                Text = "Question",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center
            };
            alertQuestionButton.Clicked += AlertQuestionButton_Clicked;

            Content = new StackLayout { Children = { label, getName, alertButton, alertYesOrCancel, alertListButton, alertQuestionButton } };
        }

        private async void GetName_ClickedAsync(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Quastion", "Insert your name: ", "OK", keyboard: Keyboard.Chat);
            label.Text = "Hello, " + result + "!";
        }

        private async void AlertQuestionButton_Clicked(object sender, EventArgs e)
        {
            string answer = await DisplayPromptAsync("Quastion", "Which day today?", "OK", "Cancel", "Enter day of week", keyboard: Keyboard.Chat);
            string answerTwo = await DisplayPromptAsync("One more quastion", "How much is 5+5?", "Answer", "Cancel", initialValue: "10", maxLength: 3, keyboard: Keyboard.Numeric);
            if (answer == "Monday")
            {
                alertQuestionButton.BackgroundColor = Color.Pink;
            }
            if (answerTwo == "10")
            {
                alertQuestionButton.BackgroundColor = Color.LightGreen;
            }
        }

        private async void AlertListButton_Clicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Which color do you like?", "Cancel", "OK", "Pink", "Blue", "Red", "Green");
            if (action == "Pink")
            {
                alertListButton.BackgroundColor = Color.Pink;
            }
            if (action == "Green")
            {
                alertListButton.BackgroundColor = Color.Green;
            }
            if (action == "Blue")
            {
                alertListButton.BackgroundColor = Color.Blue;
            }
            if (action == "Red")
            {
                alertListButton.BackgroundColor = Color.Red;
            }
        }

        private async void AlertYesOrCancel_Clicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Confirmation", "Are you sure?", "Yes", "Cancel");
            await DisplayAlert("Message", "You selected: " + (result ? "Yes" : "Cancel"), "OK");
        }

        private void AlertButton_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Message", "You've got new message", "OK");
        }
    }
}