using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileAppRogovski
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class startpage1 : ContentPage
    {
        List<ContentPage> pages = new List<ContentPage>() { new Entry_Page(), new TimePage(), new BoxView_Page(), new DateTimePage(), new StepperSliderPage(), new RGBsliderPAge(), new Frame_Page(), new Lumememm(), new PickerPage(), new TripsTrapsTrull() };
        List<string> texts = new List<string>() { "Ava entry leht", "Ava timer leht", "Ava boxview leht", "Ava datetime leht", "Ava stepperslider leht", "Ava RGB leht", "Ava Frame leht", "Ava Lumememm leht", "Ava picker leht", "TripsTrapsTrull leht" };
        StackLayout st;
        public startpage1()
        {
            st = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.AntiqueWhite
            };
            for (int i = 0; i < pages.Count; i++) 
            {
                Button button = new Button
                {
                    Text = texts[i],
                    BackgroundColor = Color.White,
                    TextColor= Color.Black,
                    TabIndex = i
                };
                st.Children.Add(button);
                button.Clicked += Ava_vajav_leht;
            }
            ScrollView sv = new ScrollView { Content = st };
            Content = sv;
        }

        private async void Ava_vajav_leht(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            await Navigation.PushAsync(pages[btn.TabIndex]);
        }
    }
}