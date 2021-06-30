using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;


namespace RaceResults
{
    class DB
    {
        private static string path = @"data source=D:\Namizje\sqlite\race.db";
        static SQLiteConnection conn = new SQLiteConnection(path);

        static public void insrtIntoToDB(List<Competitor> listcompatitor, int Raceid)
        {
            //PRAGMA foreign_keys = Off;

            //DELETE from Race;
            //DELETE from RezultatTekme;
            //DELETE from competitor;

            //SELECT* from competitor;

            var stevec = 0;
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(conn);
            
                foreach (var competitor in listcompatitor)
                {
                    stevec++;

                    cmd.CommandText = // Competitor table
                        "INSERT INTO competitor VALUES(" + competitor.id + "," + "'" + competitor.name + "'" + "," + "'" + competitor.division + "'" + "," +
                        "'" + competitor.age + "'" + "," + "'" + competitor.state + "'" + "," + "'" + competitor.country + "'" + "," + "'" +
                        competitor.profession + "'" + ");";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = // RaceResults table
                        @"INSERT INTO RezultatTekme VALUES(null," + competitor.genderRank + "," + competitor.divRank +
                        "," + competitor.overallRank + "," + competitor.bib + "," + competitor.points + "," +
                        "'" + competitor.swim + "'" + "," + "'" + competitor.t1 + "'" + "," + "'" + competitor.bike + "'" + "," + "'" + competitor.t2 + "'" + "," +
                        "'" + competitor.run + "'" + "," + "'" + competitor.overall + "'" + "," + "'" + competitor.comment + "'" + "," +
                        competitor.id +"," + Raceid +");";
                    cmd.ExecuteNonQuery();

                    Console.WriteLine("{0}  {1}",stevec,competitor.name);
                 
                }
            

            
            conn.Close();
        }

        static public void insertintoRace(Race race)
        {

            //var va = race.swimDistance.ToString();  /* spremeni , v . da ne povzroci napake v sql*/

            conn.Open();
            string comand = "INSERT INTO Race VALUES(" + race.id + "," + "'" + race.name + "'" + "," + "'" +
                            race.Category + "'" + "," + race.swimDistance.ToString(System.Globalization.CultureInfo.InvariantCulture) + "," + race.bikeDistance.ToString(System.Globalization.CultureInfo.InvariantCulture) + "," + race.runDistance.ToString(System.Globalization.CultureInfo.InvariantCulture) + ");";
            using (SQLiteCommand cmd = new SQLiteCommand(conn))
            {
                cmd.CommandText = comand;
                    

                cmd.ExecuteNonQuery();
            }

            //INSERT INTO Race VALUES(1,'avstrija','IronMan','34','44','32');
            //INSERT INTO Race VALUES(2,'maldonesia','IronMan70','24','34','12');
            //INSERT INTO Race VALUES(3,'spanija','IronMan','34','44','32');


            conn.Close();
        }

        
    }



}

