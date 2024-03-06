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
    public partial class RGBsliderPAge : ContentPage
    {
        Random random = new Random();
        Label redlbl,greenlbl,bluelbl;
        Slider sldred, sldgrn, sldblue;
        BoxView colorBox;
        Button btn;
        Stepper stp;
        public RGBsliderPAge()
        {
            stp = new Stepper
            {
                Minimum = 0,
                Maximum = 255,
                Increment = 10,
                Value = 255,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };
            stp.ValueChanged += OnSliderValueChanged;
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
                Children =
                {
                    redlbl,
                    sldred,
                    greenlbl,
                    sldgrn,
                    bluelbl,
                    sldblue,
                    colorBox,
                    btn,
                    stp
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

            colorBox.Color = Color.FromRgba(red, green, blue, (int)stp.Value);
            
            
        }
        private void RandomColorButton_Clicked(object sender, EventArgs e)
        {
            ToColor(sldred, redlbl, new Random().Next(256), "Red");
            ToColor(sldgrn, greenlbl, new Random().Next(256), "Green");
            ToColor(sldblue, bluelbl, new Random().Next(256), "Blue");
        }

        private void ToColor(Slider slider, Label label, int ToColor, string color)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (slider.Value > ToColor)
                {
                    for (; slider.Value > ToColor; slider.Value--)
                    {
                        label.Text = string.Format("{1} = {0}", (int)slider.Value, color);
                        await Task.Delay(10);
                    }
                }
                else
                {
                    for (; slider.Value < ToColor; slider.Value++)
                    {
                        label.Text = string.Format("{1} = {0}", (int)slider.Value, color);
                        await Task.Delay(10);
                    }
                }
            });
        }
    }
}