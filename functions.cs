using System;
using System.Threading;
using MySql.Data.MySqlClient;

namespace Functions
{
    public class Function
    {

        public string connectmysql(){
            return @"server=192.168.0.2;userid=wsm;password=wsm1234;database=salon";
        }
        public void CheckVersion(){

            using var con = new MySqlConnection(connectmysql());

            con.Open();
            

            Console.WriteLine($"MySQL version : {con.ServerVersion}");

            con.Close();


        }
        public void search(){

            Console.Clear();

            using var con = new MySqlConnection(connectmysql());
            con.Open();

            Console.WriteLine("Podaj marke");
            string marka = Console.ReadLine();

            Console.WriteLine("Podaj model");
            string model = Console.ReadLine();

            Console.WriteLine("Podaj rocznik");
            string rocznik = Console.ReadLine();


            string sql = ($"SELECT * FROM car WHERE producent='{marka}' AND model='{model}' AND rok='{rocznik}'");
            using var cmd = new MySqlCommand(sql, con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            int counter=0;

            while (rdr.Read())
            {
                    
                Console.WriteLine("{0}. {2} {1}",rdr.GetString(0), rdr.GetString(1), rdr.GetString(2));
                counter++;
            }

            if(counter==0){

                Console.WriteLine("Nie odnaleziono samochodu spelniajacego kryteria");
                Thread.Sleep(4000);
                search();
            }

            Console.WriteLine("Wybierz numer samochodu");
            string id_car= Console.ReadLine();
            con.Close();

            inter_car(id_car);

        }

        public void add(){

                




        }
        public void inter_car(string id){

            Console.Clear();

            using var con = new MySqlConnection(connectmysql());
            con.Open();

            string sql = ($"SELECT * FROM car WHERE id='{id}'");
            using var cmd = new MySqlCommand(sql, con);
            using MySqlDataReader rdr = cmd.ExecuteReader();

            rdr.Read();
            Console.WriteLine("Wybrales: \n{0} {1} \nRok {2} Przebieg {3} Km ", rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4));



        }

    }
}

