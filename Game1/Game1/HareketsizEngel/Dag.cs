using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.HareketsizEngel
{
    public class Dag
    {
        public string Tur { get; set; }
        public Size Boyut { get; set; }

        public Dag(string tur, Size boyut)
        {
            Tur = tur;
            Boyut = boyut;
        }
    }
}
