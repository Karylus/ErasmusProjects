using System;
using System.Collections.Generic;
using System.Drawing;

class Program
{
    static int[] BubbleSort(int[] array)
    {
        int temp;

        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array.Length - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    temp = array[j + 1];
                    array[j + 1] = array[j];
                    array[j] = temp;
                }
            }
        }

        return array;
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
    static void Main(string[] args)
    {
        int[] numeros = { 2, 3, -1, 5, 3, 11, -4, 10 };

        int[] ordenados = BubbleSort(numeros);

        Console.Write("Bubble Sort: ");
        for (int i = 0; i < ordenados.Length; i++)
            Console.Write(ordenados[i] + ", ");

        int[] ordenados2 = InsertionSort(numeros);

        Console.Write("\nInsertion Sort: ");
        for (int i = 0; i < ordenados.Length; i++)
            Console.Write(ordenados2[i] + ", ");

        int[] ordenados3 = SelectionSort(numeros);

        Console.Write("\nSelection Sort: ");
        for (int i = 0; i < ordenados.Length; i++)
            Console.Write(ordenados3[i] + ", ");
    }
}