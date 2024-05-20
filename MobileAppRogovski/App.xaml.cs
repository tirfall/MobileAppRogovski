using System;
using Xamarin.Forms;
using Rg.Plugins.Popup;
using Xamarin.Forms.Xaml;

namespace MobileAppRogovski
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new startpage1());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
