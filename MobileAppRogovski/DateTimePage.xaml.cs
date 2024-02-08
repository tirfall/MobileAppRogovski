using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileAppRogovski
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DateTimePage : ContentPage
    {
        DatePicker dp;
        TimePicker tp;
        Label lbl;
        public DateTimePage()
        {
            dp = new DatePicker()
            {
                Format = "D",
                MinimumDate = DateTime.Now.AddDays(-10),
                MaximumDate = DateTime.Now.AddDays(10),
                TextColor = Color.Black
            };
            dp.DateSelected += Dp_DateSelected;
            tp = new TimePicker
            {
                Time=new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
            };
            tp.PropertyChanged += Tp_PropertyChanged;
            lbl = new Label
            {
                BackgroundColor= Color.AntiqueWhite
            };
            AbsoluteLayout abs = new AbsoluteLayout
            {
                Children= {dp, tp}
            };
            AbsoluteLayout.SetLayoutBounds(dp, new Rectangle(0.2, 0.2, 300, 300));
            AbsoluteLayout.SetLayoutFlags(dp, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(tp, new Rectangle(0.2, 0.6, 300, 300));
            AbsoluteLayout.SetLayoutFlags(tp, AbsoluteLayoutFlags.PositionProportional);
            Content = abs;
        }

        private void Tp_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            lbl.Text = "Aeg: " + tp.Time.ToString();
        }

        private void Dp_DateSelected(object sender, DateChangedEventArgs e)
        {
            lbl.Text=e.NewDate.ToString("D");
        }
    }
}