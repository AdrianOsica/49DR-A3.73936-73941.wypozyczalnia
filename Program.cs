using System;
using MySql.Data.MySqlClient;
using Functions;

namespace wypo
{
    class Program
    {
        static void Main(string[] args)
        {
            Function ft = new Function();


            Console.WriteLine("Witamy w salonie samochodowym \n");
            start:
            Console.WriteLine("Wybierz jedna z poninzszych opcji: \n");
            Console.WriteLine("1. Znajdz samochod \n2. Dodaj samochod ");
            back:
            string choose = Console.ReadLine();

            switch(choose){


                case "1":
                    ft.search();
                    break;
                case "2":
                    if(ft.add()){
                        goto start; 
                    }
                    break;


                default:
                    Console.WriteLine("Zly wybor");
                    goto back;   

            }





        
        }
           
    }
}
