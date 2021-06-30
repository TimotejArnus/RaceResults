using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Interception;
//using System.Data.SqlClient;

//using System.Data.SqlClient;
using System.Linq;
//using System.Data.SqlClient;
//using System.Data.Sql;
using MySql.Data.MySqlClient;
//using MySqlConnector.Core;
//using MySqlConnector.Authentication;
//using MySqlConnector.Logging;
//using MySqlConnector.Protocol;
//using MySqlConnector.Utilities;



namespace RaceResults
{
    class DB
    {
        //private static string path = @"data source=C:\Zacasno\race.db";
        //static SQLiteConnection conn = new SQLiteConnection(path);
        private static MySqlConnection conn { get; set; }

        public static void ConnectToSQLDataBase()
        {
            conn = new MySqlConnection("server=localhost;user id=root;database=ozra;password=root");
           
        }

        static public void insrtIntoToDB(List<Competitor> listcompatitor, int Raceid)
        {
            //pragma foreign_keys = off;

            //delete from race;
            //delete from rezultattekme;
            //delete from competitor;

            //select* from competitor;

            var stevec = 0;
            conn.Open();
            MySqlCommand cmd;

            string query = "";
            //SQLiteCommand cmd = new SQLiteCommand(conn);

            foreach (var competitor in listcompatitor)
            {
                stevec++;
               

                query = // Competitor table
                    "INSERT INTO competitor VALUES(" + competitor.id + "," + '"' + competitor.name + '"' + "," + "'" + competitor.division + "'" + "," +
                    "'" + competitor.state + "'" + "," + "'" + competitor.country + "'" + "," + "'" + competitor.profession + "'" + "," + "'" +
                    competitor.age + "'" + ");";
                // cmd.ExecuteNonQuery();

                cmd = new MySqlCommand(query,conn);
                cmd.ExecuteNonQuery();

                query = // RaceResults table
                    @"INSERT INTO RezultatTekme VALUES(null," + competitor.genderRank + "," + competitor.divRank +
                    "," + competitor.overallRank + "," + competitor.bib + "," + competitor.points + "," +
                    "'" + competitor.swim + "'" + "," + "'" + competitor.t1 + "'" + "," + "'" + competitor.bike + "'" + "," + "'" + competitor.t2 + "'" + "," +
                    "'" + competitor.run + "'" + "," + "'" + competitor.overall + "'" + "," + "'" + competitor.comment + "'" + "," +
                    competitor.id + "," + Raceid + ");";

                cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();

                //Console.WriteLine("{0}  {1}",stevec,competitor.name);



            }



            conn.Close();
        }

        static public void insertintoRace(Race race)
        {

            //var va = race.swimDistance.ToString();  /* spremeni , v . da ne povzroci napake v sql*/


            conn.Open();
            string comand = "INSERT INTO Race VALUES(" + race.id + "," + "'" + race.name + "'" + "," + "'" + race.country +"'" + ","+ race.year + "," + "'" + race.Category + "'" + "," + race.swimDistance.ToString(System.Globalization.CultureInfo.InvariantCulture) + "," + race.bikeDistance.ToString(System.Globalization.CultureInfo.InvariantCulture) + "," + race.runDistance.ToString(System.Globalization.CultureInfo.InvariantCulture) + ");";
            MySqlCommand cmd = new MySqlCommand(comand, conn);
            cmd.ExecuteNonQuery();

            //cmd.CommandText = comand;


            //cmd.ExecuteNonQuery();


            //INSERT INTO Race VALUES(1,'avstrija','IronMan','34','44','32');
            //INSERT INTO Race VALUES(2,'maldonesia','IronMan70','24','34','12');
            //INSERT INTO Race VALUES(3,'spanija','IronMan','34','44','32');


            conn.Close();
        }


    }

    
    

}

