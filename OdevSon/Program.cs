/****************************************************************************
** SAKARYA ÜNİVERSİTESİ
** BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
** BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
** PROGRAMLAMAYA GİRİŞİ DERSİ
**
** ÖDEV NUMARASI…...: 1
** ÖĞRENCİ ADI...............: MUHAMMED YUSUF YAĞCI
** ÖĞRENCİ NUMARASI.: B211210017
** DERS GRUBU…………: C
YOUTUBE LİNKİ… …: https://youtube.com/playlist?list=PL49A8BNtm3R0xThhDnXdT0xACJHZ_ehmb
****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OdevSon
{
    public class point
    {
        int x;
        int y;

        public point()
        {
            X = 0;
            Y = 0;
        }

        public point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X
        {
            get => x;
            set => x = value;
        }

        public int Y
        {
            get => y;
            set => y = value;
        }
    }

    public class point3d : point
    {
            int z;

            public point3d()
            {
                Z = 0;
            }

            public point3d(int x,int y,int z)
            {
                Z = z;
            }

            public int Z
            {
                get => z;
                set => z = value;
            }

       

    }

    public static class Carpisma
    {

        //###############################################################################################
        //########  ↓ NOKTA VE DİKDÖRTGEN ÇARPIŞMA KONTROLÜ ↓
        //###############################################################################################
        public static bool noktaDikdortgenCarp(point p,Dikortgen d)
        {
            if (p.X >= d.M.X && p.X <= d.M.X + d.En && p.Y >= d.M.Y && p.Y <= d.M.Y + d.Boy)
            { return true; }
            return false;   
                     
        }
        //###############################################################################################
        //########  ↓ ÇEMBER VE ÇEMBER ÇARPIŞMA KONTROLÜ ↓
        //###############################################################################################
        public static bool cemberCemberCarp(Cember c1,Cember c2) 
        {
            float d = (float)Math.Sqrt(Math.Pow((c1.M.X - c2.M.X), 2) + Math.Pow((c1.M.Y - c2.M.Y), 2));
            if ((c1.R + c2.R) > d)
                return true;
            else
                return false;
        }
        //###############################################################################################
        //########  ↓ DİKDÖRTGEN VE DİKDÖRTGEN ÇARPIŞMA KONTROLÜ ↓
        //###############################################################################################
        public static bool dikdortgenDikdortgenCarp(Dikortgen d1,Dikortgen d2)
        {
            int Xa = d1.M.X + d1.En / 2;
            int Ya = d1.M.Y + d1.Boy / 2;
            int Xb = d2.M.X + d2.En / 2;
            int Yb = d2.M.Y + d2.Boy / 2;
            if (Math.Abs(Xa - Xb) < (d1.En / 2 + d2.En / 2) && Math.Abs(Ya - Yb) < (d1.Boy / 2 + d2.Boy / 2))
                return true;
            else
                return false;
        }
        //###############################################################################################
        //########  ↓ ÇEMBER VE DİKDÖRTGEN ÇARPIŞMA KONTROLÜ ↓
        //###############################################################################################
        public static bool cemberDikdortgenCarp(Cember c1,Dikortgen d1)
        {
            float testX = c1.M.X;
            float testY = c1.M.Y;

            if (c1.M.X < d1.M.X)
                testX = d1.M.X;

            else if (c1.M.X > d1.M.X + d1.En)
                testX = d1.M.X + d1.En;

            if (c1.M.Y < d1.M.Y)
                testY = d1.M.Y;

            else if (c1.M.Y > d1.M.Y + d1.Boy)
                testY = d1.M.Y + d1.Boy;

            float distX = c1.M.X - testX;
            float distY = c1.M.Y - testY;
            float distance = (float)Math.Sqrt((distX * distX) + (distY * distY));

            if (distance<= c1.R)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //###############################################################################################
        //########  ↓ NOKTA VE ÇEMBER ÇARPIŞMA KONTROLÜ ↓
        //###############################################################################################
        public static bool noktaCemberCarp(point p,Cember c1)
        {
            float distX = p.X - c1.M.X;
            float distY = p.Y - c1.M.Y;
            float distance = (float)Math.Sqrt((distX * distX) + (distY * distY));

            if (distance <= c1.R)
            {
                return true;
            }
            return false;
        }
        //###############################################################################################
        //########  ↓ NOKTA VE KÜRE ÇARPIŞMA KONTROLÜ ↓
        //###############################################################################################
        public static bool noktaKureCarp(point3d p,Kure k1) 
        {
            float distance = (float)Math.Sqrt(
               (p.X - k1.M.X) * (p.X - k1.M.X) +
               (p.Y - k1.M.Y) * (p.Y - k1.M.Y) +
                (p.Z - k1.M.Z) * (p.Z - k1.M.Z));

            if (distance < k1.R)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //###############################################################################################
        //########  ↓ NOKTA VE DİKTÖRGEN PRİZMA ÇARPIŞMA KONTROLÜ ↓
        //###############################################################################################
        public static bool noktaDikdortgenPrizmaCarp(point3d p1,Prisma dkp)
        {

            if (p1.X >= dkp.M.X && p1.X <= dkp.M.X + dkp.En1 &&
                p1.Z >= dkp.M.Z && p1.Z <= dkp.M.Z + dkp.En2 &&
                p1.Y >= dkp.M.Y && p1.Y <= dkp.M.Y + dkp.Boy)
            { return true; }
            return false;

        }

        //###############################################################################################
        //######## ↓ NOKTA VE SİLİNDİR ÇARPIŞMA KONTROLÜ ↓
        //###############################################################################################
        public static bool noktaSilindirCarp(point3d p1, Silindir s1)
        {
            if (p1.X >= s1.M.X && p1.X <= s1.M.X + s1.R &&
                p1.Z >= s1.M.Z && p1.Z <= s1.M.Z + s1.R &&
                p1.Y >= s1.M.Y && p1.Y <= s1.M.Y + s1.H / 2)
            { return true; }
            return false;
        }
        //###############################################################################################
        //########  ↓ SİLİNDİR VE SİLİNDİR ÇARPIŞMA KONTROLÜ ↓
        //###############################################################################################
        public static bool silindirSilindirCarp(Silindir s1,Silindir s2)
        {
            point3d pa = new point3d(s1.M.X, s1.M.Y + s1.H / 2, s1.M.Z);
            point3d pb = new point3d(s2.M.X, s2.M.Y + s2.H / 2, s2.M.Z);

            float d = (float)Math.Sqrt(Math.Pow((pa.X - pb.X), 2) +
            Math.Pow((pa.Y - pb.Y), 2) + Math.Pow((pa.Z - pb.Z), 2));

            if ((s1.R + s2.R) > (int)d && Math.Abs(pa.Y - pb.Y) < ((s1.H + s2.H) / 2))
                return true;
            else
                return false;
        }
        //###############################################################################################
        //########  ↓ KÜRE VE KÜRE ÇARPIŞMA KONTROLÜ ↓
        //###############################################################################################
        public static bool kureKureCarp(Kure k1,Kure k2)
        {
            float d = (float)Math.Sqrt(Math.Pow((k1.M.X - k2.M.X), 2) + Math.Pow((k1.M.Y - k2.M.Y), 2) + Math.Pow((k1.M.Z - k2.M.Z), 2));
         
            
            if ((k1.R + k2.R) > (int)d)
                return true;
            else
                return false;
        }
        //###############################################################################################
        //########  ↓ KÜRE VE SİLİNDİR ÇARPIŞMA KONTROLÜ ↓
        //###############################################################################################
        public static bool kureSilindirCarp(Kure q1,Silindir k1) 
        {
            float hipotenüs = (float)Math.Sqrt(Math.Pow((k1.R), 2) + Math.Pow((k1.H / 2), 2));

            float yatay = (float)Math.Sqrt(Math.Pow((q1.M.X - k1.M.X), 2) + Math.Pow((q1.M.Y - k1.M.Y), 2) + Math.Pow((q1.M.Z - k1.M.Z), 2));
            float dikey = (float)Math.Sqrt(Math.Pow((q1.M.X - k1.M.X), 2) + Math.Pow((q1.M.Y - k1.M.Y), 2) + Math.Pow((q1.M.Z - k1.M.Z), 2));
            float capraz = (float)Math.Sqrt(Math.Pow((q1.M.X - k1.M.X), 2) + Math.Pow((q1.M.Y - k1.M.Y), 2) + Math.Pow((q1.M.Z - k1.M.Z), 2));
            if ((q1.R + k1.R) >= yatay || (k1.H / 2 + q1.R) >= dikey || (q1.R + hipotenüs) >= capraz)
            { return true; }
            return false;
        }
        //###############################################################################################
        //########  ↓ KÜRE VE YÜZEY ÇARPIŞMA KONTROLÜ ↓
        //###############################################################################################
        public static bool yuzeyKureCarp(float _minX, float _maxX, float _minY, float _maxY, float _minZ, float _maxZ,Kure k1)
        {
            float closestX = Math.Max(_minX, Math.Min(k1.M.X, _maxX));
            float closestY = Math.Max(_minY, Math.Min(k1.M.Y, _maxY));
            float closestZ = Math.Max(_minZ, Math.Min(k1.M.Z, _maxZ));

            float distance = (float)Math.Sqrt(Math.Pow(closestX - k1.M.X, 2) +
                                              Math.Pow(closestY - k1.M.Y, 2) +
                                              Math.Pow(closestZ - k1.M.Z, 2));
            if (distance <= k1.R)
            {
                return true;
            }

            return false;

        }
        //###############################################################################################
        //########  ↓ DİKDÖRTGEN PRİZMA VE YÜZEY ÇARPIŞMA KONTROLÜ ↓
        //###############################################################################################
        public static bool yuzeyDikdortgenPrizmaCarp(float _minX, float _maxX,float _minY, float _maxY, float _minZ, float _maxZ,Prisma p1)
        {
            // D.Prizmanın yarısı
            float yariGenislik = p1.En1 / 2;
            float yariUzunluk = p1.Boy / 2;
            float yariDerinlik = p1.En2 / 2;

            //d.prizmanın kenarları
            float prizmaMinX = p1.M.X - yariGenislik;
            float prizmaMaxX = p1.M.X + yariGenislik;
            float prizmaMinY = p1.M.Y - yariUzunluk;
            float prizmaMaxY = p1.M.Y + yariUzunluk;
            float prizmaMinZ = p1.M.Z - yariDerinlik;
            float prizmaMaxZ = p1.M.Z + yariDerinlik;

            if (prizmaMinX <= _maxX && prizmaMaxX >= _minX &&
                prizmaMinY <= _maxY && prizmaMaxY >= _minY &&
                prizmaMinZ <= _maxZ && prizmaMaxZ >= _minZ)
            {
                return true;
            }

            return false;

        }
        //###############################################################################################
        //########  ↓ YÜZEY VE SİLİNDİR ÇARPIŞMA KONTROLÜ ↓
        //###############################################################################################
        public static bool yuzeySilindirCarp(float _minX, float _maxX, float _minY, float _maxY, float _minZ, float _maxZ, Silindir s1)
        {
            // Silindirin alt ve üst yüzeylerinin merkez noktalarını hesapla
            float silindirTabanYuzeyi = s1.M.X - (s1.H / 2);
            float silindirUstYuzeyi = s1.M.Y + (s1.H / 2);

            // Silindirin AABB'ini hesapla
            float silindirMinX = s1.M.X - s1.R;
            float silindirMaxX = s1.M.X + s1.R;
            float silindirMinY = silindirTabanYuzeyi;
            float silindirMaxY = silindirUstYuzeyi;
            float silindirMinZ = s1.M.Z - s1.R;
            float silindirMaxZ = s1.M.Z + s1.R;

            // AABB ve yüzey çarpışma tespiti
            if (silindirMinX <= _maxX && silindirMaxX >= _minX &&
                silindirMinY <= _maxY && silindirMaxY >= _minY &&
                silindirMinZ <= _maxZ && silindirMaxZ >= _minZ)
            {
                return true;
            }

            return false;
        }
        //###############################################################################################
        //########  ↓ KÜRE VE DİKTÖRGEN PRİZMA ÇARPIŞMA KONTROLÜ ↓
        //###############################################################################################
        public static bool kureDikdortgenPrizmaCarp(Kure q1,Prisma p1)
        {
            float koseMesafe = (float)Math.Sqrt(Math.Pow((p1.En1 / 2), 2) + Math.Pow((p1.En2 / 2), 2));
            float hipotenüs = (float)Math.Sqrt(Math.Pow((p1.Boy / 2), 2) + Math.Pow((koseMesafe), 2));

            float yatay = (float)Math.Sqrt(Math.Pow((q1.M.X - p1.M.X), 2) + Math.Pow((q1.M.Y - p1.M.Y), 2) + Math.Pow((q1.M.Z - p1.M.Z), 2));
            float dikey = (float)Math.Sqrt(Math.Pow((q1.M.X - p1.M.X), 2) + Math.Pow((q1.M.Y - p1.M.Y), 2) + Math.Pow((q1.M.Z - p1.M.Z), 2));
            float capraz = (float)Math.Sqrt(Math.Pow((q1.M.X - p1.M.X), 2) + Math.Pow((q1.M.Y - p1.M.Y), 2) + Math.Pow((q1.M.Z - p1.M.Z), 2));
            if ((q1.R + p1.En1 / 2) > yatay || (p1.Boy / 2 + q1.R) > dikey || (q1.R + hipotenüs) > capraz)
            { return true; }
            return false;

        }
        //###############################################################################################
        //######## ↓  DİKTÖRGEN PRİZMA VE DİKTÖRGEN PRİZMA ÇARPIŞMA KONTROLÜ ↓
        //###############################################################################################
        public static bool prizmaPrizmaCarp(Prisma p1, Prisma p2) 
        {
            float koseMesafe = (float)Math.Sqrt(Math.Pow((p1.En1 / 2), 2) + Math.Pow((p1.En2 / 2), 2));
            float hipotenüs = (float)Math.Sqrt(Math.Pow((p1.Boy / 2), 2) + Math.Pow((koseMesafe), 2));

            float koseMesafe1 = (float)Math.Sqrt(Math.Pow((p2.En1 / 2), 2) + Math.Pow((p2.En2 / 2), 2));
            float hipotenüs1 = (float)Math.Sqrt(Math.Pow((p2.Boy / 2), 2) + Math.Pow((koseMesafe1), 2));

            float yatay = (float)Math.Sqrt(Math.Pow((p2.M.X - p1.M.X), 2) + Math.Pow((p2.M.Y - p1.M.Y), 2) + Math.Pow((p2.M.Z - p1.M.Z), 2));
            float dikey = (float)Math.Sqrt(Math.Pow((p2.M.X - p1.M.X), 2) + Math.Pow((p2.M.Y - p1.M.Y), 2) + Math.Pow((p2.M.Z - p1.M.Z), 2));
            float capraz = (float)Math.Sqrt(Math.Pow((p2.M.X - p1.M.X), 2) + Math.Pow((p2.M.Y - p1.M.Y), 2) + Math.Pow((p2.M.Z - p1.M.Z), 2));

            if ((p2.En1 / 2 + p1.En1 / 2) > yatay || (p1.Boy / 2 + p2.Boy / 2) > dikey || (hipotenüs1 + hipotenüs) > capraz)
            { return true; }
            return false;

        }
    }
    internal class Program
    {
    static void Main(string[] args)
    {
            MenuYazdır();
            Console.ReadLine();
    }

        static void MenuYazdır()
        {
            Console.WriteLine();
            Console.WriteLine("Hoşgeldiniz");

            Console.WriteLine();

            Console.WriteLine("a) Nokta, Dikdörtgen çarpışma denetimi");
            Console.WriteLine("b) Nokta, çember çarpışma denetimi");
            Console.WriteLine("c) Dikdörtgen, dikdörtgen çarpışma denetimi");
            Console.WriteLine("d) Dikdörtgen, çember çarpışma denetimi");
            Console.WriteLine("e) Çember, çember çarpışma denetimi");
            Console.WriteLine("f) Nokta, Küre çarpışma denetimi");
            Console.WriteLine("g) Nokta, dikdörtgen prizma çarpışma denetimi");
            Console.WriteLine("h) Nokta, Silindir çarpışma denetimi");
            Console.WriteLine("i) Silindir, silindir çarpışma denetimi");
            Console.WriteLine("j) Küre, küre çarpışma denetimi");
            Console.WriteLine("k) Küre silindir çarpışma denetimi");
            Console.WriteLine("l) Yüzey, küre çarpışma denetimi");
            Console.WriteLine("m) Yüzey, dikdörtgen prizma çarpışma denetimi");
            Console.WriteLine("n) Yüzey silindir çarpışma denetimi");
            Console.WriteLine("o) Küre, dikdörtgen prizma çarpışma denetimi");
            Console.WriteLine("p) Dikdörtgen prizma, dikdörtgen prizma çarpışma denetimi");

            Console.WriteLine();
            Console.WriteLine("Çıkış işlemi için'q' ya basınız.");

            Console.WriteLine();

            Console.Write("Lütfen yapmak istediğiniz işlemi seçiniz : ");

            char secim = Convert.ToChar(Console.ReadLine());

            Console.WriteLine();

            do // seçimlerin doğru şekilde yapılmasını yanlış seçim varsa ona göre tekrar tekrar kullanıcıdan veri istenmesini sağlar
            { 
                if (secim == 'q')
                {
                    Environment.Exit(1);
                } // bütün ifler ve diğerleri seçim neyse ona uygun fonksiyonu çalıştırır.
                
                else if (secim == 'a')
                {
                    if (Carpisma.noktaDikdortgenCarp(new point(5, 5), new Dikortgen(new point(2, 2), 5, 5)))
                    {
                        Console.WriteLine("Nokta ve Dikdörtgen çarpışıyor.");
                    }
                    else
                    {
                        Console.WriteLine("Nokta ve Dikdörtgen Çarpışmıyor");
                    }

                    Console.WriteLine();

                    Console.Write("Menüye dönüp işleme devam etmek ister misiniz ? (Evet =1/Hayır =0) :");
                    int devam = Convert.ToInt32(Console.ReadLine());
                    
                   if (devam == 1)
                   {
                       System.Threading.Thread.Sleep(1500);
                       Console.Clear();
                       MenuYazdır();
                   }
                   else if (devam == 0)
                   {
                       Environment.Exit(1);
                   }
                   else
                   {
                       Console.WriteLine("Geçersiz işlem tekrar deneyiniz.");
                   }
                    
                    
                }

                else if (secim == 'b')
                {

                    if (Carpisma.noktaCemberCarp(new point(6,6),new Cember(new point(3, 3), 5)))
                    {
                        Console.WriteLine("Nokta ve çember çarpışıyor");
                    }
                    else
                    {
                        Console.WriteLine("Nokta ve çember çarpışmıyor");
                    }
                    Console.WriteLine();

                    Console.Write("Menüye dönüp işleme devam etmek ister misiniz ? (Evet =1/Hayır =0) :");
                    int devam = Convert.ToInt32(Console.ReadLine());
                    if (devam == 1)
                    {
                        System.Threading.Thread.Sleep(1500);
                        Console.Clear();
                        MenuYazdır();
                    }
                    else if (devam == 0)
                    {
                        Environment.Exit(1);
                    }
    
                }

                else if(secim == 'c')
                {
                    if (Carpisma.dikdortgenDikdortgenCarp(new Dikortgen(new point(2, 2), 5, 5), new Dikortgen(new point(2, 2), 5, 5)))
                    {
                        Console.WriteLine("Dikdörtgenler çarpışıyor");
                    }
                    else
                    {
                        Console.WriteLine("Dikdörtgenler çarpışmıyor");
                    }
                    Console.WriteLine();

                    Console.Write("Menüye dönüp işleme devam etmek ister misiniz ? (Evet =1/Hayır =0) :");
                    int devam = Convert.ToInt32(Console.ReadLine());
                    if (devam == 1)
                    {
                        System.Threading.Thread.Sleep(1500);
                        Console.Clear();
                        MenuYazdır();
                    }
                    else if (devam == 0)
                    {
                        Environment.Exit(1);
                    }

                }

                else if (secim == 'd')
                {

                    if (Carpisma.cemberDikdortgenCarp(new Cember(new point(5,5),10),new Dikortgen(new point(20, 20), 5, 10)))
                    {
                        Console.WriteLine("Çember ve Dikdörtgen çarpışıyor ");
                    }
                    else
                    {
                        Console.WriteLine("Çember ve Dikdörtgen çarpışmıyor ");
                    }

                    Console.WriteLine();

                    Console.Write("Menüye dönüp işleme devam etmek ister misiniz ? (Evet =1/Hayır =0) :");
                    int devam = Convert.ToInt32(Console.ReadLine());
                    if (devam == 1)
                    {
                        System.Threading.Thread.Sleep(1500);
                        Console.Clear();
                        MenuYazdır();
                    }
                    else if (devam == 0)
                    {
                        Environment.Exit(1);
                    }
                }

                else if (secim == 'e')
                {
                    if (Carpisma.cemberCemberCarp(new Cember(new point(10, 10), 5), new Cember(new point(5, 5), 10)))
                    {
                        Console.WriteLine("Çemberler çarpışıyor");
                    }
                    else
                    {
                        Console.WriteLine("Çemberler çarpışmıyor");
                    }
                    Console.WriteLine();

                    Console.Write("Menüye dönüp işleme devam etmek ister misiniz ? (Evet =1/Hayır =0) :");
                    int devam = Convert.ToInt32(Console.ReadLine());
                    if (devam == 1)
                    {
                        System.Threading.Thread.Sleep(1500);
                        Console.Clear();
                        MenuYazdır();
                    }
                    else if (devam == 0)
                    {
                        Environment.Exit(1);
                    }
                }

                else if (secim == 'f')
                {
                    if(Carpisma.noktaKureCarp(new point3d(5,5,5),new Kure(new point3d(10, 10, 10), 4)))
                    {
                        Console.WriteLine("Nokta ve küre çarpışıyor");
                    }
                    else
                    {
                        Console.WriteLine("Nokta ve küre çarpışmıyor");
                    }
                    Console.WriteLine();

                    Console.Write("Menüye dönüp işleme devam etmek ister misiniz ? (Evet =1/Hayır =0) :");
                    int devam = Convert.ToInt32(Console.ReadLine());
                    if (devam == 1)
                    {
                        System.Threading.Thread.Sleep(1500);
                        Console.Clear();
                        MenuYazdır();
                    }
                    else if (devam == 0)
                    {
                        Environment.Exit(1);
                    }
                }

                else if(secim == 'g')
                {
                    if(Carpisma.noktaDikdortgenPrizmaCarp(new point3d(5,5,5),new Prisma(new point3d(10, 10, 10), 20, 10, 15)))
                    {
                        Console.WriteLine("Nokta ve dikdörtgen prizma çarpışıyor");
                    }
                    else
                    {
                        Console.WriteLine("Nokta ve dikdörtgen prizma çarpışmıyor");
                    }
                    Console.WriteLine();

                    Console.Write("Menüye dönüp işleme devam etmek ister misiniz ? (Evet =1/Hayır =0) :");
                    int devam = Convert.ToInt32(Console.ReadLine());
                    if (devam == 1)
                    {
                        System.Threading.Thread.Sleep(1500);
                        Console.Clear();
                        MenuYazdır();
                    }
                    else if (devam == 0)
                    {
                        Environment.Exit(1);
                    }

                }

                else if (secim == 'h')
                {
                    if(Carpisma.noktaSilindirCarp(new point3d(5,5,5),new Silindir(new point3d(6, 6, 6), 10, 20)))
                    {
                        Console.WriteLine("Nokta ve silindir çarpışıyor");
                    }
                    else
                    {
                        Console.WriteLine("Nokta ve silindir çarpışmıyor");
                    }
                    Console.WriteLine();

                    Console.Write("Menüye dönüp işleme devam etmek ister misiniz ? (Evet =1/Hayır =0) :");
                    int devam = Convert.ToInt32(Console.ReadLine());
                    if (devam == 1)
                    {
                        System.Threading.Thread.Sleep(1500);
                        Console.Clear();
                        MenuYazdır();
                    }
                    else if (devam == 0)
                    {
                        Environment.Exit(1);
                    }
                }

                else if (secim == 'i')
                {
                    if(Carpisma.silindirSilindirCarp(new Silindir(new point3d(5,5,5),10,20), (new Silindir(new point3d(10, 10, 10), 10, 20))))
                    {
                        Console.WriteLine("Silindirler çarpışıyor");
                    }
                    else
                    {
                        Console.WriteLine("Silindirler çarpışmıyor");
                    }
                    Console.WriteLine();

                    Console.Write("Menüye dönüp işleme devam etmek ister misiniz ? (Evet =1/Hayır =0) :");
                    int devam = Convert.ToInt32(Console.ReadLine());
                    if (devam == 1)
                    {
                        System.Threading.Thread.Sleep(1500);
                        Console.Clear();
                        MenuYazdır();
                    }
                    else if (devam == 0)
                    {
                        Environment.Exit(1);
                    }
                }

                else if(secim == 'j')
                {
                    if(Carpisma.kureKureCarp(new Kure(new point3d(5,5,5),10), new Kure(new point3d(15, 15, 15), 20)))
                    {
                        Console.WriteLine("Küreler çarpışıyor");
                    }
                    else
                    {
                        Console.WriteLine("Küreler çarpışmıyor");
                    }
                    Console.WriteLine();

                    Console.Write("Menüye dönüp işleme devam etmek ister misiniz ? (Evet =1/Hayır =0) :");
                    int devam = Convert.ToInt32(Console.ReadLine());
                    if (devam == 1)
                    {
                        System.Threading.Thread.Sleep(1500);
                        Console.Clear();
                        MenuYazdır();
                    }
                    else if (devam == 0)
                    {
                        Environment.Exit(1);
                    }
                }

                else if (secim == 'k')
                {
                    if(Carpisma.kureSilindirCarp(new Kure(new point3d(5, 5, 5), 10), new Silindir(new point3d(5, 5, 5), 10, 20)))
                    {
                        Console.WriteLine("Küre ve silindir çarpışıyor");
                    }
                    else
                    {
                        Console.WriteLine("Küre ve silindir çarpışmıyor");
                    }
                    Console.WriteLine();

                    Console.Write("Menüye dönüp işleme devam etmek ister misiniz ? (Evet =1/Hayır =0) :");
                    int devam = Convert.ToInt32(Console.ReadLine());
                    if (devam == 1)
                    {
                        System.Threading.Thread.Sleep(1500);
                        Console.Clear();
                        MenuYazdır();
                    }
                    else if (devam == 0)
                    {
                        Environment.Exit(1);
                    }
                }

                else if (secim == 'l')
                {

                    if (Carpisma.yuzeyKureCarp(-10,10,-10,10,-10,10, new Kure(new point3d(5, 5, 5), 10)))
                    {
                        Console.WriteLine("Küre ve yüzey çarpışıyor");
                    }
                    else
                    {
                        Console.WriteLine("Küre ve yüzey çarpışmıyor");
                    }
                    Console.WriteLine();

                    Console.Write("Menüye dönüp işleme devam etmek ister misiniz ? (Evet =1/Hayır =0) :");
                    int devam = Convert.ToInt32(Console.ReadLine());
                    if (devam == 1)
                    {
                        System.Threading.Thread.Sleep(1500);
                        Console.Clear();
                        MenuYazdır();
                    }
                    else if (devam == 0)
                    {
                        Environment.Exit(1);
                    }
                }

                else if (secim == 'm')
                {
                    if (Carpisma.yuzeyDikdortgenPrizmaCarp(-10, 10, -10, 10, -10, 10, new Prisma(new point3d(5, 5, 5), 20,10,10)))
                    {
                        Console.WriteLine("Dikdörtgen prizma ve yüzey çarpışıyor");
                    }
                    else
                    {
                        Console.WriteLine("Dikdörtgen prizma ve yüzey çarpışmıyor");
                    }
                    Console.WriteLine();

                    Console.Write("Menüye dönüp işleme devam etmek ister misiniz ? (Evet =1/Hayır =0) :");
                    int devam = Convert.ToInt32(Console.ReadLine());
                    if (devam == 1)
                    {
                        System.Threading.Thread.Sleep(1500);
                        Console.Clear();
                        MenuYazdır();
                    }
                    else if (devam == 0)
                    {
                        Environment.Exit(1);
                    }
                }

                else if (secim == 'n')
                {
                    if (Carpisma.yuzeySilindirCarp(-10, 10, -10, 10, -10, 10, new Silindir(new point3d(5, 5, 5), 10, 20)))
                    {
                        Console.WriteLine("Silindir ve yüzey çarpışıyor");
                    }
                    else
                    {
                        Console.WriteLine("Silindir ve yüzey çarpışmıyor");
                    }
                    Console.WriteLine();

                    Console.Write("Menüye dönüp işleme devam etmek ister misiniz ? (Evet =1/Hayır =0) :");
                    int devam = Convert.ToInt32(Console.ReadLine());
                    if (devam == 1)
                    {
                        System.Threading.Thread.Sleep(1500);
                        Console.Clear();
                        MenuYazdır();
                    }
                    else if (devam == 0)
                    {
                        Environment.Exit(1);
                    }
                }

                else if (secim == 'o')
                {
                    if (Carpisma.kureDikdortgenPrizmaCarp(new Kure(new point3d(5, 5, 5), 10), new Prisma(new point3d(10, 10, 10), 20, 10, 15)))
                    {
                        Console.WriteLine("Küre ve dikdörtgen prizma çarpışıyor");
                    }
                    else
                    {
                        Console.WriteLine("Küre ve dikdörtgen prizma çarpışmıyor");
                    }
                    Console.WriteLine();

                    Console.Write("Menüye dönüp işleme devam etmek ister misiniz ? (Evet =1/Hayır =0) :");
                    int devam = Convert.ToInt32(Console.ReadLine());
                    if (devam == 1)
                    {
                        System.Threading.Thread.Sleep(1500);
                        Console.Clear();
                        MenuYazdır();
                    }
                    else if (devam == 0)
                    {
                        Environment.Exit(1);
                    }
                }

                else if (secim == 'p')
                {
                    if (Carpisma.prizmaPrizmaCarp(new Prisma(new point3d(10, 10, 10), 20, 10, 15), new Prisma(new point3d(15, 15, 15), 10, 20, 25)))
                    {
                        Console.WriteLine("dikdörtgen prizma ve dikdörtgen prizma çarpışıyor");
                    }
                    else
                    {
                        Console.WriteLine("dikdörtgen prizma ve dikdörtgen prizma çarpışmıyor");
                    }
                    Console.WriteLine();

                    Console.Write("Menüye dönüp işleme devam etmek ister misiniz ? (Evet =1/Hayır =0) :");
                    int devam = Convert.ToInt32(Console.ReadLine());
                    if (devam == 1)
                    {
                        System.Threading.Thread.Sleep(1500);
                        Console.Clear();
                        MenuYazdır();
                    }
                    else if (devam == 0)
                    {
                        Environment.Exit(1);
                    }
                }




            } while (secim != 'q');

        }

    }
}
