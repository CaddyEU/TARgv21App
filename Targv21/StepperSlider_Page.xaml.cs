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
    public partial class StepperSlider_Page : ContentPage
    {
        Stepper stepper;
        Slider slider;
        Label label;
        public StepperSlider_Page()
        {
            stepper = new Stepper
            {
                Minimum = 0,
                Maximum = 100,
                Value = 50,
                Increment = 5,
            };

            stepper.ValueChanged += Stepper_ValueChanged;

            label = new Label
            {
                Text = "Test",
                FontSize = stepper.Value,
            };

            slider = new Slider
            {
                Minimum = stepper.Minimum,
                Maximum = stepper.Maximum,
                Value = stepper.Value,
                MinimumTrackColor = Color.White,
                MaximumTrackColor = Color.Black
            };

            slider.ValueChanged += Stepper_ValueChanged;

            AbsoluteLayout abs = new AbsoluteLayout { Children = { stepper, label, slider } };

            AbsoluteLayout.SetLayoutBounds(stepper, new Rectangle(0.4, 0.4, 200, 100));
            AbsoluteLayout.SetLayoutFlags(stepper, AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(slider, new Rectangle(0.5, 0.6, 200, 100));
            AbsoluteLayout.SetLayoutFlags(slider, AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(label, new Rectangle(0.6, 0.9, 200, 100));
            AbsoluteLayout.SetLayoutFlags(label, AbsoluteLayoutFlags.PositionProportional);

            Content = abs;
        }

        private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            label.Text = "OK";
            label.FontSize = e.NewValue;
        }
    }
}
