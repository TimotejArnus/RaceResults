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

            DB.ConnectToSQLDataBase();
            //TimeSpan cas = new TimeSpan();  // Za merjnje casa branja; 
            //TimeSpan trenutnicas = new TimeSpan();  // Za merjnje casa branja; 
            //DateTime konecMerjanja = new DateTime();
            DateTime zacetekMerjenja = DateTime.Now;



            var pathIronMan =
                @"D:\Namizje\Mape Namizja\Šola\2. Letnik\2. Semester\Orodja za razvoj aplikacij\Naloga 1 Nacrtovanje Projekta\Podatki\Race-Results\Race-Results\IRONMAN\CSV";
            var i = new DirectoryInfo(pathIronMan);

            var pathIronMan70 =
                @"D:\Namizje\Mape Namizja\Šola\2. Letnik\2. Semester\Orodja za razvoj aplikacij\Naloga 1 Nacrtovanje Projekta\Podatki\Race-Results\Race-Results\IRONMAN70.3\CSV";
            var i70 = new DirectoryInfo(pathIronMan70);

            var pathTriaThlon =
                @"D:\Namizje\Mape Namizja\Šola\2. Letnik\2. Semester\Orodja za razvoj aplikacij\Naloga 1 Nacrtovanje Projekta\Podatki\Race-Results\Race-Results\Ultra-triathlon\CSV";
            
            
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

                    for (int j = 0; j < value.Length; j++)
                    {
                        if (!int.TryParse(value[j], out int n))
                        {
                            string nova = "";
                            for (int k = 0; k < value[j].Length; k++)
                            {

                                if (value[j][k].ToString() == @"""" || value[j][k].ToString() == @"'" || value[j][k].ToString() == @"\")
                                {

                                }
                                else
                                {
                                    nova += value[j][k];
                                }
                            }

                            value[j] = nova;
                        }
                    }

                    var competitor = Competitor.CreateCompetitor(value, DataLength);
                    listCompetitors.Add(competitor);
                }


                Console.WriteLine(file.Name);
                DB.insrtIntoToDB(listCompetitors, Raceid);


            }


            zacetekMerjenja = Belezenje.Zabelezi("IronMan", zacetekMerjenja);
           


            foreach (var file in i70.GetFiles("*.csv"))   // IRONMAN70,3
            {
                var reader = new StreamReader(file.FullName);
                var DataLength = reader.ReadLine().Split(',').Length;  // prebere prvo vrstico ki je redundantna
                var listCompetitors = new List<Competitor>();

                var Raceid = Race.addRace(file.Name, Race.category.IronMan70);

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var value = line.Split(',');

                    for (int j = 0; j < value.Length; j++)
                    {
                        if (!int.TryParse(value[j], out int n))
                        {
                            string nova = "";
                            for (int k = 0; k < value[j].Length; k++)
                            {
                                if (value[j][k].ToString() == @"""" || value[j][k].ToString() == @"'" || value[j][k].ToString() == @"\")
                                {

                                }
                                else
                                {
                                    nova += value[j][k];
                                }
                            }

                            value[j] = nova;
                        }
                    }

                    Competitor competitor = Competitor.CreateCompetitor(value, DataLength);
                    listCompetitors.Add(competitor);
                }

                Console.WriteLine(file.Name);
                DB.insrtIntoToDB(listCompetitors, Raceid);

             

            }

            zacetekMerjenja = Belezenje.Zabelezi("IronMan70", zacetekMerjenja);

           

            foreach (var file in tt.GetFiles("*.csv"))   // Thriathlon
            {
                var reader = new StreamReader(file.FullName);
                var data = reader.ReadLine().Split(',');  // prebere prvo vrstico ki je redundantna

                var racetype = file.ToString().Split('_');
                
                var listCompetitors = new List<Competitor>();

                int Raceid;

                if (racetype[0] == "Double")
                {
                    Raceid = Race.addRace(file.Name,Race.category.TriathlonDouble);
                }
                else if (racetype[0] == "Triple")
                {
                    Raceid = Race.addRace(file.Name, Race.category.TriathlonDouble);
                }
                else
                {
                    Raceid = Race.addRace(file.Name, Race.category.Other);
                }

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var value = line.Split(',');

                    for (int j = 0; j < value.Length; j++)
                    {
                        if (!int.TryParse(value[j], out int n))
                        {
                            string nova = "";
                            for (int k = 0; k < value[j].Length; k++)
                            {
                                
                                if (value[j][k].ToString() == @"""" || value[j][k].ToString() == @"'" || value[j][k].ToString() == @"\")
                                {

                                }
                                else
                                {
                                    nova += value[j][k];
                                }
                            }

                            value[j] = nova;
                        }
                    }



                    Competitor competitor = Competitor.CreateCompetitor(value, data.Length);
                    listCompetitors.Add(competitor);
                }

                Console.WriteLine(file.Name);
                DB.insrtIntoToDB(listCompetitors, Raceid);

              
            }

            zacetekMerjenja = Belezenje.Zabelezi("triathlon", zacetekMerjenja);

            Belezenje.ZapisiVTxt();
            

            
            Console.ReadLine();



        }
    }
}
