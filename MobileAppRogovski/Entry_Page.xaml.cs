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
    public partial class Entry_Page : ContentPage
    {
        Label lbl;
        Editor editor;
        public Entry_Page()
        {
            Button Close_btn = new Button
            {
                Text = "Close Leht",
                BackgroundColor = Color.FromRgb(32, 32, 34),
                TextColor = Color.Fuchsia

            };
            
            lbl = new Label
            {
                Text = "Teksssssssssst",
                BackgroundColor = Color.FromRgb(30, 4, 105),
                TextColor = Color.Fuchsia
                
            };
            editor = new Editor 
            { 
                Placeholder = "Sisesta siia tekst...",
                HorizontalOptions = LayoutOptions.Center
            };
            StackLayout st = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.FromRgb(32, 32, 255),
                Children = { lbl,editor, Close_btn },
                VerticalOptions = LayoutOptions.End
            };
            Content = st;

            Close_btn.Clicked += Close_btn_Clicked;

            editor.TextChanged += Editor_TextChanged;
        }

        private void Editor_TextChanged(object sender, TextChangedEventArgs e)
        {
            lbl.Text = editor.Text;
        }

        private async void Close_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}