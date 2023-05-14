using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdevSon
{
    public class Kure
    {
        point3d m;
        int r;
        public Kure() 
        {
            M = new point3d();
            R = 0;
        }

        public Kure(point3d _m, int _r)
        {
            M = _m;
            R = _r;
        }

        public point3d M
        {
            get => m; set => m = value;
        }

        public int R
        { get => r;set => r = value; }


    }
}
