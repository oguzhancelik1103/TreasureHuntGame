using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class Lokasyon
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Lokasyon(int x, int y)
        {
            X = x;
            Y = y;
        }

        // X koordinatını döndüren metot
        public int GetX()
        {
            return X;
        }

        // Y koordinatını döndüren metot
        public int GetY()
        {
            return Y;
        }

        // X koordinatını güncelleyen metot
        public void SetX(int x)
        {
            X = x;
        }

        // Y koordinatını güncelleyen metot
        public void SetY(int y)
        {
            Y = y;
        }
    }
}
