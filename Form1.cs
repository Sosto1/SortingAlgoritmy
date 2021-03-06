using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortingAlgorithms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int[] array = new int[10] /*{4,7,8,0,1,2,6,3,5,10,9}*/;
        private void Form1_Load(object sender, EventArgs e)
        {
            FillArray(array);
        }
        void FillArray(int[] array)
        {
            Random rnd = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(0, 1000);
            }
        }

        private void button1_Click(object sender, EventArgs e)

        {
            ShowArray(array);

            int[] array2 = Algorithms.SelectionSort(array);
            ShowArray(array2);
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            ShowArray(array);

            int[] array2 = Algorithms.BubbleSort(array);
            ShowArray(array2);
        }


       

        private void button3_Click(object sender, EventArgs e)
        {
            ShowArray(array);

            int[] array2 = Algorithms.QuickSort(array);
            ShowArray(array2);
        }



        public void ShowArray(int[] array)
        {
            Console.WriteLine("\npole");
            foreach (var item in array)
            {
                Console.Write(item + " ,");
            }
            Console.WriteLine("\n");

          //  Console.WriteLine("Neco");
           // Console.WriteLine("--------");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ShowArray(array);

            int[] array2 = Algorithms.MergeSort(array);
            ShowArray(array2);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ShowArray(array);

            int[] array2 = Algorithms.InsertSort(array);
            ShowArray(array2);
        }
    }
}
