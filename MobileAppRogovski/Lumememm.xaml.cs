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
        Button IsVis, colorButton, meltBut, resetBut;

        public Lumememm()
        {
            BackgroundColor = Color.MintCream;

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
                HeightRequest = 60,
                Text = "Peida",
                HorizontalOptions = LayoutOptions.Center
            };
            IsVis.Clicked += IsVis_Clicked;

            colorButton = new Button
            {
                BackgroundColor = Color.Green,
                WidthRequest = 100,
                HeightRequest = 60,
                Text = "Random Color",
                HorizontalOptions = LayoutOptions.Center
            };
            colorButton.Clicked += ColorButton_Clicked;
            meltBut = new Button
            {
                BackgroundColor = Color.Red,
                WidthRequest = 100,
                HeightRequest = 60,
                Text = "Melt lumememm",
                HorizontalOptions = LayoutOptions.Center
            };
            meltBut.Clicked += meltBut_Clicked;
            resetBut = new Button
            {
                BackgroundColor = Color.Blue,
                WidthRequest = 100,
                HeightRequest = 60,
                Text = "reset",
                HorizontalOptions = LayoutOptions.Center
            };
            resetBut.Clicked += resetBut_Clicked;

            // Initialize AbsoluteLayout
            AbsoluteLayout al = new AbsoluteLayout();

            // Add BoxViews to AbsoluteLayout
            
            al.Children.Add(head);
            al.Children.Add(body);
            al.Children.Add(bucket);
            al.Children.Add(IsVis);
            al.Children.Add(colorButton);
            al.Children.Add(meltBut);
            al.Children.Add(resetBut);
            // Set positions of BoxViews within the AbsoluteLayout

            AbsoluteLayout.SetLayoutBounds(head, new Rectangle(150, 225, head.Width, head.Height));
            AbsoluteLayout.SetLayoutBounds(body, new Rectangle(125, 300, body.Width, body.Height));
            AbsoluteLayout.SetLayoutBounds(bucket, new Rectangle(150, 150, bucket.Width, bucket.Height));
            AbsoluteLayout.SetLayoutBounds(IsVis, new Rectangle(0, 10, IsVis.Width, IsVis.Height));
            AbsoluteLayout.SetLayoutBounds(colorButton, new Rectangle(100, 10, colorButton.Width, colorButton.Height));
            AbsoluteLayout.SetLayoutBounds(meltBut, new Rectangle(200, 10, meltBut.Width, meltBut.Height));
            AbsoluteLayout.SetLayoutBounds(resetBut, new Rectangle(300, 10, resetBut.Width, resetBut.Height));

            // Set the AbsoluteLayout as the Content of the ContentPage
            Content = al;
        }

        private void resetBut_Clicked(object sender, EventArgs e)
        {
            foreach (BoxView item in new BoxView[] { head, body})
            {
                item.Opacity = 1;
                item.BackgroundColor = Color.White;
            }
            AbsoluteLayout.SetLayoutBounds(bucket, new Rectangle(150, 150, bucket.Width, bucket.Height));
            bucket.BackgroundColor = Color.LightGray;
        }

        private async void meltBut_Clicked(object sender, EventArgs e)
        {
            for (double i = 1; i > 0.01; i -= 0.01)
            {
                head.Opacity = i;
                body.Opacity = i;
                await Task.Delay(10);
            }
            head.Opacity = 0;
            body.Opacity = 0;
            for (int i = 150; i < 500; i += 5)
            {
                AbsoluteLayout.SetLayoutBounds(bucket, new Rectangle(150, i, bucket.Width, bucket.Height));
                await Task.Delay(1);
            }
            int j = 0;
            for (int i = 500; i > 425; i -= 5)
            {
                j += 3;
                AbsoluteLayout.SetLayoutBounds(bucket, new Rectangle(150, i, bucket.Width, bucket.Height));
                await Task.Delay(1);
                bucket.Rotation = j;
            }
            for (int i = 425; i < 500; i += 5)
            {
                j += 3;
                AbsoluteLayout.SetLayoutBounds(bucket, new Rectangle(150, i, bucket.Width, bucket.Height));
                await Task.Delay(1);
                bucket.Rotation = j;
                bucket.HeightRequest += 1;
            }
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
            IsVis.Text = bucket.IsVisible ? "Peida" : "Näita";
            //if (bucket.IsVisible) { IsVis.Text = "Peida"; }
        }
    }
}