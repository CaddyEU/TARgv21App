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
    public partial class Frame_Page : ContentPage
    {
        public Frame_Page()
        {
            Frame frame;
            Label label;
            Grid grid;
            int r;
            int g; 
            int b;
            Random random = new Random();

            label = new Label
            {
                Text = "Frame disign",
                FontSize = Device.GetNamedSize(NamedSize.Subtitle, typeof(Label))
            };

            grid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            List<int> bars = new List<int> { (int)DeviceDisplay.MainDisplayInfo.Height/20, (int)
                (DeviceDisplay.MainDisplayInfo.Height)/40, (int) (DeviceDisplay.MainDisplayInfo.Height/20)};
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    r = random.Next(0, 255);
                    g = random.Next(0, 255);
                    b = random.Next(0, 255);
                    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(bars[i]) });
                    grid.Children.Add(new BoxView
                    {
                        Color = Color.FromRgb(r, g, b),
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                    }, j, i);
                }
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }

            /*{
                RowDefinitions =
                {
                    new RowDefinition {Height = new GridLength(2, GridUnitType.Star) },
                    new RowDefinition {Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition {Height = new GridLength(1, GridUnitType.Star)}
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition {Width = new GridLength (1, GridUnitType.Star) },
                    new ColumnDefinition {Width = new GridLength (1, GridUnitType.Star)} 
                }
            };

            grid.Children.Add(new BoxView { Color =Color.Blue},0,0);
            grid.Children.Add(new BoxView { Color = Color.Green}, 1, 0);
            grid.Children.Add(new BoxView { Color = Color.Red }, 0, 1);
            grid.Children.Add(new BoxView { Color =Color.YellowGreen}, 1, 1);
            grid.Children.Add(new BoxView { Color = Color.Purple }, 0, 2);
            grid.Children.Add(new BoxView { Color = Color.Pink}, 1, 2);*/

            frame = new Frame
            {
                Content = grid,
                BorderColor = Color.FromRgb(20, 120, 255),
                CornerRadius = 20,
                HorizontalOptions= LayoutOptions.FillAndExpand,
                VerticalOptions= LayoutOptions.Center,
                BackgroundColor = Color.FromHex("#ffccff"),
                Margin = 5
            };

            StackLayout stack = new StackLayout
            {
                Children = { label, frame }
            };

            Content = stack;
        }
    }
}