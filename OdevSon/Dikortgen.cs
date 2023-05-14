using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdevSon
{
    public class Dikortgen
    {
        point m;
        int en;
        int boy;

        public Dikortgen()
        {
            M = new point();
            En = 0;
            Boy = 0;
        }

        public Dikortgen(point p,int en,int boy)
        {
            M =p;
            En = en;
            Boy = boy;

        }
        public point M
        {
            get => m; 
            set => m = value;
        }
        public int En
        {
            get => en;
            set => en = value;
        }

        public int Boy
        {
            get => boy;
            set => boy = value;
        }
    }
}
