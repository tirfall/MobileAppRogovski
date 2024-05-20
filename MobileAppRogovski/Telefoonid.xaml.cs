using Plugin.Media.Abstractions;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileAppRogovski
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Telefoonid : ContentPage
    {
        
    Label lbl;
    ListView listView;
    ObservableCollection<Telefoon> telefons = new ObservableCollection<Telefoon> {
    new Telefoon("iPhone 10","Apple",500,Properties.Resources.tel),
    new Telefoon("Samsung Note A8", "Samsusng", 300,Properties.Resources.tel),
    new Telefoon("iPhone 12 pro", "Apple", 200,Properties.Resources.tel),
    new Telefoon("iPhone 11", "Apple", 800,Properties.Resources.tel) };
    Telefoon selectedTelefon;
    Button Lisa, Kustuta;
        public Telefoonid()
        {
            Title = "Telefoonid leht";
            listView = new ListView
            {
                ItemsSource = telefons,
                Footer = DateTime.Now.ToString("t"),
                ItemTemplate = new DataTemplate(() =>
                {
                    ImageCell ic = new ImageCell { TextColor = Color.White, DetailColor = Color.Pink };
                    ic.SetBinding(ImageCell.TextProperty, "Nimetus");
                    Binding companyBinding = new Binding { Path = "Tootja", StringFormat = "Tore telefon firmalt {0}" };
                    ic.SetBinding(ImageCell.DetailProperty, companyBinding);
                    ic.SetBinding(ImageCell.ImageSourceProperty, "Pilt");
                    return ic;
                })
            };
            lbl = new Label
            {
                Text = "Telefonide leht",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };
            listView.ItemTapped += ListView_ItemTapped;
            Lisa = new Button { Text = "Lisa telefon" };
            Lisa.Clicked += Lisa_Clicked;
            Kustuta = new Button { Text = "Kustuta telefon" };
            Kustuta.Clicked += Kustuta_Clicked;
            this.Content = new StackLayout { Children = { lbl, listView, Lisa, Kustuta } };
        }

        private async void Kustuta_Clicked(object sender, EventArgs e)
        {
            if (selectedTelefon != null)
            {
                bool isConfirmed = await DisplayAlert("Kustutamise kinnitus", $"Kas soovite kindlasti kustutada {selectedTelefon.Nimetus}?", "Kustuta", "Tühista");
                if (isConfirmed)
                {
                    telefons.Remove(selectedTelefon);
                    lbl.Text = "Euroopa riigid leht";
                }
            }
            else
            {
                await DisplayAlert("Viga", "Palun valige kustutamiseks üksus", "OK");
            }
            lbl.Text = "Telefonide leht";
        }

        private async void Lisa_Clicked(object sender, EventArgs e)
        {
            string nimetus = await DisplayPromptAsync("Nimetus", "Kirjuta nimetus");
            if (nimetus == null)
                return;
            string tootja = await DisplayPromptAsync("Tootja", "Kirjuta tootja");
            if (tootja == null)
                return;
            string hind = await DisplayPromptAsync("Hind", "Kirjuta hind", keyboard: Keyboard.Numeric);
            if (hind == null)
                return;
            await CrossMedia.Current.Initialize();
            MediaFile image = await CrossMedia.Current.PickPhotoAsync();
            Telefoon tel = new Telefoon(nimetus, tootja, int.Parse(hind), ImageSource.FromStream(() => image.GetStream()));
            if (telefons.Any(x => x.Nimetus == tel.Nimetus))
                return;
            telefons.Add(tel);
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            selectedTelefon = e.Item as Telefoon;
            lbl.Text = $"{selectedTelefon.Tootja} | {selectedTelefon.Nimetus} - {selectedTelefon.Hind} eurot";
        }
        
    }
}