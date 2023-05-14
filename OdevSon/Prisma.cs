using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdevSon
{
    public class Prisma
    {
        point3d m;
        int boy;
        int en1;
        int en2;

        public Prisma()
        {
            M = new point3d();
            Boy = 0;
            En1 = 0;
            En2= 0;
        }

        public Prisma(point3d _m, int _boy, int _en1, int _en2)
        {
            M = _m;
            Boy = _boy;
            En1 = _en1;
            En2 = _en2;
        }

        public point3d M
        {
            get => m; set => m = value;
        }

        public int Boy
        {
            get => boy; set => boy = value;
        }
        public int En1
        {
            get => en1; set => en1 = value;
        }

        public int En2
        {
            get => en2; set => en2 = value;
        }
    }
}
