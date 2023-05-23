using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Targv21
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Horoskop_Page : ContentPage
    {
        Entry zodiacEntry;
        Picker chooseZodiacSign;
        DatePicker zodiacDatePicker;
        Image zodiacImage;
        Label header, zodiacDescribe;
        ScrollView scrollView;
        public char[] charsToTrim = { '$', '*', ' ', '\'', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', ',', '.', ':', ';', '-', '+', '#', '!', '/', '¤', '%', '&', '(', ')', '=', '?', '`', '[', ']', '{', '}', '<', '>' };
        public Horoskop_Page()
        {
            zodiacDatePicker = new DatePicker
            {

                WidthRequest = 10,
                TextColor = Color.Black

            };
            zodiacDatePicker.DateSelected += datePicker_DateSelected;

            chooseZodiacSign = new Picker
            {
                Title = "Otsing",
                TextColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.Start

            };
            addingDataToPicker();
            chooseZodiacSign.SelectedIndexChanged += ChooseZodiacSign_SelectedIndexChanged;

            zodiacImage = new Image
            {
                Source = ""
            };

            zodiacDescribe = new Label
            {
                Text = "Vali kuupäev voi vajuta otsing",
                TextColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };


            zodiacEntry = new Entry
            {
                Placeholder = "Sodiaagi otsing:",
                WidthRequest = 10,
                MaxLength = 10,
                ClearButtonVisibility = ClearButtonVisibility.WhileEditing, 
                Keyboard = Keyboard.Text, 
                ReturnType = ReturnType.Search, 
                TextColor = Color.Black,
            };
            zodiacEntry.Completed += Entry_Completed;

            Grid grid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto }
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                }
            };


            grid.Children.Add
                (
                    header = new Label
                    {
                        Text = "Sodiaagimärgid",
                        TextColor = Color.BlanchedAlmond,
                        HorizontalTextAlignment = TextAlignment.Center,
                        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
                    }, 0, 0 
                ); ;
            Grid.SetColumnSpan(header, 2);


            grid.Children.Add
                (
                    zodiacImage, 1, 1 
                );
            Grid.SetRowSpan(zodiacImage, 3);


            grid.Children.Add
                (
                    zodiacDatePicker, 0, 1 
                );


            grid.Children.Add
                (
                    zodiacEntry, 0, 2 
                );

            grid.Children.Add
                (
                    chooseZodiacSign, 0, 3 
                );

            grid.Children.Add
                (
                    scrollView = new ScrollView { Content = zodiacDescribe }, 0, 4 
                );
            Grid.SetColumnSpan(scrollView, 2);

            Content = grid;
        }

        private void ChooseZodiacSign_SelectedIndexChanged(object sender, EventArgs e)
        {
            zodiacEntry.Text = chooseZodiacSign.SelectedItem.ToString();
            zodiacEntry.TextColor = Color.Violet;
            zodiacEntry.HorizontalTextAlignment = TextAlignment.Center;
            Entry_Completed(sender, e);
        }

        private void datePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            var year = e.NewDate.Year; 

            if (new DateTime(year, 03, 21) <= e.NewDate && e.NewDate <= new DateTime(year, 04, 20)) 
            {
                jaarZodiac();
            }
            else if (new DateTime(year, 04, 21) <= e.NewDate && e.NewDate <= new DateTime(year, 05, 20))
            {
                sonnZodiac();
            }
            else if (new DateTime(year, 05, 21) <= e.NewDate && e.NewDate <= new DateTime(year, 06, 21))
            {
                kaksikudZodiac();
            }
            else if (new DateTime(year, 06, 22) <= e.NewDate && e.NewDate <= new DateTime(year, 07, 22))
            {
                vahkZodiac();
            }
            else if (new DateTime(year, 07, 23) <= e.NewDate && e.NewDate <= new DateTime(year, 08, 22))
            {
                loviZodiac();
            }
            else if (new DateTime(year, 08, 23) <= e.NewDate && e.NewDate <= new DateTime(year, 09, 22))
            {
                neitsiZodiac();
            }
            else if (new DateTime(year, 09, 23) <= e.NewDate && e.NewDate <= new DateTime(year, 10, 22))
            {
                kaaludZodiac();
            }
            else if (new DateTime(year, 10, 23) <= e.NewDate && e.NewDate <= new DateTime(year, 11, 21))
            {
                skorpionZodiac();
            }
            else if (new DateTime(year, 11, 22) <= e.NewDate && e.NewDate <= new DateTime(year, 12, 21))
            {
                amburZodiac();
            }
            else if (new DateTime(year, 12, 22) <= e.NewDate && e.NewDate <= new DateTime(year, 01, 19))
            {
                kaljukitsZodiac();
            }
            else if (new DateTime(year, 01, 20) <= e.NewDate && e.NewDate <= new DateTime(year, 02, 19))
            {
                veevalajaZodiac();
            }
            else if (new DateTime(year, 02, 20) <= e.NewDate && e.NewDate <= new DateTime(year, 03, 20))
            {
                kaladZodiac();
            }
            else
            {
                tyhiZodiac();
            }

            header.Text = "Sa valisid: " + e.NewDate.ToString("dd/MM/yyyy");  
            header.TextColor = Color.Black;
            header.HorizontalTextAlignment = TextAlignment.Center;
        }

        private void Entry_Completed(object sender, EventArgs e)
        {
            string zodiacEntryText = zodiacEntry.Text.ToLower().Trim(charsToTrim);

            if (zodiacEntryText == "Jaar" || zodiacEntryText == "jaar")
            {

                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 03, 21);
            }
            else if (zodiacEntryText == "Sonn" || zodiacEntryText == "sonn")
            {

                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 04, 21);
            }
            else if (zodiacEntryText == "Kaksikud" || zodiacEntryText == "kaksikud")
            {

                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 05, 21);
            }
            else if (zodiacEntryText == "Vahk" || zodiacEntryText == "vahk")
            {

                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 06, 22);
            }
            else if (zodiacEntryText == "Lovi" || zodiacEntryText == "lovi")
            {

                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 07, 23); //
            }
            else if (zodiacEntryText == "Neitsi" || zodiacEntryText == "neitsi")
            {

                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 08, 22);
            }
            else if (zodiacEntryText == "Kaalud" || zodiacEntryText == "kaalud")
            {

                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 09, 23);
            }
            else if (zodiacEntryText == "Skorpion" || zodiacEntryText == "skorpion")
            {

                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 10, 23);
            }
            else if (zodiacEntryText == "Ambur" || zodiacEntryText == "ambur")
            {

                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 11, 22);
            }
            else if (zodiacEntryText == "Kaljukits" || zodiacEntryText == "kaljukits")
            {

                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 12, 22);
            }
            else if (zodiacEntryText == "Veevalaja" || zodiacEntryText == "veevalaja")
            {

                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 01, 20);
            }
            else if (zodiacEntryText == "Kalad" || zodiacEntryText == "kalad")
            {

                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, 02, 20);
            }
            else
            {
                zodiacDatePicker.Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                tyhiZodiac();
            }

            header.Text = "Sinu otsing: " + zodiacEntryText;
            header.HorizontalTextAlignment = TextAlignment.Center;
        }

        public void jaarZodiac()
        {
            zodiacEntry.Text = "Jaar";
            zodiacEntry.TextColor = Color.Violet;
            zodiacImage.Source = "Aries.png";
            zodiacDescribe.Text = "Leiate vanale probleemile kiire ja mõistliku lahenduse. Ärge jääge liiga kauaks koju. Ära jäta tõtt rääkimast ka siis, kui see haiget teeb. Vältige kangekaelsust ning kuulake ka teiste arvamusi. ";
            zodiacDescribe.TextColor = Color.Black;
            TextAlignment Center = default;
            zodiacDescribe.HorizontalTextAlignment = Center;
            chooseZodiacSign.SelectedIndex = 0;
        }

        public void sonnZodiac()
        {
            zodiacEntry.Text = "Sonn";
            zodiacEntry.TextColor = Color.Violet;
            zodiacImage.Source = "Taurus.png";
            zodiacDescribe.Text = "Muutused on teie jaoks rahaliselt võimalikud. Head asjad tulevad nende juurde, kes ootavad. Teil on armastuses õnne. Näita välja oma erakordset hoolivust ja oskust olla tõeline sõber. ";
            zodiacDescribe.TextColor = Color.Black;
            TextAlignment Center = default;
            zodiacDescribe.HorizontalTextAlignment = Center;
            chooseZodiacSign.SelectedIndex = 1;
        }

        public void kaksikudZodiac()
        {
            zodiacEntry.Text = "Kaksikud";
            zodiacEntry.TextColor = Color.Violet;
            zodiacImage.Source = "Gemini.png";
            zodiacDescribe.Text = "Planeerige midagi uut ning julgege mänguga liituda. Teil tekivad huvitavad tutvused, mis võivad muutuda tõsisteks isiklikeks või ärilisteks kontaktideks. Ära maga maha võimalust oma unistusi ellu viia. Hoia oma süda avatud, maagia on kõikjal, kuhu sa vaatad. ";
            zodiacDescribe.TextColor = Color.Black;
            TextAlignment Center = default;
            zodiacDescribe.HorizontalTextAlignment = Center;
            chooseZodiacSign.SelectedIndex = 2;
        }

        public void vahkZodiac()
        {
            zodiacEntry.Text = "Vahk";
            zodiacEntry.TextColor = Color.Violet;
            zodiacImage.Source = "Cancer.png";
            zodiacDescribe.Text = "Sinu elus liigub võimas jõud, mida ei saa enam tähele panemata jätta. Veetke rohkem aega oma lähedaste sõpradega. Vabane oma plaanitavate tegevuste nimekirjas olevatest asjadest, kui need ei aita sul otse oma ambitsioonide poole pürgida. Ole kannatlik, sa saad loomulikul teel teada kõike, mida sul vaja on. ";
            zodiacDescribe.TextColor = Color.Black;
            TextAlignment Center = default;
            zodiacDescribe.HorizontalTextAlignment = Center;
            chooseZodiacSign.SelectedIndex = 3;
        }

        public void loviZodiac()
        {
            zodiacEntry.Text = "Lovi";
            zodiacEntry.TextColor = Color.Violet;
            zodiacImage.Source = "Leo.png";
            zodiacDescribe.Text = "Hoia oma elu nii lihtsana kui võimalik. Saage võitu väsimusest, hirmudest ja sisemistest barjääridest. Tempomuutus teeb sulle head. Olge kannatlik, jääge muutumatuks ning seadke endale teostatavaid eesmärke.";
            zodiacDescribe.TextColor = Color.RosyBrown;
            TextAlignment Center = default;
            zodiacDescribe.HorizontalTextAlignment = Center;
            chooseZodiacSign.SelectedIndex = 4;
        }

        public void neitsiZodiac()
        {
            zodiacEntry.Text = "Neitsi";
            zodiacEntry.TextColor = Color.Violet;
            zodiacImage.Source = "Virgo.png";
            zodiacDescribe.Text = "Teil on raske keskenduda ning te pole enam elu olemusega kursis. Sinu praegused suhtekonfliktid on tõelised, aga sa tead, kuidas asju korda teha. Planeerige oma kiireloomulisi kulutusi ette. Suudate tööl valikute olemasolu korral kergesti otsust langetada. ";
            zodiacDescribe.TextColor = Color.RoyalBlue;
            TextAlignment Center = default;
            zodiacDescribe.HorizontalTextAlignment = Center;
            chooseZodiacSign.SelectedIndex = 5;
        }

        public void kaaludZodiac()
        {
            zodiacEntry.Text = "Kaalud";
            zodiacEntry.TextColor = Color.Violet;
            zodiacImage.Source = "Libra.png";
            zodiacDescribe.Text = "Tempomuutus teeb sulle head. Jagage lähedaste sõpradega oma positiivset energiat. Hoia oma elu nii lihtsana kui võimalik. Uuri uusi projekte enne, kui sa nende kallal töötama hakkad. ";
            zodiacDescribe.TextColor = Color.DarkOliveGreen;
            TextAlignment Center = default;
            zodiacDescribe.HorizontalTextAlignment = Center;
            chooseZodiacSign.SelectedIndex = 6;
        }

        public void skorpionZodiac()
        {
            zodiacEntry.Text = "Skorpion";
            zodiacEntry.TextColor = Color.Violet;
            zodiacImage.Source = "Scorpio.png";
            zodiacDescribe.Text = "See oleks ideaalne aeg kellegi uuega tutvumiseks. Naudi hetkeks oma igapäeva rutiinist vabanemist. Näita välja oma erakordset hoolivust ja oskust olla tõeline sõber. Mõistke ennast ümbritsevaid inimesi ning andestage neile nende tehtud vead.";
            zodiacDescribe.TextColor = Color.Red;
            TextAlignment Center = default;
            zodiacDescribe.HorizontalTextAlignment = Center;
            chooseZodiacSign.SelectedIndex = 7;
        }

        public void amburZodiac()
        {
            zodiacEntry.Text = "Ambur";
            zodiacEntry.TextColor = Color.Violet;
            zodiacImage.Source = "Sagittarius.png";
            zodiacDescribe.Text = "Sa ei karda sattuda olukorda, mis nõuab sinupoolset sekkumist. Teil on piisavalt võimu, et tasakaalu enda kasuks kallutada. Ole oma lähenemise osas originaalne, ole oma tegevustes lahke ja valmis muutusi omaks võtma. On aeg pisut lõõgastuda.";
            zodiacDescribe.TextColor = Color.Violet;
            TextAlignment Center = default;
            zodiacDescribe.HorizontalTextAlignment = Center;
            chooseZodiacSign.SelectedIndex = 8;
        }

        public void kaljukitsZodiac()
        {
            zodiacEntry.Text = "Kaljukits";
            zodiacEntry.TextColor = Color.Violet;
            zodiacImage.Source = "Capricorn.png";
            zodiacDescribe.Text = "Teie igatsus romantilise kogemuse järele saab rahuldatud. Ainsad piirid su tuleviku osas on need, mille sa oled loonud oma peas. Võtate endale uusi vastutusi ning ülesandeid, mis teid soovitud eduni viivad. Naudi hetkeks oma igapäeva rutiinist vabanemist. ";
            zodiacDescribe.TextColor = Color.Blue;
            TextAlignment Center = default;
            zodiacDescribe.HorizontalTextAlignment = Center;
            chooseZodiacSign.SelectedIndex = 9;
        }

        public void veevalajaZodiac() 
        {
            zodiacEntry.Text = "Veevalaja";
            zodiacEntry.TextColor = Color.Violet;
            zodiacImage.Source = "Aquarius.png";
            zodiacDescribe.Text = "See on hea aeg oma rahalise olukorra ümberkorraldamiseks. Vaata hoolikalt ning sa võid märgata inimestes külgi, mida sa varem märganud pole. Torm teie eraelus hoopis tugevdab, mitte ei hävita teie suhteid. Millegi uue proovimine ainult seetõttu, et sul igav on, ei tule sulle kasuks.";
            zodiacDescribe.TextColor = Color.Black;
            TextAlignment Center = default;
            zodiacDescribe.HorizontalTextAlignment = Center;
            chooseZodiacSign.SelectedIndex = 10;
        }

        public void kaladZodiac() 
        {
            zodiacEntry.Text = "Kalad";
            zodiacEntry.TextColor = Color.Violet;
            zodiacImage.Source = "Pisces.png";
            zodiacDescribe.Text = "Kui sa küsid abi, siis sa seda ka saad. Vabane oma plaanitavate tegevuste nimekirjas olevatest asjadest, kui need ei aita sul otse oma ambitsioonide poole pürgida. Ärge laske ennast kaasata intriigidesse ega armuafääridesse. Ärge muretsege selle üle, kas te saate asjadega õigel ajal hakkama või mitte.";
            zodiacDescribe.TextColor = Color.Gold;
            TextAlignment Center = default;
            zodiacDescribe.HorizontalTextAlignment = Center;
            chooseZodiacSign.SelectedIndex = 11;
        }

        public void tyhiZodiac() 
        {
            zodiacEntry.Text = "";
            zodiacImage.Source = "blank2.png";
            zodiacDescribe.Text = "Andmed puuduvad";
            zodiacDescribe.HorizontalTextAlignment = TextAlignment.Center;
            zodiacDescribe.TextColor = Color.Red;
            TextAlignment Center = default;
            zodiacDescribe.HorizontalTextAlignment = Center;

        }

        public void addingDataToPicker()
        {
            chooseZodiacSign.Items.Add("Jaar");
            chooseZodiacSign.Items.Add("Sonn");
            chooseZodiacSign.Items.Add("Kaksikud");
            chooseZodiacSign.Items.Add("Vahk");
            chooseZodiacSign.Items.Add("Lovi");
            chooseZodiacSign.Items.Add("Neitsi");
            chooseZodiacSign.Items.Add("Kaalud");
            chooseZodiacSign.Items.Add("Skorpion");
            chooseZodiacSign.Items.Add("Ambur");
            chooseZodiacSign.Items.Add("Kaljukits");
            chooseZodiacSign.Items.Add("Veevalaja");
            chooseZodiacSign.Items.Add("Kalad");
        }
    }
}
