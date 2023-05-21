using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Targv21
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Picker_Page : ContentPage
    {
        Picker picker;
        WebView webview;
        Entry entry;
        Button textButton;
        Frame frame;       
        string[] pages = new string[3] { "https://tahvel.edu.ee/#/", "https://moodle.edu.ee/my/", "https://www.tthk.ee/" };
        StackLayout stack;
        public Picker_Page()
        {
            picker = new Picker 
            { 
                Title = "Pages"
            };

            picker.Items.Add("Tahvel");
            picker.Items.Add("Moodle");
            picker.Items.Add("TTHK");

            webview = new WebView 
            {
                Source = new UrlWebViewSource { Url = pages[0] }
            };

            picker.SelectedIndexChanged += Picker_SelectedIndexChanged;

            entry = new Entry { };
            entry.Completed += Entry_Completed;
            textButton = new Button { Text = "Homepage" };
            textButton.Clicked += TextButton_Clicked;


            frame = new Frame 
            { 
                Content = webview,
                BorderColor = Color.FromHex("#ffcccc"),
                CornerRadius = 10,
                HeightRequest = 400,
                WidthRequest = 150,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                HasShadow = true
            };

            stack = new StackLayout { Children = {picker, frame, entry, textButton} };
            Content = stack;

        }

        private void TextButton_Clicked(object sender, EventArgs e)
        {
            webview.Source = new UrlWebViewSource { Url = (string)Preferences.Get("link", "https://postimess.ee/") };
        }

        protected override void OnAppearing()
        {
            object link = "";
            entry.Text = Preferences.Get("link", "http://www.postimees.ee/");
            base.OnAppearing();
        }

        private void Entry_Completed(object sender, EventArgs e)
        {
            string value = "http://www." + entry.Text;
            Preferences.Set("link", value);
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            webview.Source = new UrlWebViewSource { Url = pages[picker.SelectedIndex] } ;
        }
    }
}