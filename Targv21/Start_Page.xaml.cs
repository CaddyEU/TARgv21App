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
    public partial class Start_Page : ContentPage
    {
        StackLayout st;
        ScrollView scrollView;

        List<ContentPage> pages = new List<ContentPage>()
        {
            new Editor_Page(),
            new Riddle_Page(),
            new Timer_Page(),
            new Box_Page(),
            new TrafficLights_Page(),
            new DateTime_Page(),
            new StepperSlider_Page(),
            new ColorSlider_Page(),
            new Frame_Page(),
            new Image_Page(),
            new PopUp_Page(),
            new Dictionary_Page(),
            new Picker_Page(),
            new Table_Page(),
            new File_Page(),
            new Horoskop_Page(),
        };

        List<string> texts = new List<string>
        {
            "Editor page",
            "Riddle page",
            "Timer page",
            "BoxView Page",
            "Traffic lights Page",
            "Date Time Page",
            "Stepper Slider Page",
            "Color Slider Page",
            "Frame page",
            "Image page",
            "PopUp Page",
            "Dictionary Page",
            "Picker Page",
            "Table Page",
            "File Page",
            "Horoskop Page"
        };

        //This staff for making buttons all the time with differnts colors
        //Random random = new Random();

        public EventHandler BoxBtn_Clicked { get; }

        public Start_Page()
        {

            Button TrafficLightsButton = new Button
            {
                Text = "Traffic lights Page",
                BackgroundColor = Color.FromHex("#33ff99")

            };

            st = new StackLayout();

            for (int i = 0; i < pages.Count; i++)
            {
                Button button = new Button
                {
                    Text = texts[i],
                    BackgroundColor = Color.FromHex("#33ff99"),
                    //BackgroundColor = Color.FromRgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)), - this staff for colored random buttons
                    TabIndex = i
                };
                st.Children.Add(button);
                button.Clicked += Button_Clicked;
            }

            scrollView = new ScrollView
            {
                Content = st
            };

            Content = scrollView;

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Button sampel = sender as Button;
            await Navigation.PushAsync(pages[sampel.TabIndex]);
        }
    }
}