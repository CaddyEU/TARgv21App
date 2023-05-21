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
    public partial class Timer_Page : ContentPage
    {
        public Timer_Page()
        {
            InitializeComponent();
        }
        int i=0; 
        private async void NaitaAeg()
        {
            while (true)
            {
                lbl.Text = DateTime.Now.ToString("T");
                await Task.Delay(1000);
            }
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            i++;           
            if (i==10)
            {
                NaitaAeg();
            }
            else
            {
                lbl.Text = "Vajutatud " + i.ToString() + " korda";
            }
        }

        private async void tagasi_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}