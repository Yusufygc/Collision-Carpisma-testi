using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdevSon
{
    public class Yuzey
    {
        float minX;// -
        float maxX;
        float minY;// -
        float maxY;
        float minZ;// -
        float maxZ;


        public Yuzey(float _minX, float _maxX, float _minY, float _maxY, float _minZ, float _maxZ)
        {
            minX = _minX;
            maxX = _maxX;
            minY = _minY;
            maxY = _maxY;
            minZ = _minZ;
            maxZ = _maxZ;

        }

        public float MinX
        {
            get => minX;
            set => minX = value;
        }
        public float MaxX
        {
            get => maxX;
            set => maxX = value;

        }
        public float MinY
        {
            get => minY;
            set => minY = value;
        }
        public float MaxY
        {
            get => maxY;
            set => maxY = value;

        }
        public float MinZ
        {
            get => minZ;
            set => minZ = value;
        }
        public float MaxZ
        {
            get => maxZ;
            set => maxZ = value;

        }
    }
}
