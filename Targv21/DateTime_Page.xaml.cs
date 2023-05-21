using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Targv21
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DateTime_Page : ContentPage
    {
        DatePicker datePicker;
        TimePicker timePicker;
        Label lbl;
        public DateTime_Page()
        {
            datePicker = new DatePicker
            {
                Format = "D",
                MinimumDate = DateTime.Now.AddDays(-7),
                MaximumDate = DateTime.Now.AddDays(7)
            };

            datePicker.DateSelected += DatePicker_DateSelected;

            timePicker = new TimePicker
            {
                Format = "D",
                Time = new TimeSpan(12, 30, 0)
            };

            timePicker.PropertyChanged += TimePicker_PropertyChanged;

            lbl = new Label
            {
                Text = "..."
            };

            AbsoluteLayout abs = new AbsoluteLayout { Children = { datePicker, timePicker, lbl } };

            AbsoluteLayout.SetLayoutBounds(datePicker, new Rectangle(0.2, 0.2, 300, 100));
            AbsoluteLayout.SetLayoutFlags(datePicker, AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(timePicker, new Rectangle(0.6, 0.5, 300, 100));
            AbsoluteLayout.SetLayoutFlags(timePicker, AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(lbl, new Rectangle(0.2, 0.8, 300, 100));
            AbsoluteLayout.SetLayoutFlags(lbl, AbsoluteLayoutFlags.PositionProportional);

            Content = abs;
        }

        private void TimePicker_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            lbl.Text = "Time: " + timePicker.Time.ToString();
        }

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            lbl.Text = "Date: " + e.NewDate.ToString();
        }
    }
}