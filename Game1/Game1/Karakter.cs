using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class Karakter
    {
        public int ID { get; set; }
        public string Ad { get; set; }
        public Lokasyon Konum { get; set; }

        public Karakter(int id, string ad, Lokasyon konum)
        {
            ID = id;
            Ad = ad;
            Konum = konum;
        }

        // Karakterin koordinatlarını güncelleyen metot
        public void SetKonum(Lokasyon yeniKonum)
        {
            Konum = yeniKonum;
        }

        // Karakterin koordinatlarını döndüren metot
        public Lokasyon GetKonum()
        {
            return Konum;
        }

        // Karakterin en kısa yolunu hesaplayan metot
        public Lokasyon EnKisaYol(Lokasyon hedef)
        {
            // Çapraz hareketi engelleyen kodlar
            int deltaX = hedef.X - Konum.X;
            int deltaY = hedef.Y - Konum.Y;
            if (Math.Abs(deltaX) > Math.Abs(deltaY))
            {
                return new Lokasyon(Konum.X + Math.Sign(deltaX), Konum.Y);
            }
            else
            {
                return new Lokasyon(Konum.X, Konum.Y + Math.Sign(deltaY));
            }
        }
    }
}
