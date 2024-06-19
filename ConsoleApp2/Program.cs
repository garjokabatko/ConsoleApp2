using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Write("Въведете числа, разделени с интервал: ");
        List<double> numbers = Console.ReadLine().Split(' ').Select(double.Parse).ToList();

        double mean = numbers.Sum() / numbers.Count;
        double median = CalculateMedian(numbers);
        double mode = CalculateMode(numbers);

        Console.WriteLine($"Средно аритметично: {mean}");
        Console.WriteLine($"Медиана: {median}");
        Console.WriteLine($"Мода: {mode}");
    }

    static double CalculateMedian(List<double> numbers)
    {
        numbers.Sort();
        int count = numbers.Count;
        return (count % 2 != 0) ? numbers[count / 2] : (numbers[count / 2 - 1] + numbers[count / 2]) / 2.0;
    }

    static double CalculateMode(List<double> numbers)
    {
        var grouped = numbers.GroupBy(n => n)
                             .OrderByDescending(g => g.Count())
                             .ThenBy(g => g.Key)
                             .First();
        return grouped.Key;
    }
}
