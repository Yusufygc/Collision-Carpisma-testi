using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdevSon
{
    public class Silindir
    {
        point3d m;
        int r;
        int h;

        public Silindir()
        {
            M = new point3d();
            R = 0;
            H = 0;
        }

        public Silindir(point3d _m, int _r, int _h)
        {
            M = _m;
            R = _r;
            H  = _h;
        }

        public point3d M
        {
            get => m; set => m = value;
        }

        public int R
        {
            get => r;
            set => r = value;
        }
        public int H
        {
            get => h; set => h = value;
        }
    }
}
