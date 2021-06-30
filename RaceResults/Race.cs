using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceResults
{
    class Race
    {
        private static int stevec = 0;
        public int id { get; set; }
        

        public enum category
        {
            Other,
            IronMan,
            IronMan70,
            TriathlonDouble,
            TriathlonTriple
        }

        public category Category { get; set; }
        public string name { get; set; }
        public double swimDistance { get; set; }    // V KM
        public double bikeDistance { get; set; }
        public double runDistance { get; set; }

        List<Race> listraces = new List<Race>();

        static public int addRace(string filename, category cat)
        {
            stevec++;
            Race race = new Race();
            race.id = stevec;
            race.name = filename;
            race.Category = cat;

            if (race.Category == category.IronMan)
            {
                race.swimDistance = 3.86;
                race.bikeDistance = 180.25;
                race.runDistance = 42.2;
            }
            else if(race.Category == category.IronMan70) 
            {
                race.swimDistance = 1.9;
                race.bikeDistance = 90;
                race.runDistance = 21;
            }
            else if(race.Category == category.TriathlonDouble)
            {
                race.swimDistance = 7.6;
                race.bikeDistance = 360;
                race.runDistance = 84.4;
            }
            else if (race.Category == category.TriathlonTriple)
            {
                race.swimDistance = 11.4;
                race.bikeDistance = 540;
                race.runDistance = 126.6;
            }
            else
            {
                race.swimDistance = 0;
                race.bikeDistance = 0;
                race.runDistance = 0;
            }

            DB.insertintoRace(race);

            return race.id;
        }
    }
}
