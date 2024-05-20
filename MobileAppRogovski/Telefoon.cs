using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.IO;

namespace MobileAppRogovski
{
    public class Telefoon
    {
        public string Nimetus { get; set; }
        public string Tootja { get; set; }
        public int Hind { get; set; }
        public ImageSource Pilt { get; set; }

        public Telefoon(string nimetus, string tootja, int hind, byte[] pilt)
        {
            Nimetus = nimetus;
            Tootja = tootja;
            Hind = hind;
            Pilt = ImageSource.FromStream(() => new MemoryStream(pilt));
        }
        public Telefoon(string nimetus, string tootja, int hind, ImageSource pilt)
        {
            Nimetus = nimetus;
            Tootja = tootja;
            Hind = hind;
            Pilt = pilt;
        }
        public Telefoon(string nimetus, string tootja, int hind)
        {
            Nimetus = nimetus;
            Tootja = tootja;
            Hind = hind;
            Pilt = ImageSource.FromStream(() => new MemoryStream(Properties.Resources.white));
        }
    }
}
