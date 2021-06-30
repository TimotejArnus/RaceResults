using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceResults
{
 
    class Belezenje
    {
        private string mapa;
        private TimeSpan porabljenCas;

        static List<Belezenje> list = new List<Belezenje>();
        private static TimeSpan skupenjCas = TimeSpan.Zero;

        
        static public DateTime Zabelezi(string mapa, DateTime casZacetka)
        {
            var casKonca = DateTime.Now;
            var zabelezij = new Belezenje();
            zabelezij.mapa = mapa;
            zabelezij.porabljenCas = casKonca - casZacetka;
            list.Add(zabelezij);
            skupenjCas += zabelezij.porabljenCas;

            return DateTime.Now;
        }

        static public void ZapisiVTxt()
        {
            StreamWriter writer = new StreamWriter(@"D:\Desktop\test\porabaCasa.txt");

            foreach (var podatek in list)
            {
                writer.WriteLine(podatek.mapa + '\t' + podatek.porabljenCas + '\n');
                
            }

            writer.WriteLine("skupaj :  " + skupenjCas);

            writer.Close();
        }

        

       
    }
}
