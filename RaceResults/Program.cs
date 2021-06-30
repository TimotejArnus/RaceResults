using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;


namespace RaceResults
{
    class Program
    {


        static void Main(string[] args)
        {


            TimeSpan cas = new TimeSpan();  // Za merjnje casa branja; 
            TimeSpan trenutnicas = new TimeSpan();  // Za merjnje casa branja; 
            DateTime konecMerjanja = new DateTime();
            DateTime zacetekMerjenja = DateTime.Now;



            var pathIronMan =
                @"D:\Namizje\Mape Namizja\Šola\2. Letnik\2. Semester\Orodja za razvoj aplikacij\Naloga 1 Nacrtovanje Projekta\Race-Results\IRONMAN\CSV";
            var i = new DirectoryInfo(pathIronMan);

            var pathIronMan70 =
                @"D:\Namizje\Mape Namizja\Šola\2. Letnik\2. Semester\Orodja za razvoj aplikacij\Naloga 1 Nacrtovanje Projekta\Race-Results\IRONMAN70.3\CSV";
            var i70 = new DirectoryInfo(pathIronMan70);

            var pathTriaThlon =
                @"D:\Namizje\Mape Namizja\Šola\2. Letnik\2. Semester\Orodja za razvoj aplikacij\Naloga 1 Nacrtovanje Projekta\Race-Results\Ultra-triathlon\CSV";
            var tt = new DirectoryInfo(pathTriaThlon);



            foreach (var file in i.GetFiles("*.csv"))   // IRONMAN    Po stevilu v prvi vrsti
            {
                var reader = new StreamReader(file.FullName);
                var DataLength = reader.ReadLine().Split(',').Length;  // prebere prvo vrstico ki je redundantna
                var listCompetitors = new List<Competitor>();

                var Raceid = Race.addRace(file.Name, Race.category.IronMan);

                while (!reader.EndOfStream)
                {
                    var listCompetitor = new List<Competitor>();
                    var line = reader.ReadLine();
                    var value = line.Split(',');

                    var competitor = Competitor.CreateCompetitor(value, DataLength);
                    listCompetitors.Add(competitor);
                }

                DB.insrtIntoToDB(listCompetitors, Raceid);

                Console.WriteLine(file.Name);
            }

            konecMerjanja = DateTime.Now;
            trenutnicas += konecMerjanja - zacetekMerjenja;
            cas = konecMerjanja - zacetekMerjenja;
            Console.WriteLine("cas:  {0},skupenj cas:  {1}", trenutnicas, cas);


            foreach (var file in i70.GetFiles("*.csv"))   // IRONMAN70,3
            {
                var reader = new StreamReader(file.ToString());
                var DataLength = reader.ReadLine().Split(',').Length;  // prebere prvo vrstico ki je redundantna
                var listCompetitors = new List<Competitor>();

                var Raceid = Race.addRace(file.Name, Race.category.IronMan70);

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var value = line.Split(',');

                    Competitor competitor = Competitor.CreateCompetitor(value, DataLength);
                    listCompetitors.Add(competitor);
                }

                DB.insrtIntoToDB(listCompetitors,Raceid);

                Console.WriteLine(file.Name);
            }

            konecMerjanja = DateTime.Now;
            trenutnicas += konecMerjanja - zacetekMerjenja;
            cas = konecMerjanja - zacetekMerjenja;
            Console.WriteLine("cas:  {0},skupenj cas:  {1}", trenutnicas, cas);

            foreach (var file in tt.GetFiles("*.csv"))   // Thriathlon
            {
                var reader = new StreamReader(file.ToString());
                var data = reader.ReadLine().Split(',');  // prebere prvo vrstico ki je redundantna

                var listCompetitors = new List<Competitor>();

                var Raceid = Race.addRace(file.Name, Race.category.IronMan70);

                if (data[0] == "Double")
                {
                    Race.addRace(file.Name,Race.category.TriathlonDouble);
                }
                else if (data[0] == "Triple")
                {
                    Race.addRace(file.Name, Race.category.TriathlonDouble);
                }
                else
                {
                    Race.addRace(file.Name, Race.category.Other);
                }

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var value = line.Split(',');

                    Competitor competitor = Competitor.CreateCompetitor(value, data.Length);
                    listCompetitors.Add(competitor);
                }

                DB.insrtIntoToDB(listCompetitors, Raceid);

                Console.WriteLine(file.Name);
            }

            konecMerjanja = DateTime.Now;
            trenutnicas += konecMerjanja - zacetekMerjenja;
            cas = konecMerjanja - zacetekMerjenja;
            Console.WriteLine("cas:  {0},skupenj cas:  {1}", trenutnicas, cas);

            
            Console.ReadLine();





            //SqlConnection conn = new SqlConnection(
            //    new SqlConnectionStringBuilder()
            //    {
            //        DataSource = "DESKTOP-4E2BO4S",
            //        InitialCatalog = "race_results",
            //        UserID = "root",
            //        Password = "geslo"
            //    }.ConnectionString
            //);


            //// SqlConnection cnn = new SqlConnection(connectionString);
            //conn.Open();
            //Console.WriteLine("Connection Open!");

            //conn.Close();

            // Connect to SQLite




        }
    }
}
