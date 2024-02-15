using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileAppRogovski
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Frame_Page : ContentPage
    {
        Grid grid;
        Random random = new Random();
        Frame fr;
        Label lbl;
        Image image;
        Switch sw;
        public Frame_Page()
        {
            grid = new Grid
            {
                BackgroundColor = Color.LightBlue,
                HorizontalOptions= LayoutOptions.FillAndExpand,
                VerticalOptions= LayoutOptions.FillAndExpand
            };

            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            tap.NumberOfTapsRequired = 1;
            grid.GestureRecognizers.Add(tap);

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    grid.Children.Add(
                        fr = new Frame { 
                            BackgroundColor= Color.FromRgb(random.Next(0,255), random.Next(0,255), random.Next(0,255)),
                            HorizontalOptions= LayoutOptions.FillAndExpand,
                            VerticalOptions= LayoutOptions.FillAndExpand
                        },i,j
                    );
                    fr.GestureRecognizers.Add(tap);
                }
            };
            lbl = new Label { Text = "Tekst", FontSize=Device.GetNamedSize(NamedSize.Subtitle, typeof(Label))};
            grid.Children.Add(lbl,0,6);
            Grid.SetColumnSpan(lbl, 10);

            image = new Image { Source ="cat.png"};
            sw=new Switch { IsToggled = false };
            sw.Toggled += Image_On_Off;
            grid.Children.Add(sw, 0, 7);
            grid.Children.Add(image, 1, 7);

            Content = grid;
        }

        private void Image_On_Off(object sender, ToggledEventArgs e)
        {
            image.IsVisible = e.Value;
        }

        private void Tap_Tapped(object sender, EventArgs e)
        {
            Frame fr = (Frame)sender;
            var r = Grid.GetRow(fr)+1;
            var c = Grid.GetColumn(fr)+1;
            lbl.Text = "Rida: "+r.ToString() + "Veerg: " + c.ToString();
        }
    }
}