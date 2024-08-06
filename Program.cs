
using static LanguageExt.Prelude;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using LanguageExt.SomeHelp;

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
                       .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }

        // Create a function that returns the key with the maximum value in a dictionary.
        public static string GetKeyWithMaxValue(Dictionary<string, int> dict)
        {
            return dict.OrderByDescending(kvp => kvp.Value).First().Key;
        }

        // Write a function that groups a list of strings by their length,
        // returning a dictionary where the key is the length and the value is a
        // list of strings of that length.
        public static Dictionary<int, List<string>> GroupStringsByLength(List<string> strings)
        {
            return strings.GroupBy(s => s.Length)
                          .ToDictionary(g => g.Key, g => g.ToList());
        }

        // Create a queue of strings and enqueue 3 strings
        public static void Enqueue ()
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

        static void Main(string[] args)
        {





        }
    }
}
