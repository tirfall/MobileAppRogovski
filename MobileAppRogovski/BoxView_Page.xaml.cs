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
    public partial class BoxView_Page : ContentPage
    {
        BoxView box;
        Label lbl;
        int mount = 1; 
        public BoxView_Page()
        {
            int r=0, g=0, b=0;
            box = new BoxView
            {
                Color= Color.FromRgb(r, g, b),
                CornerRadius=10,
                WidthRequest=200, HeightRequest=200,
                HorizontalOptions=LayoutOptions.Center,
                VerticalOptions=LayoutOptions.CenterAndExpand
            };
            lbl = new Label
            {
                Text="0",
                WidthRequest = 200,
                HeightRequest = 200,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontSize=50
            };
            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            box.GestureRecognizers.Add(tap);
            StackLayout st = new StackLayout { Children = { box, lbl } };
            Content = st;
        }
        Random rnd;
        private void Tap_Tapped(object sender, EventArgs e)
        {
            rnd = new Random();
            box.Color = Color.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
            lbl.Text = mount++.ToString();
            box.Rotation = mount;
        }

        

    }
}