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
    public partial class PickerPage : ContentPage
    {
        Picker picker;
        WebView webview;
        
        string[] lehed = new string[3] { "https://moodle.edu.ee/", "https://thk.edupage.org/timetable/view.php?fullscreen=1", "https://www.tthk.ee/" };
        public PickerPage()
        {
            picker = new Picker()
            {
                Title = "veebilehed"
            };
            foreach (string leht in lehed)
            {
                picker.Items.Add(leht);
            }
            webview = new WebView
            {
                Source = new UrlWebViewSource { Url = "https://www.w3schools.com" },
                HeightRequest = 400,
                WidthRequest = 100
            };
            SwipeGestureRecognizer swipe = new SwipeGestureRecognizer
            {
                Direction = SwipeDirection.Right 
            };
            swipe.Swiped += Swipe_Swiped;
            webview.GestureRecognizers.Add(swipe);
            picker.SelectedIndexChanged += Valime_leht_avamiseks;
            Content = new StackLayout
            {
                Children = { picker, webview }
            };
        }

        private void Swipe_Swiped(object sender, SwipedEventArgs e)
        {
            switch(e.Direction)
            {
                case SwipeDirection.Right:
                    webview.GoBack();
                    picker.SelectedIndex += 1;
                    break;
                case SwipeDirection.Left:
                    //webview.GoForward();
                    if (picker.SelectedIndex == 0)
                    {
                        picker.SelectedIndex = lehed.Length - 1;
                    }
                    else { picker.SelectedIndex -= 1; }
                    
                    break;
                case SwipeDirection.Up:
                    webview.Source = new UrlWebViewSource { Url = lehed[0] };
                    break;
                case SwipeDirection.Down:
                    webview.Source = new UrlWebViewSource { Url = lehed[lehed.Length-1] };
                    break;
                default:
                    break;
            }
        }

        private void Valime_leht_avamiseks(object sender, EventArgs e)
        {
            webview.Source = new UrlWebViewSource { Url = lehed[picker.SelectedIndex] };
        }
    }
}