using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdevSon
{
    public class Cember
    {
        point m;
        int r;

        public Cember()
        {
            M= new point();
            R=0;
        }

        public Cember(point m, int r)
        {
            M = m;
            R= r; 
        }

        public point M 
        { 
            get => m;
            set => m = value;
        }

        public int R
        {
            get => r;
            set => r = value;
        }

    }
}
