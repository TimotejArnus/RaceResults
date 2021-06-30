using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceResults
{
    public class Competitor
    {
        static int stevec = 0;
        public int id { get; set; }
        public string name { get; set; }
        public int genderRank { get; set; }
        public int divRank { get; set; }
        public int overallRank { get; set; }
        public int bib { get; set; }
        public string division { get; set; }    //TODO: 38-40 naredi tip od do ..;
        public string age { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string profession { get; set; }
        public int points { get; set; }
        public TimeSpan swim { get; set; }
        public TimeSpan t1 { get; set; }
        public TimeSpan bike { get; set; }
        public TimeSpan t2 { get; set; }
        public TimeSpan run { get; set; }
        public TimeSpan overall { get; set; }
        public string comment { get; set; }

        
        public static Competitor CreateCompetitor(string[] value, int DataLength)
        {
            Competitor competitor = new Competitor();
            stevec++;

            if (value.Length >= DataLength) // Ce je podatkov v tabeli manj kot jih mora biti v eni vrstici 
            {
                //
            }
            else
            {
                string[] newvalue = new string[20];
                List<Competitor> novList = new List<Competitor>();
                for (int i = 0; i < DataLength; i++)    // Potrebna Sprememba ce se menja stevilo podatkov
                {
                    if (i < value.Length)
                    {
                        newvalue[i] = value[i];
                    }
                    else
                    {
                        newvalue[i] = "---";    // Ce je vrednosti manj vnesemo string, ki je brez pomena 
                    }
                }

                value = newvalue; // Value Popravljeno -> s 20 podatki 
            }

            if (DataLength >= 20)
            {
                competitor.id = stevec;
                competitor.name = value[0];
                competitor.genderRank = ConvertToInt(value[1]);  // TODO Prilagodi !!!
                competitor.divRank = ConvertToInt(value[2]);
                competitor.overallRank = ConvertToInt(value[3]);
                competitor.bib = ConvertToInt(value[4]);
                competitor.division = value[5];
                competitor.age = value[6];
                competitor.state = value[7];
                competitor.country = value[8];
                competitor.profession = value[9];
                competitor.points = ConvertToInt(value[10]);
                competitor.swim = ConvertToDateTime(value[11]);
                //competitor.swimDistance = value[12];     // Napaka zaradi Mi
                competitor.t1 = ConvertToDateTime(value[13]);
                competitor.bike = ConvertToDateTime(value[14]);
                //competitor.bikeDistance = value[15];
                competitor.t2 = ConvertToDateTime(value[16]);
                competitor.run = ConvertToDateTime(value[17]);
                //competitor.runDistance = value[18];
                competitor.overall = ConvertToDateTime(value[19]);
            }
            else
            {
                competitor.id = stevec;
                competitor.divRank = ConvertToInt(value[0]);
                competitor.overallRank = ConvertToInt(value[1]);
                competitor.name = value[2];
                competitor.country = value[3];
                competitor.age = value[4];
                competitor.swim = ConvertToDateTime(value[5]);
                competitor.t1 = ConvertToDateTime(value[6]);
                competitor.bike = ConvertToDateTime(value[7]);
                competitor.t2 = ConvertToDateTime(value[8]);
                competitor.run = ConvertToDateTime(value[9]);
                competitor.overall = ConvertToDateTime(value[10]);
                competitor.comment = value[11];
            }




            return competitor;
        }
        public static int ConvertToInt(string value)
        {
            int a = 0;
            int.TryParse(value, out a);
            return a;
        }

        public static TimeSpan ConvertToDateTime(string value)
        {
            TimeSpan a = TimeSpan.MinValue;
            TimeSpan.TryParse(value, out a);
            return a;
        }
    }
}
