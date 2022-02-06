using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab22
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            Func<object, int[]> func1 = new Func<object, int[]>(GetArray);
            Task<int[]> task1 = new Task<int[]>(func1, n);
            Action<Task<int[]>> action = new Action<Task<int[]>>(SumMax);
            Task task2 = task1.ContinueWith(action);
            task1.Start();
            Console.ReadKey();
        }
        static int[] GetArray(object a)
        {
            int n = (int)a;
            int[] array = new int[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(0, 100);
            }
            return array;
        }
        static void SumMax(Task<int[]> task)
        {
            int[] array = task.Result;
            int Sum = 0;
            int Max = 0;
            for (int i = 0; i < array.Count(); i++)
            {
                Sum += array[i];
                int maxValue = array.Max<int>();
                Max = maxValue;
                Console.Write($"{ array[i]} ");
            }
            Console.WriteLine($" ");
            Console.WriteLine($"{ Max} ");
            Console.WriteLine($"{Sum} ");
        }
    }
}