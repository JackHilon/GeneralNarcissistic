using System;
using System.Collections.Generic;

namespace GeneralNarcissistic
{
    class Program
    {
        static void Main(string[] args)
        {
            // Narcissistic Numbers
            // An n-digit number that is the sum of the n-th powers of its digits is
            // called an n-narcissistic. For n=3 there are only 4 numbers 
            // -{ 153 , 370 , 371 , 407 }- which are the sums of the cubes of their 
            // digits.
            // 153 = 1^3 + 5^3 + 3^3
            // 370 = 3^3 + 7^3 + 0^3
            // 371 = 3^3 + 7^3 + 1^3
            // 407 = 4^3 + 0^3 + 7^3


            Console.Write("Enter order: ");
            int order = EnterNumber();

            Console.WriteLine(" ");
            Console.WriteLine($"Narcissistic numbers of order({order}):");
            PrintList(Narcissistic1(order));
            Console.WriteLine(" ");

            Console.WriteLine(" ");
            Console.WriteLine($"All Narcissistic numbers to the order({order}):");
            PrintList(Narcissistic2(order));
            Console.WriteLine(" ");

        }
        private static List<int[]> Narcissistic2(int order)
        {
            var results = new List<int[]>();
            for (int y = 3; y <= order; y++)
            {
                results.AddRange(Narcissistic1(y));
            }
            return results;
        }
        private static List<int[]> Narcissistic1(int order)
        {
            var results = new List<int[]>();
            int[] number = InitializeArray(order);

            int p = 0;
            int limit = (int)Math.Pow(10, order + 1);
            while (true)
            {
                if (BasicFunc(number) == true && number[0] != 0)
                    results.Add(number);
                number = IncrementArray(number);

                p++;
                if (p > limit)
                    break;
            }
            return results;
        }
        private static int[] IncrementArray(int[] array)
        {
            var arr = CopyArray(array);
            arr[0] = arr[0] + 1;
            for (int i = 0; i < arr.Length; i++)
            {
                if(arr[i]==10&&i<arr.Length-1)
                {
                    arr[i] = 0;
                    arr[i + 1] = arr[i + 1] + 1;
                }
                if (arr[i] == 10 && i < arr.Length - 1)
                {
                    arr[i] = 0;
                }
            }
            return arr;
        }
        private static bool BasicFunc(int[] array)
        {
            var first = FirstFunc(array);
            var second = SecondFunc(array);
            if (SumArray(first) == SumArray(second))
                return true;
            else return false;
        }
        private static int[] MinusArray(int[] a, int[] b)
        {
            try
            {
                if (a.Length != b.Length)
                    throw new IndexOutOfRangeException();
            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message + ": FATAL ERROR!!!!");
                return a;
            }
            var res = new int[a.Length];
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = a[i] - b[i];
            }
            return res;
        }
        private static bool CompareArray(int[] a, int[] b)
        {
            try
            {
                if (a.Length != b.Length)
                    throw new IndexOutOfRangeException();
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message + ": FATAL ERROR!!!!");
                return false;
            }
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                    return false;
            }
            return true;
        }
        private static int[] SecondFunc(int[] array)
        {
            int order = array.Length;
            var arr = CopyArray(array);
            for (int i = 0; i < order; i++)
            {
                arr[i] = (int)Math.Pow(10, order - 1 - i) * arr[i];
            }
            return arr;
        }
        private static int[] FirstFunc(int[] array)
        {
            int order = array.Length;
            var arr = CopyArray(array);
            for (int i = 0; i < order; i++)
            {
                arr[i] = (int)Math.Pow(arr[i], order);
            }
            return arr;
        }
        private static int EnterNumber()
        {
            int a = 0;
            try
            {
                a = int.Parse(Console.ReadLine());
                if (a < 1 || a > 10)
                    throw new ArgumentException();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message + " : Order must be [1 , 8]");
                return EnterNumber();
            }
            return a;
        }
        private static int[] CopyArray(int[] a)
        {
            int[] b = new int[a.Length];
            for (int i = 0; i < b.Length; i++)
            {
                b[i] = a[i];
            }
            return b;
        }
        private static int[] InitializeArray(int leng)
        {
            int[] arr = new int[leng];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = 0;
            }
            return arr;
        }
        private static int SumArray(int[] a)
        {
            int sum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                sum = sum + a[i];
            }
            return sum;
        }
        private static void PrintArrayOneLine(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine(" ");
        }
        private static void PrintList(List<int[]> list)
        {
            foreach (var item in list)
            {
                PrintArrayOneLine(item);
            }
        }
    }
}
