using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Targv21
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Box_Page : ContentPage
    {
        BoxView box;
        Random random = new Random();

        public Box_Page()
        {
            int r = 0, g = 0, b = 0;
            box = new BoxView
            {
                Color = Color.FromRgb(r, g, b),
                CornerRadius = 20,
                WidthRequest = 200,
                HeightRequest = 300,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            box.GestureRecognizers.Add(tap);
            Content = new StackLayout { Children = { box } };
        }

        private void Tap_Tapped(object sender, EventArgs e)
        {
            box.Color = Color.FromRgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
            box.WidthRequest = box.Width + 10;
            box.HeightRequest = box.Height + 10;

            if (box.HeightRequest > (int)DeviceDisplay.MainDisplayInfo.Height / 5)
            {
                box.HeightRequest = 300;
                box.WidthRequest = 200;
            }
        }
    }
}