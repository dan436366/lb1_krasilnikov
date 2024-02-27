using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

public class SortingChecker
{
    public delegate void SortingMethod(int[] array);

    public void TestSorting(SortingMethod correctSorting, SortingMethod studentSorting, int[] array)
    {
        Stopwatch stopwatch = new Stopwatch();

        stopwatch.Start();
        correctSorting(array);
        stopwatch.Stop();
        TimeSpan correctTime = stopwatch.Elapsed;

        stopwatch.Restart();
        studentSorting(array);
        stopwatch.Stop();
        TimeSpan studentTime = stopwatch.Elapsed;

        bool isSorted = IsSortedRight(array);

        CompareTime(correctTime.TotalMilliseconds, studentTime.TotalMilliseconds);

        Console.WriteLine($"Еталонний час: {correctTime.TotalMilliseconds} мс");
        Console.WriteLine($"Студентський час: {studentTime.TotalMilliseconds} мс");
        Console.WriteLine($"Сортування вiрне: {isSorted}");
        Console.WriteLine($"Час роботи: {CompareTime(correctTime.TotalMilliseconds, studentTime.TotalMilliseconds)}");
    }

    private bool IsSortedRight(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i] > array[i + 1])
            {
                return false;
            }
        }
        return true;
    }

    private bool CompareTime(double first, double second)
    {
        //double first1 = first * 0.8;
        //double first2 = first * 1.2;

        //if (second >= first1 && first2 >= second)
        //{
        //    return true;
        //}
        //else
        //{
        //    return false;
        //}


        if (Math.Max(0, first / 5 - 200) <= second && second <= first * 5 + 200)
        {
            return true;
        }
        else
        {
            return false;
        }


        //if (first - 200 <= second && second <= first + 200)
        //{
        //    return true;
        //}
        //else
        //{
        //    return false;
        //}
    }
}

class Program
{
    static void Main(string[] args)
    {
        SortingChecker sortingChecker = new SortingChecker();

        int[] array1 = ReadArrayFromFileOrCreate("array1.txt");

        if (array1 == null)
        {
            Console.WriteLine("Failed to read arrays from files.");
            return;
        }

        Console.WriteLine("Перевiрка сортування вибором:");
        sortingChecker.TestSorting(SelectionSort, SelectionSortStudent, array1);
        Console.WriteLine();

        Console.WriteLine("Перевiрка шейкерного сортування:");
        sortingChecker.TestSorting(ShakerSort, ShakerSortStudent, array1);
    }

    static void SelectionSort(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] < array[minIndex])
                {
                    minIndex = j;
                }
            }
            if (minIndex != i)
            {
                int temp = array[i];
                array[i] = array[minIndex];
                array[minIndex] = temp;
            }
        }
    }

    static void ShakerSort(int[] array)
    {
        bool swapped;
        do
        {
            swapped = false;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    int temp = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = temp;
                    swapped = true;
                }
            }
            if (!swapped)
                break;
            swapped = false;
            for (int i = array.Length - 2; i >= 0; i--)
            {
                if (array[i] > array[i + 1])
                {
                    int temp = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = temp;
                    swapped = true;
                }
            }
        } while (swapped);
    }



    static void SelectionSortStudent(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] < array[minIndex])
                {
                    minIndex = j;
                }
            }
            if (minIndex != i)
            {
                int temp = array[i];
                array[i] = array[minIndex];
                array[minIndex] = temp;
            }
        }


        //int n = array.Length;
        //for (int i = 0; i < n - 1; i++)
        //{
        //    for (int j = 0; j < n - i - 1; j++)
        //    {
        //        if (array[j] > array[j + 1])
        //        {
        //            int temp = array[j];
        //            array[j] = array[j + 1];
        //            array[j + 1] = temp;
        //        }
        //    }
        //}

        //Array.Sort(array);

    }

    static void ShakerSortStudent(int[] array)
    {
        bool swapped;
        do
        {
            swapped = false;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    int temp = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = temp;
                    swapped = true;
                }
            }
            if (!swapped)
                break;
            swapped = false;
            for (int i = array.Length - 2; i >= 0; i--)
            {
                if (array[i] > array[i + 1])
                {
                    int temp = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = temp;
                    swapped = true;
                }
            }
        } while (swapped);

        //Array.Sort(array);
    }

    static int[] ReadArrayFromFileOrCreate(string filename)
    {
        if (!File.Exists(filename))
        {
            Random rand = new Random();
            int[] randomArray = new int[rand.Next(5, 20)]; 
            for (int i = 0; i < randomArray.Length; i++)
            {
                randomArray[i] = rand.Next(100); 
            }
            File.WriteAllLines(filename, Array.ConvertAll(randomArray, x => x.ToString()));
            return randomArray;
        }
        else
        {
            string[] lines = File.ReadAllLines(filename);
            return Array.ConvertAll(lines, int.Parse);
        }
    }

}