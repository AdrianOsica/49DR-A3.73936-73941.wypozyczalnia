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


            string sql = ($"SELECT * FROM car WHERE producent='{marka}' AND model='{model}' AND rok='{rocznik}' AND status='wolny' ");
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

        public bool add(){

            Console.WriteLine("Dodawanie samochodu");
            
            Console.WriteLine("Podaj marke");
            string marka = Console.ReadLine();

            Console.WriteLine("Podaj model");
            string model = Console.ReadLine();

            Console.WriteLine("Podaj rocznik");
            string rocznik = Console.ReadLine();

            Console.WriteLine("Podaj przebieg");
            string przebieg = Console.ReadLine();

            Console.WriteLine("Podaj cene kupna");
            string cena_kupna = Console.ReadLine();

            Console.WriteLine("Podaj cene wynajmu");
            string cena_wynajmu = Console.ReadLine();

            using var con = new MySqlConnection(connectmysql());
            con.Open();

            string sql = ($"INSERT INTO `car` (`id`, `producent`, `model`, `rok`, `przebieg`, `Cena_kupna`, `Cena_wynajmu`, `status`) VALUES (NULL, '{marka}', '{model}', '{rocznik}', '{przebieg}', '{cena_kupna}', '{cena_wynajmu}', 'wolny');");
            using var cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();

            Console.WriteLine("Dodano do bazy");
            Thread.Sleep(4000);
            Console.Clear();
            return true;

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
            Console.WriteLine("\nCena kupna:{0} zl \nCena wynajmu:{1} zl\n", rdr.GetString(5), rdr.GetString(6));
            back:
            Console.WriteLine("Wybierz opcje:\n1.Zakup \n2.Wynajem");
            string choose = Console.ReadLine();

            switch(choose){

                case "1":
                    if(buy(id)){
                        search();
                    }
                    break;
                case "2":
                    if(rent(id,rdr.GetString(6))){
                        search();
                    }
                    break;

                default:
                    Console.WriteLine("Zly wybor");
                    goto back;   

            }

        }
        public bool buy(string id){

            Console.WriteLine("Kupowanie\n");

            Console.WriteLine("Podaj imie i nazwisko");
            string name=Console.ReadLine();

            using var con = new MySqlConnection(connectmysql());
            con.Open();

            string sql = ($"SELECT * FROM car WHERE id='{id}'");
            using var cmd = new MySqlCommand(sql, con);
            using(MySqlDataReader rdr = cmd.ExecuteReader()){
            
            rdr.Read();

            Console.WriteLine("Kupiles: \n{0} {1} \nRok {2} Przebieg {3} Km za {4} zl  ", rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5));
            }

            string sql_1 = ($"INSERT INTO `buy` (`id`, `id_car`, `name_buyer`) VALUES (NULL, '{id}', '{name}');");
            string sql_2 = ($"UPDATE `car` SET `status` = 'sprzedany' WHERE `car`.`id` = '{id}';");

            using var cmd1 = new MySqlCommand(sql_1, con);
            using var cmd2 = new MySqlCommand(sql_2, con);
            cmd1.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();

            Thread.Sleep(4000);
            Console.Clear();

            con.Close();

            return true;

        }

        public bool rent(string id,string cost){

            Console.WriteLine("Wypozyczenie\n");
            Console.WriteLine("Podaj imie i nazwisko");

            string name=Console.ReadLine();

            Console.WriteLine("Na ile miesiecy?");
            int how_much=Convert.ToInt32(Console.ReadLine());

            DateTime now = DateTime.Now;
            DateTime modifiedDatetime = now.AddMonths(how_much);

            using var con = new MySqlConnection(connectmysql());
            con.Open();
            string sql_1 = ($"INSERT INTO `rent` (`id`, `id_car`, `name_buyer`,`do_kiedy`) VALUES (NULL, '{id}', '{name}','{modifiedDatetime}');");
            string sql_2 = ($"UPDATE `car` SET `status` = 'wynajety' WHERE `car`.`id` = '{id}';");

            using var cmd1 = new MySqlCommand(sql_1, con);
            using var cmd2 = new MySqlCommand(sql_2, con);

            cmd1.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();

            int result = Int32.Parse(cost);

            Console.WriteLine($"Auto wynajete do {modifiedDatetime} za {how_much*result} zl \n");

            con.Close();
            Thread.Sleep(4000);

            return true;

        }

    }
}

