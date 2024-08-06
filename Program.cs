
using static LanguageExt.Prelude;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using LanguageExt.SomeHelp;
using LanguageExt.Pipes;

namespace exercises
{

    internal class Program
    {
        // Write a function that takes a dictionary of string keys and integer values,
        // and returns a new dictionary with all values incremented by 1.
        public static Dictionary<string, int> IncrementValues(Dictionary<string, int> dict)
        {
            return dict.ToDictionary(kvp => kvp.Key, kvp => kvp.Value + 1);
        }

        // Create a function that merges two dictionaries, summing the values for matching keys.
        public static Dictionary<string, int> MergeDictionaries(Dictionary<string, int> dict1, Dictionary<string, int> dict2)
        {
            return dict1.Concat(dict2)
                        .GroupBy(kvp => kvp.Key)
                        .ToDictionary(g => g.Key, g => g.Sum(kvp => kvp.Value));
        }

        // Write a function that filters a dictionary, keeping only entries where the value is even.
        public static Dictionary<string, int> FilterEvenValues(Dictionary<string, int> dict)
        {
            return dict.Where(kvp => kvp.Value % 2 == 0)
                       .ToDictionary();
        }

        // Create a function that returns the key with the maximum value in a dictionary.
        public static string GetKeyWithMaxValue(Dictionary<string, int> dict)
        {
           return dict.MaxBy(kvp => kvp.Value).Key;
        }

        // Write a function that groups a list of strings by their length,
        // returning a dictionary where the key is the length and the value is a
        // list of strings of that length.
        // 5 [tomer, enosh]
        // 4 [alef, omer] 
        public static Dictionary<int, List<string>> GroupStringsByLength(List<string> strings)
        {
            return strings.GroupBy(s => s.Length)
                          .ToDictionary(g => g.Key, g => g.ToList());
        }

        // Create a queue of strings and enqueue 3 strings
        public static void Enqueue()
        {
            Queue<string> fruitQueue = new();

            // Enqueue fruits
            fruitQueue.Enqueue("Apple");
            fruitQueue.Enqueue("Banana");
            fruitQueue.Enqueue("Cherry");
        }

        // Create a queue of int, peek, dequeue and peek again
        public static void PeekAndDequeue()
        {
            Queue<int> numberQueue = new();

            numberQueue.Enqueue(10);
            numberQueue.Enqueue(20);
            numberQueue.Enqueue(30);

            Console.WriteLine($"First element without removing: {numberQueue.Peek()}");  // Output: 10
            Console.WriteLine($"Dequeued element: {numberQueue.Dequeue()}");  // Output: 10
            Console.WriteLine($"New first element: {numberQueue.Peek()}");  // Output: 20
        }

        // Create a queue of int, count queue, clear queue and count again
        public static void ClearQueue()
        {
            Queue<int> charQueue = new();

            charQueue.Enqueue(10);
            charQueue.Enqueue(20);
            charQueue.Enqueue(30);

            Console.WriteLine($"Queue count before clear: {charQueue.Count}");  // Output: 3

            charQueue.Clear();

            Console.WriteLine($"Queue count after clear: {charQueue.Count}");  // Output: 0
        }

        // Filter Queue Elements Create a queue of integers and use LINQ
        // to create a new queue with only even numbers.
        public static void FilterEvenQueues()
        {
            IEnumerable<int> toQu = [2, 3, 4, 5];

            Queue<int> queues = toQu.ToQueue();

            Queue<int> numbers = new([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]);

            Queue<int> evens = numbers.Where(x => x % 2 == 0).ToQueue();

            Queue<int> evenNumbers = new(numbers.Where(n => n % 2 == 0));
            Console.WriteLine(string.Join(",", evenNumbers));
        }

        // Transform Queue Elements Double each element in a queue of integers.
        public static void TransformQueues()
        {
            Queue<int> original = new([1, 2, 3, 4, 5]);
            Queue<int> doubled = original.Select(n => n * 2).ToQueue();
            Console.WriteLine(string.Join(",", doubled));
        }

        // Find the maximum and the minimum values in queue
        public static void MaxAndMin()
        {
            Queue<int> values = new([5, 2, 8, 1, 9]);
            int max = values.Max();
            int min = values.Min();

            Console.WriteLine($"Max: {max}, Min: {min}");
        }

        static void Main(string[] args)
        {

            Dictionary<string, int> ages = new()
           {
               {"enosh", 34 },
               {"alef", 16 },
               {"avi", 450 },
                {"elly", 23},
                {"tomer", 12 }
           };

            Dictionary<string, int> segelAges = new()
            {
                {"elly", 27 },
                {"uriel", 120 },
                {"tomer", 502 },
                {"ariel", 22 },
                {"enosh", 45 }
            };

            Dictionary<string, int> studentsGrades = new()
            {
                { "mendy", 100 },
                { "bejamin", 12 },
                { "enosh", 0 },
                { "ariel", 100 },
                { "michael", 12 },
                { "alef", 0 }
            };

            var group = studentsGrades.GroupBy(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Select(x => x.Key).ToList());

            // 5 [enosh, tomer]
            // 4 [alef]

           foreach(var x in group)
            {
                Console.WriteLine(x.Key + " " +  $"[{string.Join(",",x.Value)}]");
            }



            var combined = ages.Concat(segelAges)
                .GroupBy(kvp => kvp.Key)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Select(x => x.Value).ToList());

          


        }
    }
}
