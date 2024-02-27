using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace lb1._2
{
    delegate bool FindDelegate(int number, int k);
    internal class Program
    {
        static void Main(string[] args)
        {
            int k = InputK();

            int[] array = InputArr();

            FindDelegate findDelegate = IsMultiple;

            int[] finishedArray = FindMultipleInArray(array, findDelegate, k);

            Console.WriteLine("My filter");
            PrintArr(finishedArray);

            var result = FilterWithWhere(array, k, findDelegate);

            Console.WriteLine();
            Console.WriteLine("FIlter where");
            PrintArr(result);

        }

        static bool IsMultiple(int number, int k)
        {
            if (number != 0)
            {
                return number % k == 0;
            }
            return false;

        }

        static int[] FindMultipleInArray(int[] array, FindDelegate findDelegate, int k)
        {
            int count = 0;
            foreach (int num in array)
            {
                if (findDelegate(num, k))
                {
                    count++;
                }
            }

            int[] resultArray = new int[count];

            //Array.Resize(ref array, count);

            int index = 0;
            foreach (int num in array)
            {
                if (findDelegate(num, k))
                {
                    resultArray[index] = num;
                    index++;
                }
            }

            return resultArray;
        }

        static int[] FilterWithWhere(int[] array, int k, FindDelegate findDelegate)
        {
            var result = array.Where(x => findDelegate(x, k)).ToArray();
            return result;
        }

        static int InputK()
        {
            Console.Write("Enter k: ");
            return int.Parse(Console.ReadLine());
        }

        static int[] InputArr()
        {
            Console.WriteLine("Enter array length:");
            int arrLength = int.Parse(Console.ReadLine());

            int[] arr = new int[arrLength];

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Enter {i+1} element:");
                arr[i] = int.Parse(Console.ReadLine());
            }

            return arr;
        }

        static void PrintArr(int[] arr)
        {
            Console.WriteLine("Sorted array:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + ", ");
            }
        }

    }
}
