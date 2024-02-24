using System;
using Statistics;

class Program
{
    public static void Main()
    {
        int[] source = new int[] { 1, 2, 3, 4, 5, };
        Console.WriteLine(Statistics.Statistics.DescriptiveStatistics(source));
        Console.ReadKey();
    }
}
