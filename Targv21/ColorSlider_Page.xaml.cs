using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static System.Net.WebRequestMethods;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;



namespace Targv21
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ColorSlider_Page : ContentPage
    {
        BoxView boxView;
        Stepper stepper;

        Slider sliderRed;
        Slider sliderGreen;
        Slider sliderBlue;
        
        Label labelRed;
        Label labelGreen;
        Label labelBlue;
        Label labelOppacity;

        public ColorSlider_Page()
        {
            labelRed = new Label 
            { 
                Text = "Red = ", 
                HorizontalOptions = LayoutOptions.Center 
            };

            labelGreen = new Label 
            { 
                Text = "Green = ", 
                HorizontalOptions = LayoutOptions.Center 
            };

            labelBlue = new Label 
            { 
                Text = "Blue = ", 
                HorizontalOptions = LayoutOptions.Center 
            };

            labelOppacity = new Label 
            { 
                Text = "Alpha = ", 
                HorizontalOptions = LayoutOptions.Center 
            };

            stepper = new Stepper
            {
                Minimum = 0,
                Maximum = 255,
                Value = 255,
                Increment = 5,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.EndAndExpand
            };

            stepper.ValueChanged += Stepper_ValueChanged;

            sliderRed = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 50,
                MinimumTrackColor = Color.Red,
                MaximumTrackColor = Color.LightGray,
            };
            sliderRed.ValueChanged += Stepper_ValueChanged;

            sliderGreen = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 50,
                MinimumTrackColor = Color.Green,
                MaximumTrackColor = Color.LightGray,
            };
            sliderGreen.ValueChanged += Stepper_ValueChanged;

            sliderBlue = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 50,
                MinimumTrackColor = Color.Blue,
                MaximumTrackColor = Color.LightGray,
            };
            sliderBlue.ValueChanged += Stepper_ValueChanged;

            boxView = new BoxView
            {
                Color = Color.FromHex("#ffd4cc"),
                WidthRequest = 200,
                HeightRequest = 300
            };

            List<Object> objects = new List<Object> 
            { 
                boxView,
                sliderRed,
                labelRed,
                sliderGreen,
                labelGreen,
                sliderBlue,
                labelBlue,
                stepper,
                labelOppacity
            };

            /*AbsoluteLayout code example.

            AbsoluteLayout abs = new AbsoluteLayout();
            double y = 0;
            foreach (var item in objects)
            {
                y = y + 0.1;
                AbsoluteLayout.SetLayoutBounds((BindableObject)item, new Rectangle(0.2, y, 300, 100));
                AbsoluteLayout.SetLayoutFlags((BindableObject)item, AbsoluteLayoutFlags.PositionProportional);
                abs.Children.Add((View)(BindableObject)item);
            }

            Content = abs;*/

            //This code sample puts elements more naturally. For best elements position use Grid or FlexLayout
            
            StackLayout stack = new StackLayout
            {
                Children = 
                { 
                    boxView, 
                    sliderRed, 
                    labelRed, 
                    sliderGreen, 
                    labelGreen, 
                    sliderBlue, 
                    labelBlue, 
                    stepper, 
                    labelOppacity 
                }
            };

            stack.BackgroundColor = Color.White;
            Content = stack;
        }

        private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (sender == sliderRed)
            {
                labelRed.Text = String.Format("Red = {0:X2}", (int)e.NewValue);
            }
            else if (sender == sliderGreen)
            {
                labelGreen.Text = String.Format("Green = {0:X2}", (int)e.NewValue);
            }
            else if (sender == sliderBlue)
            {
                labelBlue.Text = String.Format("Blue = {0:X2}", (int)e.NewValue);
            }
            else if (sender == stepper)
            {
                labelOppacity.Text = String.Format("Alpha = {0:X2}", (int)e.NewValue);
            }

            boxView.Color = Color.FromRgba((int)sliderRed.Value,
                                      (int)sliderGreen.Value,
                                      (int)sliderBlue.Value,
                                      (int)stepper.Value);
        }
    }
}