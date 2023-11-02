using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISharp
{
    public interface IOutput
    {
        void Show(string message);
        void Show();
    }

    public interface IMath
    {
        int Max();
        int Min();
        float Avg();
        bool Search(int valueToSearch);
    }

    public interface ISort
    {
        void SortAsc();
        void SortDesc();
        void SortByParam(bool isAsc);
    }

    public class Array : IOutput, IMath, ISort
    {
        private int[] array;

        public Array(int[] array)
        {
            this.array = array;
        }

        public void Show()
        {
            foreach (int item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        public void Show(string info)
        {
            Console.WriteLine(info);
            Show(); 
        }

        public int Max()
        {
            if (array.Length == 0)
            {
                return -1;
            }

            return array.Max();
        }

        public int Min()
        {
            if (array.Length == 0)
            {
                return -1;
            }
            
            return array.Min();
        }

        public float Avg()
        {
            if (array.Length == 0)
            {
                return -1;
            }
                
            return (float)array.Sum() / array.Length;
        }

        public bool Search(int valueToSearch)
        {
            return array.Contains(valueToSearch);
        }

        public void SortAsc()
        {
            int temp;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        public void SortDesc()
        {
            SortAsc();

            int temp;

            int mid = array.Length / 2;          

            for (int i = 0; i < mid; i++)
            {
                temp = array[i];
                array[i] = array[array.Length - i - 1];
                array[array.Length - i - 1] = temp;
            }
        }

        public void SortByParam(bool isAsc)
        {
            if (isAsc)
            {
                SortAsc();
            }
            else
            {
                SortDesc();
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 5, 3, 1, 4, 2 };
            Array array = new Array(arr);

            array.Show();

            array.SortAsc();
            array.Show();

            array.SortDesc();
            array.Show();

            array.SortByParam(true); 
            array.Show();

            array.SortByParam(false); 
            array.Show();

            Console.WriteLine(array.Max());
            Console.WriteLine(array.Min());
            Console.WriteLine(array.Avg());

        }
    }
}


    

