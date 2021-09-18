using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    static class Algorithms
    {
        public static int[] SelectionSort(int [] pole)
        {
            for (int i = 0; i < pole.Length; i++) //jede pro kazdy item v poli
            {
                for (int j = 0; j < pole.Length; j++) //na konci dostane vzdy nejmensi na zacatek
                {
                    if (pole[j] > pole[i])// vezme jednu levou hodnotu a POROVNAVA JI S KAZDOU
                    {
                        //kdyz zjiste ze leva ja vetsi prohodí se a pokracuje dale
                        int pom = pole[i];
                        pole[i] = pole[j];
                        pole[j] = pom;

                    }
                }
                VypisPole(pole.ToList());


            }
            return pole;
        }
        public static int[] BubbleSort(int[] pole)
        {
            for (int l = 0; l < pole.Length; l++) //jede pro kazdy item v poli
            {
                bool Zmena = false;
                for (int i = 0; i < pole.Length - 1; i++) //na konci cyklu dostane vzdy nejvetsi na konec pole
                {
                    if (pole[i] > pole[i + 1]) //porovna vzdycky DVE HODNOTY vedle sebe, leva a prava a potom rozhoda zda je prohodit
                    {

                        //kdyz je na levo vetsi prohodi tyto dve hodnoty
                        int pom = pole[i + 1];
                        pole[i + 1] = pole[i];
                        pole[i] = pom;
                        Zmena = true;
                    }
                }
                if (!Zmena)
                {
                    return pole;
                }
                VypisPole(pole.ToList());
            }
            
            return pole;
        }

        public static int[] InsertSort(int[] pole)
        {
            for (int i = 1; i < pole.Length; i++)
            {
                bool zmena = false;
                for (int j = i; j > 0; j--)
                {
                    if (pole[j - 1] > pole[j])
                    {
                        int pom = pole[j - 1];
                        pole[j - 1] = pole[j];
                        pole[j] = pom;
                        zmena = true;
                    }
                    if (!zmena)
                    {
                        break; //pouzití break protože chceme skocit do outer for ne uplne preskocit zbytek metody
                    }
                }
                VypisPole(pole.ToList());
            }
            return pole;
        }



        public static int[] QuickSort(int[] pole)
        {
            return QuickSortMetoda(pole, 0, pole.Length - 1);
        }
        private static int[] QuickSortMetoda(int[] pole, int Zacatek, int Konec) //extrem tohle
        {
            int Pivot = pole[(Zacatek + Konec) / 2]; //pivot bude prostredek pole

            //Pivot je uprostred

            int COUNTER_LEFT = Zacatek; //bude pricitat indexy od zacatku
            int COUNTER_RIGHT = Konec;//maximalni index ze ktereho se bude odecitat

            //z leve strany musí být hodnoty mensí než Pivot a z prava musí být větsí než pivot
            // mensi ----< PIVOT <--- vetsi 


            while (COUNTER_LEFT <= COUNTER_RIGHT) 
            {
                Console.WriteLine("Pivot: " + Pivot);

                //Projizdi pole z leva a hleda vetsi cisla nez pivot
                //kdyz je cislo mensi nez pivot vše je v poradku a pricte dalsi index 
                while (pole[COUNTER_LEFT] < Pivot) 
                {
                    COUNTER_LEFT++;
                }
                
                //projizdi pole z prava a hleda mensi cislo nez je pivot
                //kdyz je cislo z prava vetsi nez pivot pokracuje dale
                while (pole[COUNTER_RIGHT] > Pivot) 
                {
                    COUNTER_RIGHT--;
                }

                //v promennych counter je ted index cisla ktere nesouhlasí z podminkama
                //COUNTER_LEFT = index nejvetsiho cisla z leva
                //COUNTER_RIGHT = index nejmensiho cisla z prava

                if (COUNTER_LEFT <= COUNTER_RIGHT) //leva strana nemuze byt vetsi nez prava 
                { 
                    Console.WriteLine("index prvního nejvetsiho cisla z leva: " + COUNTER_LEFT);
                    Console.WriteLine("index prvního nejmensiho cisla z prava: " + COUNTER_RIGHT);

                    Console.WriteLine("Neprehozena array");
                    foreach (var item in pole)
                    {
                        Console.Write(" ," + item);
                    }


                    //prohodi pravě ty čísla které nesplňují požadavky tzv. mensi ----< PIVOT <--- vetsi 
                    int K = pole[COUNTER_RIGHT];
                    pole[COUNTER_RIGHT] = pole[COUNTER_LEFT];
                    pole[COUNTER_LEFT] = K;

                    
                    COUNTER_LEFT++;
                    COUNTER_RIGHT--;


                    Console.WriteLine("\n prehozena array ");
                    foreach (var item in pole)
                    {
                        Console.Write(" ," + item);
                    }
                    Console.WriteLine("\n ----------");
                }
            }

            //recursivni
            //kdyz pole splnuje pozadavky (mensi ----< PIVOT <--- vetsi)

            //podrobne vytridi leve a prave casty pole 
            if (Zacatek < COUNTER_RIGHT) 
            {
                Console.WriteLine("Leva cast");
                QuickSortMetoda(pole, Zacatek, COUNTER_RIGHT); //metoda zavola sama sebe s třídí v rozsahu od 0 do pivota (levá mensí část pole)
            }

            if (COUNTER_LEFT < Konec)
            {
                Console.WriteLine("Prava cast");
                QuickSortMetoda(pole, COUNTER_LEFT, Konec);
            }

            return pole;
        }





        public static int[] MergeSort(int[] pole)
        {
            return MergeSortMetoda(pole);
        }

        private static int[] MergeSortMetoda(int[] pole)
        {
            if (pole.Length == 1)//kdyz ma pole jenom jednu hodnotu 
            {
                return pole;
            }


            //dva listy do kterych se rozdeli hlavli list
            List<int> List_Leva = new List<int>();
            List<int> List_Prava = new List<int>();

            for (int i = 0; i < pole.Length; i++) //rozdeli pole na pulku a ulozi do listů
            {
                if (i < pole.Length/2)
                {
                    List_Leva.Add(pole[i]);
                }
                else
                {
                    List_Prava.Add(pole[i]);
                }
            }

            
            Console.WriteLine("\n Leva strana");
            VypisPole(List_Leva);
            Console.WriteLine("\n Prava strana");
            VypisPole(List_Prava);
            Console.WriteLine("");


            //pomoci rekurze rozdeli zbyvajici listy do jednotlivych cisel
            List_Leva = MergeSortMetoda(List_Leva.ToArray()).ToList();
            List_Prava = MergeSortMetoda(List_Prava.ToArray()).ToList();




            //zavola metodu merge, která zase tyto pole spojí
            return merge(List_Leva, List_Prava);
        }


        private static int[] merge(List<int> List_Leva, List<int> List_Prava)
        {
            //list do ktereho se bude ukladat vysledny retezec
            List<int> ListVysledek = new List<int>();


            while (List_Leva.Count > 0 && List_Prava.Count > 0) //dokud nejsou listy prázdné 
            {
                if (List_Leva[0] <= List_Prava[0]) //postupne se diva na prvni indexy listu a kdyz neni mensi v levo (2 itemu v listu) tak je prehodi
                {                   //taky muzem pouzit .First()
                    PresunHodnoty(List_Leva, ListVysledek);
                }
                else
                {
                    PresunHodnoty(List_Prava, ListVysledek);
                }
            }

            while (List_Leva.Count > 0)
            {
                PresunHodnoty(List_Leva, ListVysledek);
            }

            while (List_Prava.Count > 0)
            {
                PresunHodnoty(List_Prava, ListVysledek);
            }



            return ListVysledek.ToArray() ;
        }

        private static void PresunHodnoty(List<int> list, List<int> Vysledek) //presune prvni hodnotu listu do vysledneho listu
        {
            Vysledek.Add(list[0]);
            list.RemoveAt(0);
        }

        private static void VypisPole(List<int> list)
        {
            foreach (var item in list)
            {
                Console.Write(item + " ,");
            }
            Console.WriteLine();
        }

    }
}
