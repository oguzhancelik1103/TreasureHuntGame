using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.DinamikEngel
{
    public class Kuslar
    {
        public string Tur { get; set; }
        public Size Boyut { get; set; }
        public int YukariSinir { get; set; }
        public int AsagiSinir { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Kuslar(string tur, Size boyut, int yukariSinir, int asagiSinir)
        {
            Tur = tur;
            Boyut = boyut;
            YukariSinir = yukariSinir;
            AsagiSinir = asagiSinir;
            X = 0; // Başlangıçta X koordinatı
            Y = 0; // Başlangıçta Y koordinatı
        }

        public void HareketEt()
        {
            Random rastgele = new Random();
            int rastgeleYon = rastgele.Next(0, 2); // 0: Yukarı, 1: Aşağı

            if (rastgeleYon == 0 && Y > YukariSinir)
            {
                Y--; // Yukarı hareket
            }
            else if (rastgeleYon == 1 && Y < AsagiSinir)
            {
                Y++; // Aşağı hareket
            }
        }
    }
}

