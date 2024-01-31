using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyak_Con
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Lotto> lotto_list = new List<Lotto>();
            string[] lines = File.ReadAllLines("sorsolas.txt");
            foreach (var item in lines)
            {
                string[] values = item.Split(';');
                Lotto lotto_object = new Lotto(values[0], values[1], values[2], values[3], values[4], values[5] );
                lotto_list.Add(lotto_object);
            }

            /* foreach (var item in lotto_list)
             {
                 Console.WriteLine($"{item.sorszam} {item.szam1} {item.szam2} {item.szam3} {item.szam4} {item.szam5}");
             }*/

            //2.Feladat
            int number = 0;
            bool start = true;
            while (start) {
                Console.WriteLine("Kérem adjon meg egy számot 1-52 között");
                string input = Console.ReadLine();

                if (int.TryParse(input, out number))
                {
                    if (number > 0 && number <= 52)
                    {
                        foreach (var item in lotto_list)
                        {
                            if (item.sorszam == number)
                            {
                                Console.WriteLine($"{item.sorszam} {item.szam1} {item.szam2} {item.szam3} {item.szam4} {item.szam5}");
                            }
                        }start = false;
                    }
                    else Console.WriteLine("Nincs tartományban");
                }
                else Console.WriteLine("Nem szám");


                //3.Feladat
                List<Sorsolas> sorsolas_list = new List<Sorsolas>();

                int db = 0;
                for (int i = 1; i < 91; i++)
                {
                    foreach (var item in lotto_list)
                    {
                        if(item.szam1 == i)
                            db++;
                        if (item.szam2 == i)
                            db++;
                        if (item.szam3 == i)
                            db++;
                        if (item.szam4 == i)
                            db++;
                        if (item.szam5 == i)
                            db++;
                    }
                    Sorsolas sorsolas_object = new Sorsolas(i, db);
                    sorsolas_list.Add(sorsolas_object);
                    db= 0;
                }

                int minDB = int.MaxValue;
                int minSzam = 0;
                foreach (var item in sorsolas_list)
                {
                    if(minDB > item.db)
                    {
                        minDB = item.db;
                        minSzam = item.szam;
                    }
                }
                Console.WriteLine($"{minDB}; {minSzam}");

                //4.Feladat
                int paros = 0;
                foreach (var item in sorsolas_list)
                {
                    if(item.szam % 2 == 0)
                    {
                        paros++;
                    }
                }
                Console.WriteLine(paros);

                //5.Feladat
                int db5 = 0;
                int db46 = 0;
                foreach (var item in sorsolas_list)
                {
                    if(item.szam == 5)
                    {
                        db5+= item.db;
                    }
                    if (item.szam == 46)
                    {
                        db46 += item.db;
                    }
                }

                Console.WriteLine($"{db5}; {db46}");

                //7.Feladat
                foreach (var item in sorsolas_list)
                {
                    Console.WriteLine($"{item.szam}; {item.db}");
                }
                Console.ReadKey();
            }
        }
    }
}
