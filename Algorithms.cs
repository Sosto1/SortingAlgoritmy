using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    static class Algorithms
    {
        public static int[] BasicSort(int [] array)
        {
            for (int i = 0; i < array.Length; i++) //jede pro kazdy item v poli
            {
                for (int j = 0; j < array.Length; j++) //na konci dostane vzdy nejmensi na zacatek
                {
                    if (array[j] > array[i])// vezme jednu levou hodnotu a POROVNAVA JI S KAZDOU
                    {
                        //kdyz zjiste ze leva ja vetsi prohodí se a pokracuje dale
                        int pom = array[i];
                        array[i] = array[j];
                        array[j] = pom;

                    }
                }
                
            }
            return array;
        }
        public static int[] BubbleSort(int[] pole)
        {
            for (int l = 0; l < pole.Length; l++) //jede pro kazdy item v poli
            {

                for (int i = 0; i < pole.Length - 1; i++) //na konci cyklu dostane vzdy nejvetsi na konec pole
                {
                    if (pole[i] > pole[i + 1]) //porovna vzdycky DVE HODNOTY vedle sebe, leva a prava a potom rozhoda zda je prohodit
                    {

                        //kdyz je na levo vetsi prohodi tyto dve hodnoty
                        int pom = pole[i + 1];
                        pole[i + 1] = pole[i];
                        pole[i] = pom;
                    }
                }
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
            if (pole.Length == 1)
            {
                return pole;
            }

            List<int> List_Leva = new List<int>();
            List<int> List_Prava = new List<int>();

            for (int i = 0; i < pole.Length; i++)
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


            List_Leva = MergeSortMetoda(List_Leva.ToArray()).ToList();
            List_Prava = MergeSortMetoda(List_Prava.ToArray()).ToList();





            return merge(List_Leva, List_Prava);
        }


        private static int[] merge(List<int> List_Leva, List<int> List_Prava)
        {
            List<int> ListVysledek = new List<int>();


            while (List_Leva.Count > 0 && List_Prava.Count > 0)
            {
                if (List_Leva.First() <= List_Prava.First())
                {
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

        private static void PresunHodnoty(List<int> list, List<int> Vysledek)
        {
            Vysledek.Add(list.First());
            list.RemoveAt(0);
        }






        private static void VypisPole(List<int> list)
        {
            foreach (var item in list)
            {
                Console.Write(item + " ,");
            }
        }

    }
}
