using System;
using MyListLibrary;
namespace MyListProgram
{
    public class Program
    {

        private static void MainTest()
        {
            Console.WriteLine("#== MyList Test Program ==#");
            MyList<int> list = new MyList<int>();
            Random rand = new Random();
            for(int i = 0; i < 15; i++)
            {
                int num = rand.Next(100);
                list.Add(num);
            }

            // Testing Enumeration
            Console.WriteLine(list);
            Console.WriteLine("\n#== Enumerating Test ==#");
            foreach(int i in list)
            {
                Console.WriteLine(i);
            }

            // Testing IndexOf() Function
            Console.WriteLine("\n#== IdexOf() Test ==#");
            Console.WriteLine($"Testing for index of int 5: {list.IndexOf(5) }");
            Console.WriteLine($"Testing for index of int 100: {list.IndexOf(100) }");

            // Testing Contains() Function
            Console.WriteLine("\n#== Contains() Test ==#");
            Console.WriteLine($"Checking if list contains int 14: {list.Contains(14) }");
            Console.WriteLine($"Checking if list contains int 100: {list.Contains(100) }");

            // Testing Count variable 
            Console.WriteLine("\n#== Count value test ==#");
            Console.WriteLine($"List Count vale: {list.Count}");

            // Testing Insert() Function
            Console.WriteLine("\n#== Insert() Test ==#");
            Console.WriteLine("Inserting '17' at index '2'");
            list.Insert(17, 2);
            Console.WriteLine("New List:");
            foreach(int i in list)
            {
                Console.WriteLine(i);
            }

            // Testing RemoveAt() Function
            Console.WriteLine("\n#== RemoveAt() Test ==#");
            Console.WriteLine("Removing '17' at index '2'");
            list.RemoveAt(2);
            Console.WriteLine("New List:");
            foreach(int i in list)
            {
                Console.WriteLine(i);
            }

            // Testing get-set with [] notation
            Console.WriteLine("\n#== Index Get-Set Test ==#");
            Console.WriteLine("Setting '17' to index '2' using '[int index]' notation");
            list[2] = 17;
            for(int i = 0; i < 3; i++)
            {
                Console.WriteLine($"List index {i} = {list[i]}");
            }
            Console.WriteLine("Previous 3 indexes called using '[int index]' notation.");

            // Testing ToArray() Function
            Console.WriteLine("\n#== ToArray() Test ==#");
            Console.WriteLine("Converting MyList object to array.");
            int[] arr = list.ToArray();
            Console.Write("[ ");
            foreach(int i in arr)
            {
                Console.Write($"{i}, ");
            }
            Console.Write("]\n");

            // Testing Constructor with Pre-made Array
            Console.WriteLine("\n#== Secondary Constructor Test ==#");
            string[] sArr = new string[] { "z", "h", "c", "g", "e", "f", "i", "a"};
            MyList<string> sList = new MyList<string>(sArr);
            Console.WriteLine(sList);

            // Simple Sort Test
            Console.WriteLine("\n#== Simple Sort Test ==#");
            list.SimpleSort();
            foreach(int i in list)
            {
                Console.WriteLine(i);
            }
        }


        public static async void WalkerTest()
        {
            int arrLength = 9;
            int[] arr = new int[arrLength];
            for(int i = 1; i < arrLength + 1; i++)
            {
                arr[i - 1] = i;
            }
            MyList<int> l = new MyList<int>(arr);

            l.MergeSort();
        }
        public static void Main(string[] args)
        {
            // MainTest();
            WalkerTest();
        }
    }
}