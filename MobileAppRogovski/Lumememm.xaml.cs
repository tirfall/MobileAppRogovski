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
    public partial class Lumememm : ContentPage
    {
        BoxView bucket, head, body;
        Button IsVis, colorButton;
        Slider meltingSlider;

        public Lumememm()
        {
            BackgroundColor = Color.LightGray;

            // Initialize BoxViews
            bucket = new BoxView
            {
                BackgroundColor = Color.LightGray,
                WidthRequest = 100,
                HeightRequest = 90,
                HorizontalOptions = LayoutOptions.Center,
            };

            head = new BoxView
            {
                BackgroundColor = Color.White,
                WidthRequest = 100,
                HeightRequest = 100,
                HorizontalOptions = LayoutOptions.Center,
                CornerRadius = 50, // Adjusted from 360 to 50 to make a semicircle
            };

            body = new BoxView
            {
                BackgroundColor = Color.White,
                WidthRequest = 150,
                HeightRequest = 150,
                HorizontalOptions = LayoutOptions.Center,
                CornerRadius = 75, // Adjusted from 360 to 75 to make a semicircle
            };
            IsVis = new Button
            {
                BackgroundColor = Color.Blue,
                WidthRequest = 100,
                HeightRequest = 50,
                Text = "Peida",
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 20, 0, 0)
            };
            IsVis.Clicked += IsVis_Clicked;

            colorButton = new Button
            {
                Text = "Random Color",
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 20, 0, 0)
            };
            colorButton.Clicked += ColorButton_Clicked;
            meltingSlider = new Slider
            {
                Minimum = 0,
                Maximum = 1,
                Value = 1, // Initial value
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Margin = new Thickness(20, 20, 20, 0)
            };
            meltingSlider.ValueChanged += MeltingSlider_ValueChanged;

            // Initialize AbsoluteLayout
            AbsoluteLayout al = new AbsoluteLayout();

            // Add BoxViews to AbsoluteLayout
            
            al.Children.Add(head);
            al.Children.Add(body);
            al.Children.Add(bucket);
            al.Children.Add(IsVis);
            al.Children.Add(colorButton);
            al.Children.Add(meltingSlider);
            // Set positions of BoxViews within the AbsoluteLayout

            AbsoluteLayout.SetLayoutBounds(head, new Rectangle(150, 225, head.Width, head.Height));
            AbsoluteLayout.SetLayoutBounds(body, new Rectangle(125, 300, body.Width, body.Height));
            AbsoluteLayout.SetLayoutBounds(bucket, new Rectangle(150, 150, bucket.Width, bucket.Height));
            AbsoluteLayout.SetLayoutBounds(IsVis, new Rectangle(0, 650, IsVis.Width, IsVis.Height));
            AbsoluteLayout.SetLayoutBounds(colorButton, new Rectangle(100, 650, colorButton.Width, colorButton.Height));
            AbsoluteLayout.SetLayoutBounds(meltingSlider, new Rectangle(200, 650, meltingSlider.Width, meltingSlider.Height));

            // Set the AbsoluteLayout as the Content of the ContentPage
            Content = al;
        }

        private void MeltingSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ColorButton_Clicked(object sender, EventArgs e)
        {
            Random random = new Random();
            Color randomColor = Color.FromRgb(random.Next(256), random.Next(256), random.Next(256));
            head.BackgroundColor = randomColor;
            body.BackgroundColor = randomColor;
            Color randomColor1 = Color.FromRgb(random.Next(256), random.Next(256), random.Next(256));
            bucket.BackgroundColor = randomColor1;
        }

        private void IsVis_Clicked(object sender, EventArgs e)
        {
            bucket.IsVisible = !bucket.IsVisible;
            head.IsVisible = !head.IsVisible;
            body.IsVisible = !body.IsVisible;
            IsVis.Text = "Näita";
            if (bucket.IsVisible) { IsVis.Text = "Peida"; }
        }
    }
}