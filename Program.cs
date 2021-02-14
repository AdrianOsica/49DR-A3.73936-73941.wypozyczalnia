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
            Console.WriteLine("1. Znajdz samochod \n2. Dodaj samochod \n3. Edytuj samochod\n4. Wyjdz");
            back:
            string choose = Console.ReadLine();

            switch(choose){


                case "1":
                    if(ft.search(false))
                    {
                        goto start; 
                    }
                    break;
                case "2":
                    if(ft.add()){
                        goto start; 
                    }
                    break;
                case "3":
                    if(ft.edit()){
                        goto start;
                    }
                    break;
                case "4":
                    break;
                default:
                    Console.WriteLine("Zly wybor");
                    goto back;   

            }





        
        }
           
    }
}
