using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class Uygulama
    {
        public int AdimSayisi { get; private set; }
        public List<string> EldeEdilenNesneler { get; private set; }

        public Uygulama()
        {
            AdimSayisi = 0;
            EldeEdilenNesneler = new List<string>();
        }

        // Karakterin adım sayısını artıran metot
        public void AdimArtir()
        {
            AdimSayisi++;
        }

        // Elde edilen nesneler listesine nesne ekleyen metot
        public void NesneEkle(string nesne)
        {
            EldeEdilenNesneler.Add(nesne);
        }

        // Uygulama bilgilerini ekrana yazdıran metot
        public void BilgileriGoster()
        {
            Console.WriteLine("Karakterin Hedefe Ulaşma Adım Sayısı: " + AdimSayisi);
            Console.WriteLine("Elde Edilen Nesneler:");
            foreach (var nesne in EldeEdilenNesneler)
            {
                Console.WriteLine("- " + nesne);
            }
        }
    }
}
