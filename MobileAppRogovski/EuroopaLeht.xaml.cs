using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace MobileAppRogovski
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EuroopaLeht : ContentPage
    {
        ListView listView;
        Label lbl;
        Button Lisa, Kustuta;
        ObservableCollection<Euroopa> riigid = new ObservableCollection<Euroopa> {
            new Euroopa("Eesti","Tallinn",1200000,Properties.Resources.eesti),
            new Euroopa("Rootsi","Stokholm",10500000,Properties.Resources.rootsi),
            new Euroopa("Leedu","Vilnus",2700000,Properties.Resources.leedu),
            new Euroopa("Poola","Warsaw",38000000,Properties.Resources.poola)
            };
        Euroopa selectedRiik;
        public EuroopaLeht()
        {
            Title = "Euroopa riigid leht";
            selectedRiik = riigid[0];
            listView = new ListView
            {
                ItemsSource = riigid,
                Footer = DateTime.Now.ToString("T"),
                ItemTemplate = new DataTemplate(() =>
                {
                    ImageCell ic = new ImageCell { TextColor = Color.White, DetailColor = Color.Pink };
                    ic.SetBinding(ImageCell.TextProperty, "Nimi");
                    Binding companyBinding = new Binding { Path = "Pealinn", StringFormat = "Pealinn - {0}" };
                    ic.SetBinding(ImageCell.DetailProperty, companyBinding);
                    ic.SetBinding(ImageCell.ImageSourceProperty, "Lipp");
                    return ic;
                })
            };
            lbl = new Label
            {
                Text = "Euroopa riigid leht",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };
            listView.ItemTapped += ListView_ItemTapped;
            Lisa = new Button { Text = "Lisa riik" };
            Lisa.Clicked += Lisa_Clicked;
            Kustuta = new Button { Text = "Kustuta riik" };
            Kustuta.Clicked += Kustuta_Clicked;
            this.Content = new StackLayout { Children = { lbl, listView, Lisa, Kustuta } };
            FooterUpdate();
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            selectedRiik = e.Item as Euroopa;
            lbl.Text = selectedRiik.Nimi;
            await DisplayAlert(selectedRiik.Nimi, $"Pealinn - {selectedRiik.Pealinn}, Rahvaarv - {selectedRiik.Rahvaarv}", "Tühista");
        }

        private async void Kustuta_Clicked(object sender, EventArgs e)
        {
            if (selectedRiik != null)
            {
                bool isConfirmed = await DisplayAlert("Kustutamise kinnitus", $"Kas soovite kindlasti kustutada {selectedRiik.Nimi}?", "Kustuta", "Tühista");
                if (isConfirmed)
                {
                    riigid.Remove(selectedRiik);
                    lbl.Text = "Euroopa riigid leht";
                }
            }
            else
            {
                await DisplayAlert("Viga", "Palun valige kustutamiseks üksus", "OK");
            }
            lbl.Text = "Euroopa riigid leht";
        }

        private async void Lisa_Clicked(object sender, EventArgs e)
        {
            string nimi = await DisplayPromptAsync("Nimi", "Kirjuta nimi");
            if (nimi == null)
                return;
            string pealinn = await DisplayPromptAsync("Pealinn", "Kirjuta pealinn");
            if (pealinn == null)
                return;
            string rahvaarv = await DisplayPromptAsync("Rahvaarv", "Kirjuta rahvaarv", keyboard: Keyboard.Numeric);
            if (rahvaarv == null)
                return;
            await CrossMedia.Current.Initialize();
            MediaFile image = await CrossMedia.Current.PickPhotoAsync();
            Euroopa eur = new Euroopa(nimi, pealinn, int.Parse(rahvaarv), ImageSource.FromStream(() => image.GetStream()));
            if (riigid.Any(x => x.Nimi == eur.Nimi))
                return;
            riigid.Add(eur);
        }

        private async void FooterUpdate()
        {
            while (true)
            {
                await Task.Delay(1000);
                Device.BeginInvokeOnMainThread(() =>
                {
                    listView.Footer = DateTime.Now.ToString("T");
                });
            }
        }
    }
}