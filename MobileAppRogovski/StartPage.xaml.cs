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
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            Button Entry_btn = new Button
            {
                Text = "Entry Leht",
                BackgroundColor = Color.FromRgb(32, 32, 34),
                TextColor = Color.Fuchsia

            };
            Button Time_btn = new Button
            {
                Text = "Time Leht",
                BackgroundColor = Color.FromRgb(32, 32, 34),
                TextColor = Color.Fuchsia

            };
            Button Box_btn = new Button
            {
                Text = "Box Leht",
                BackgroundColor = Color.FromRgb(32, 32, 34),
                TextColor = Color.Fuchsia

            };
            StackLayout st = new StackLayout 
            { 
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.FromRgb(32,32,255)
            };
            st.Children.Add(Entry_btn);
            st.Children.Add(Time_btn);
            st.Children.Add(Box_btn);
            Content = st;
            //InitializeComponent();

            Entry_btn.Clicked += Entry_btn_Clicked;
            Time_btn.Clicked += Time_btn_Clicked;
            Box_btn.Clicked += Box_btn_Clicked;
        }

        private async void Box_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BoxView_Page());
        }

        private async void Time_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TimePage());
        }

        private async void Entry_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Entry_Page());
        }
    }
}