﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileAppRogovski
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RGBsliderPAge : ContentPage
    {
        Random random = new Random();
        Label redlbl,greenlbl,bluelbl;
        Slider sldred, sldgrn, sldblue;
        BoxView colorBox;
        Button btn;
        public RGBsliderPAge()
        {
            sldred = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 0,
                ThumbColor = Color.Red
            };
            sldred.ValueChanged += OnSliderValueChanged;
            sldblue = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 0,
                ThumbColor = Color.Blue
            };
            sldblue.ValueChanged += OnSliderValueChanged;
            sldgrn = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 0,
                ThumbColor = Color.Green
            };
            sldgrn.ValueChanged += OnSliderValueChanged;

            redlbl = new Label { 
                Text = "Red = 0", 
                HorizontalOptions = LayoutOptions.Center 
            };
            greenlbl = new Label { 
                Text = "Green = 0", 
                HorizontalOptions = LayoutOptions.Center 
            };
            bluelbl = new Label { 
                Text = "Blue = 0", 
                HorizontalOptions = LayoutOptions.Center 
            };

            colorBox = new BoxView { 
                Color = Color.Black, 
                HorizontalOptions = LayoutOptions.FillAndExpand, 
                VerticalOptions = LayoutOptions.FillAndExpand 
            };

            btn = new Button
            {
                Text = "Random Color",
                HorizontalOptions = LayoutOptions.Center
            };
            btn.Clicked += RandomColorButton_Clicked;

            Content = new StackLayout
            {
                Padding = new Thickness(20),
                Children =
                {
                    redlbl,
                    sldred,
                    greenlbl,
                    sldgrn,
                    bluelbl,
                    sldblue,
                    colorBox,
                    btn
                }
            };
        }
        
        private void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            int red = Convert.ToInt32(sldred.Value);
            int green = Convert.ToInt32(sldgrn.Value);
            int blue = Convert.ToInt32(sldblue.Value);
            if (sender == sldred)
            {
                redlbl.Text = String.Format("Red = {0:X2}", (int)args.NewValue);
            }
            else if (sender == sldgrn) 
            {
                greenlbl.Text = String.Format("Green = {0:X2}", (int)args.NewValue);
            }
            else if (sender == sldblue)
            {
                bluelbl.Text = String.Format("Blue = {0:X2}", (int)args.NewValue);
            }

            colorBox.Color = Color.FromRgb(red, green, blue);
        }
        private async void RandomColorButton_Clicked(object sender, EventArgs e)
        {
            await AnimateSlider(sldred, GetRandomValue());
            await AnimateSlider(sldgrn, GetRandomValue());
            await AnimateSlider(sldblue, GetRandomValue());
        }

        private double GetRandomValue()
        {
            Random random = new Random();
            return random.Next(0, 255);
        }
        private async Task AnimateSlider(Slider slider, double value)
        {
            
            await slider.TranslateTo(value, 0);
            //slider.Value = value;
        }
    }
}