using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Savarankiskas1
{
    class RaidziuDazniai
    {
        private const int CMax = 500;
        private int[] Rn; // raidžių pasikartojimai
        public string eil;
        public char[] simboliai { get; private set; }
        public RaidziuDazniai()
        {
            eil = "";
            simboliai = new char[32] { 'a', 'ą', 'b', 'c', 'č', 'd', 'e', 'ę', 'ė', 'f', 'g', 'h', 'i', 'į', 'y', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'r', 's', 'š', 't', 'u', 'ų', 'ū', 'v', 'z', 'ž' };
            Rn = new int[CMax];
            for (int i = 0; i < simboliai.Length; i++)
                Rn[simboliai[i]] = 0;
        }
        public int Imti(char sim) { return Rn[sim]; }

        public void kiek()
        {
            for (int i = 0; i < eil.Length; i++)
            {
                for (int j = 0; j < simboliai.Length; j++)
                {
                    if (eil[i] == simboliai[j] || eil[i] == Char.ToUpper(simboliai[j]))
                    {
                        Rn[eil[i]]++;
                    }
                }
            }
        }
    }
    internal class Program
    {
        const string CFd = "U1.txt";
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.GetEncoding(1257);
            Console.OutputEncoding = Encoding.UTF8;

            RaidziuDazniai eil = new RaidziuDazniai();

            Dazniai(CFd, eil);
            Spausdinti(eil);
        }
        static void Spausdinti(RaidziuDazniai eil)
        {
            Console.WriteLine("\nLietuviškos abėcėlės raidės ir jų pasikartojimai tekste:");
            for (int i = 0; i < eil.simboliai.Length; i++)
            {
                char simbolis = eil.simboliai[i];
                Console.WriteLine("{0, 3:c} {1, 4:d} |{2, 3:c} {3, 4:d}", simbolis, eil.Imti(simbolis), Char.ToUpper(simbolis), eil.Imti(Char.ToUpper(simbolis)));
            }
        }
        static void Dazniai(string fv, RaidziuDazniai eil)
        {
            using (StreamReader reader = new StreamReader(fv))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    eil.eil = line;
                    eil.kiek();
                }
            }
        }
    }
}
