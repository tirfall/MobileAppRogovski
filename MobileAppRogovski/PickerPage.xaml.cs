using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileAppRogovski
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PickerPage : ContentPage
    {
        Picker picker;
        WebView webView;
        Entry search;
        ImageButton home, back, forward, favorite, add, delete;
        StackLayout st;
        List<string> favoriteList = new List<string>() { "www.tthk.ee/" };
        string urlR;
        public PickerPage()
        {
            BackgroundColor= Color.LightGray;
            Title = "Picker Page";
            picker = new Picker
            {
                Title = "AJALUGU",
                TitleColor = Color.Gray,
                TextColor = Color.Gray
            };
            picker.SelectedIndexChanged += Picker_SelectedIndexChanged;
            webView = new WebView
            {
                Source = new UrlWebViewSource { Url = "https://www.tthk.ee" },
                WidthRequest = 200,
                HeightRequest = 700,
            };
            webView.Navigated += (sender, e) =>
            {
                picker.Items.Add(e.Url.Replace("https://", ""));
                search.TextColor = Color.Gray;
                search.Text = "OTSING";
                urlR = e.Url.Replace("https://", "");
            };
            search = new Entry
            {
                Text = "OTSING",
                TextColor = Color.Gray,
                MaxLength = 20,
                WidthRequest = 200,
                FontSize = 16,
            };
            search.Focused += (sender, e) =>
            {
                search.Text = string.Empty;
                search.TextColor = Color.Gray;
            };
            search.Unfocused += Search_Unfocused;
            home = new ImageButton
            {
                HeightRequest = 50,
                WidthRequest = 50,
                Source = ImageSource.FromStream(() => new MemoryStream(Properties.Resources.home)),
                BackgroundColor = Color.Transparent
            };
            home.Clicked += (sender, e) =>
            {
                webView.Source = new UrlWebViewSource { Url = "https://www.tthk.ee"};
            };
            back = new ImageButton
            {
                HeightRequest = 50,
                WidthRequest = 50,
                Source = ImageSource.FromStream(() => new MemoryStream(Properties.Resources.back)),
                BackgroundColor = Color.Transparent
            };
            back.Clicked += (sender, e) => webView.GoBack();
            forward = new ImageButton
            {
                HeightRequest = 50,
                WidthRequest = 50,
                Source = ImageSource.FromStream(() => new MemoryStream(Properties.Resources.forward)),
                BackgroundColor = Color.Transparent
            };
            forward.Clicked += (sender, e) => webView.GoForward();
            favorite = new ImageButton
            {
                HeightRequest = 50,
                WidthRequest = 50,
                Source = ImageSource.FromStream(() => new MemoryStream(Properties.Resources.star)),
                BackgroundColor = Color.Transparent,
            };
            favorite.Clicked += Favorite_Clicked;
            add = new ImageButton
            {
                HeightRequest = 50,
                WidthRequest = 50,
                Source = ImageSource.FromStream(() => new MemoryStream(Properties.Resources.plus)),
                BackgroundColor = Color.Transparent
            };
            add.Clicked += Add_Clicked;
            
            st = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { home, back, forward, new Frame { WidthRequest = 195, BackgroundColor = Color.Transparent }, favorite, add },
            };
            Content = new StackLayout
            {
                Children = { picker, search, st, webView },
            };
        }

        private async void Delete_Clicked(object sender, EventArgs e)
        {
            if (!favoriteList.Contains(urlR))
                return;
            favoriteList.Remove(urlR);
            await DisplayAlert("Teavitus", "Sa kustutasid lehe", "OK");
        }

        private async void Add_Clicked(object sender, EventArgs e)
        {
            if (favoriteList.Contains(urlR))
                return;
            favoriteList.Add(urlR);
            await DisplayAlert("Teavitus", "Sa lisad lehe", "OK");
        }

        private async void Favorite_Clicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Lemmiklehed", "Lisa", "Kustuta", favoriteList.ToArray());
            if (action == "Kustuta")
            {
                string siteToDelete = await DisplayActionSheet("Kustutamine", "Kaota", null, favoriteList.ToArray());
                if (siteToDelete != "Kaota")
                {
                    favoriteList.Remove(siteToDelete);
                    await DisplayAlert("Teavitus", "Sa kustutasid lehe", "OK");
                }
            }
            else if (action == "Lisa")
            {
                string siteToAdd = await DisplayPromptAsync("Lisamine", "Kirjuta lehe nimi:",accept: "Lisa",cancel: "Kaota", placeholder: "Lehe nimi");
                if (!string.IsNullOrEmpty(siteToAdd))
                {
                    if (!favoriteList.Contains(siteToAdd) && siteToAdd.Contains("."))
                    {
                        favoriteList.Add(siteToAdd);
                        await DisplayAlert("Teavitus", "Sa lisatud lehe", "OK"); 
                    }
                    else
                    {
                        await DisplayAlert("Teavitus", "Ei saa lisata", "OK");
                    }
                    
                }
            }
            else if (action != "Kustuta" && action != "Kaota")
            {
                webView.Source = new UrlWebViewSource { Url = "https://" + action };
            }
        }

    


        private void Search_Unfocused(object sender, FocusEventArgs e)
        {
            if (search.Text == string.Empty)
                return;
            string[] list = search.Text.Split('.');
            if (list.Length == 1 || list[1].Length < 1)
                return;
            try
            {
                webView.Source = new UrlWebViewSource { Url = "https://" + search.Text };
            }
            catch (Exception)
            {
                return;
            }
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            string url = picker.SelectedItem as string;
            if (!picker.Items.Contains(url))
                picker.Items.Add(url.Replace("https://", ""));
            webView.Source = new UrlWebViewSource { Url = "https://" + url };
        }
    }
}