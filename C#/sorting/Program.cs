using System;
using System.Collections.Generic;
using System.Drawing;

class Program
{
    static int[] BubbleSort(int[] array)
    {
        int temp;
        int comparisons = 0;
        int swaps = 0;

        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array.Length - 1; j++)
            {
                comparisons++;

                if (array[j] > array[j + 1])
                {
                    temp = array[j + 1];
                    array[j + 1] = array[j];
                    array[j] = temp;

                    swaps++;
                }
            }
        }

        return array;
    }
    static List<int> BubbleSort(List<int> list)
    {
        int temp;

        for (int i = 0; i < list.Count; i++)
        {
            for (int j = 0; j < list.Count - 1; j++)
            {
                if (list[j] > list[j + 1])
                {
                    temp = list[j + 1];
                    list[j + 1] = list[j];
                    list[j] = temp;
                }
            }
        }

        return list;
    }
    static int[] InsertionSort(int[] array)
    {
        int temp, j;
        for (int i = 1; i < array.Length; i++)
        {
            temp = array[i];
            j = i - 1;

            while (j >= 0 && array[j] > temp)
            {
                array[j + 1] = array[j];
                j = j - 1;
            }
            array[j + 1] = temp;
        }

        return array;
    }

    static List<int> InsertionSort(List<int> list)
    {
        int temp, j;
        for (int i = 1; i < list.Count; i++)
        {
            temp = list[i];
            j = i - 1;

            while (j >= 0 && list[j] > temp)
            {
                list[j + 1] = list[j];
                j = j - 1;
            }
            list[j + 1] = temp;
        }

        return list;
    }
    static int[] SelectionSort(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            int min = i;

            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] < array[min])
                    min = j;
            }

            int temp = array[min];
            array[min] = array[i];
            array[i] = temp;
        }


        return array;
    }
    static List<int> SelectionSort(List<int> list)
    {
        for (int i = 0; i < list.Count - 1; i++)
        {
            int min = i;

            for (int j = i + 1; j < list.Count; j++)
            {
                if (list[j] < list[min])
                    min = j;
            }

            int temp = list[min];
            list[min] = list[i];
            list[i] = temp;
        }


        return list;
    }

    static void PrintArray(int[] array, int n, int everyN)
    {
        Console.Write("\n(array) ");
        for (int i = 0; i < n; i++)
        {
            if (i % everyN == 1)
                Console.Write(array[i] + " ");
        }
    }

    static void PrintList(List<int> list, int n, int everyN)
    {
        Console.Write("\n(list) ");
        for (int i = 0; i < n; i++)
        {
            if (i % everyN == 1)
                Console.Write(list[i] + " ");
        }
    }

    static void Main(string[] args)
    {
        Random rand = new Random();

        int n = 50000;

        int [] array1 = new int[n];
        int [] array2 = new int[n];
        int [] array3 = new int[n];

        List<int> list1 = new List<int>(n);
        List<int> list2 = new List<int>(n);
        List<int> list3 = new List<int>(n);

        for (int i = 0; i < n; i++)
        {
            array1[i] = rand.Next(0, 500);
            array2[i] = array1[i];
            array3[i] = array1[i];
        }

        for (int i = 0; i < n; i++)
        {
            list1.Add(rand.Next(0, 500));
            list2.Add(list1[i]);
            list3.Add(list1[i]);
        }

        DateTime start;
        TimeSpan time;

//---------------------------------------------------------------------------------------

        Console.Write("Bubble Sort");
        Console.Write("\n-->Before sorting: ");
        PrintArray(array1, n, 2500);

        start = DateTime.Now;
        int[] ordenados = BubbleSort(array1);
        time = DateTime.Now - start;

        Console.Write("\n-->After Sorting: ");
        PrintArray(ordenados, n, 2500);
        Console.Write("\n-->Lasted: " + time);

        Console.Write("\n-->Before sorting: ");
        PrintList(list1, n, 2500);

        start = DateTime.Now;
        List<int> ordenadosList = BubbleSort(list1);
        time = DateTime.Now - start;

        Console.Write("\n-->After Sorting: ");
        PrintList(ordenadosList, n, 2500);
        Console.Write("\n-->Lasted: " + time);

//---------------------------------------------------------------------------------------

        Console.Write("\n\nInsertion Sort");
        Console.Write("\n-->Before sorting: ");
        PrintArray(array2, n, 2500);

        start = DateTime.Now;
        int[] ordenados2 = InsertionSort(array2);
        time = DateTime.Now - start;

        Console.Write("\n-->After Sorting: ");
        PrintArray(ordenados2, n, 2500);
        Console.Write("\n-->Lasted: " + time);

        Console.Write("\n-->Before sorting: ");
        PrintList(list2, n, 2500);

        start = DateTime.Now;
        List<int> ordenadosList2 = InsertionSort(list2);
        time = DateTime.Now - start;

        Console.Write("\n-->After Sorting: ");
        PrintList(ordenadosList2, n, 2500);
        Console.Write("\n-->Lasted: " + time);

//---------------------------------------------------------------------------------------

        Console.Write("\n\nSelection Sort");
        Console.Write("\n-->Before sorting: ");
        PrintArray(array3, n, 2500);

        start = DateTime.Now;
        int[] ordenados3 = SelectionSort(array3);
        time = DateTime.Now - start;

        Console.Write("\n-->After Sorting: ");
        PrintArray(ordenados3, n, 2500);
        Console.Write("\n-->Lasted: " + time);

        Console.Write("\n-->Before sorting: ");
        PrintList(list3, n, 2500);

        start = DateTime.Now;
        List<int> ordenadosList3 = SelectionSort(list3);
        time = DateTime.Now - start;

        Console.Write("\n-->After Sorting: ");
        PrintList(ordenadosList3, n, 2500);
        Console.Write("\n-->Lasted: " + time);
    }
}