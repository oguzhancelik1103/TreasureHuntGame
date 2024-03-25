using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.DinamikEngel
{
    public class Arilar
    {
        public string Tur { get; set; }
        public Size Boyut { get; set; }
        public int SagaSinir { get; set; }
        public int SolaSinir { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Arilar(string tur, Size boyut, int sagaSinir, int solaSinir)
        {
            Tur = tur;
            Boyut = boyut;
            SagaSinir = sagaSinir;
            SolaSinir = solaSinir;
            X = 0; // Başlangıçta X koordinatı
            Y = 0; // Başlangıçta Y koordinatı
        }

        public void HareketEt()
        {
            Random rastgele = new Random();
            int rastgeleYon = rastgele.Next(0, 2); // 0: Sağa, 1: Sola

            if (rastgeleYon == 0 && X < SagaSinir)
            {
                X++; // Sağa hareket
            }
            else if (rastgeleYon == 1 && X > SolaSinir)
            {
                X--; // Sola hareket
            }
        }
    }
}
