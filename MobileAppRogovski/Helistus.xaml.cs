using Plugin.Messaging;
using System;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileAppRogovski
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Helistus : ContentPage
    {
        readonly TableView tableView;
        readonly SwitchCell sc;
        readonly ImageCell ic;
        readonly TableSection fotosection;
        readonly ImageButton helista, sms, email;
        public Helistus()
        {
            Title = "Sms, Email, Helistus leht";
            sc = new SwitchCell { Text = "Näita veel" };
            sc.OnChanged += Sc_OnChanged;
            ic = new ImageCell
            {
                ImageSource = ImageSource.FromStream(() => new MemoryStream(Properties.Resources.user)),
                Text = "Sõbra nimi: ",
                Detail = "Tel.number: | Email:",
            };
            fotosection = new TableSection();
            helista = new ImageButton
            {
                HeightRequest = 50,
                WidthRequest = 50,
                Source = ImageSource.FromStream(() => new MemoryStream(Properties.Resources.tel)),
                BackgroundColor = Color.MintCream,
            };
            helista.Clicked += Helista_Clicked;
            sms = new ImageButton
            {
                HeightRequest = 50,
                WidthRequest = 50,
                Source = ImageSource.FromStream(() => new MemoryStream(Properties.Resources.sms)),
                BackgroundColor = Color.MintCream,
            };
            sms.Clicked += Sms_Clicked;
            email = new ImageButton
            {
                HeightRequest = 50,
                WidthRequest = 50,
                Source = ImageSource.FromStream(() => new MemoryStream(Properties.Resources.email)),
                BackgroundColor = Color.MintCream,
            };
            email.Clicked += Email_Clicked;
            tableView = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot("Andmete sisetamine")
                {
                    new TableSection("Nimi")
                    {
                        new EntryCell
                        {
                            Label="Nimi: ",
                            Placeholder="Sisesta oma sõbra nimi"
                        }
                    },
                    new TableSection("Kontaktid")
                    {

                        new EntryCell
                        {
                            Label="Telefon: ",
                            Placeholder="Sisesta telefomi number",
                            Keyboard = Keyboard.Telephone
                        },
                        new EntryCell
                        {
                            Label="Email: ",
                            Placeholder="Sisesta email",
                            Keyboard = Keyboard.Email
                        },
                    },
                    new TableSection("Sõnum")
                    {
                        new EntryCell
                        {
                            Label="Sõnumi teema: ",
                            Placeholder="Sisesta sõnumi teema",
                            Keyboard = Keyboard.Text
                        },
                        new EntryCell
                        {
                            Label="Sõnum: ",
                            Placeholder="Sisesta sõnum",
                            Keyboard = Keyboard.Text
                        },
                        sc
                    },
                    fotosection,
                    new TableSection
                    {
                        new ViewCell
                        {
                            View = helista
                        },
                        new ViewCell
                        {
                            View = sms
                        },
                        new ViewCell
                        {
                            View = email
                        },
                    }
                }
            };
            Content = tableView;
        }

        private void Email_Clicked(object sender, EventArgs e)
        {
            var smsMessenger = CrossMessaging.Current.EmailMessenger;
            if (smsMessenger.CanSendEmail)
            {
                string smsteema = ((EntryCell)tableView.Root[2][0]).Text;
                string sms = ((EntryCell)tableView.Root[2][1]).Text;
                string email = ((EntryCell)tableView.Root[1][1]).Text;
                smsMessenger.SendEmail(email, smsteema, sms);
            }
        }

        private void Sms_Clicked(object sender, EventArgs e)
        {
            var smsMessenger = CrossMessaging.Current.SmsMessenger;
            if (smsMessenger.CanSendSms)
            {
                string smsteema = ((EntryCell)tableView.Root[1][2]).Text;
                string sms = ((EntryCell)tableView.Root[1][3]).Text;
                string number = ((EntryCell)tableView.Root[1][0]).Text;
                smsMessenger.SendSms(number, smsteema == string.Empty ? sms : $"{smsteema}: {sms}");
            }
        }

        private async void Helista_Clicked(object sender, EventArgs e)
        {
            try
            {
                string number = ((EntryCell)tableView.Root[1][0]).Text;
                if (!string.IsNullOrWhiteSpace(number))
                    await Launcher.OpenAsync(new Uri("tel:" + number));
                else
                    await DisplayAlert("Viga", "Palun sisesta õige tel. number", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Viga", ex.Message, "OK");
            }
        }

        private void Sc_OnChanged(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                fotosection.Title = "Info";
                ic.Text = $"Sõbra nimi: {((EntryCell)tableView.Root[0][0]).Text ?? "Ei leidnud"}";
                ic.Detail = $"Tel.number: {((EntryCell)tableView.Root[1][0]).Text ?? "Ei leidnud"} | Email: {((EntryCell)tableView.Root[1][1]).Text ?? "Ei leidnud"}";
                fotosection.Add(ic);
                sc.Text = "Peida";
            }
            else
            {
                fotosection.Title = string.Empty;
                fotosection.Remove(ic);
                sc.Text = "Näita veel";
            }
        }
    }
}