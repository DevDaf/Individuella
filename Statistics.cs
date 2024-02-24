using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

namespace Statistics
{
  
    public static class Statistics
    {
        public static int[] source = JsonConvert.DeserializeObject<int[]>(File.ReadAllText("data.json"));

        public static dynamic DescriptiveStatistics(int[] source)
        {
            Dictionary<string, dynamic> StatisticsList = new Dictionary<string, dynamic>()
            {
                { "Maximum", Maximum(source) },
                { "Minimum", Minimum(source) },
                { "Medelvärde", Mean(source) },
                { "Median", Median(source) },
                { "Typvärde", String.Join(", ", Mode(source)) },
                { "Variationsbredd", Range(source) },
                { "Standardavvikelse", StandardDeviation(source) }
                
            };

            string output =
                $"Maximum: {StatisticsList["Maximum"]}\n" +
                $"Minimum: {StatisticsList["Minimum"]}\n" +
                $"Medelvärde: {StatisticsList["Medelvärde"]}\n" +
                $"Median: {StatisticsList["Median"]}\n" +
                $"Typvärde: {StatisticsList["Typvärde"]}\n" +
                $"Variationsbredd: {StatisticsList["Variationsbredd"]}\n" +
                $"Standardavvikelse: {StatisticsList["Standardavvikelse"]}";

            return output;
        }

        public static int Maximum(int[] source)
        {
            Array.Sort(source);
            Array.Reverse(source);
            int result = source[0];
            return result;
        }

        public static int Minimum(int[] source)
        {
            Array.Sort(source);
            int result = source[0];
            return result;
        }

        public static double Mean(int[] source)
        {

            double total = 0;

            for (int i = 0; i < source.LongLength; i++)
            {
                total += source[i];
            }
            return total / source.LongLength;
        }

        public static double Median(int[] source)
        {
            Array.Sort(source);
            int size = source.Length;
            int mid = size / 2;
            int dbl = source[mid];
            return dbl;
        }
        // first int takes number from source second int counts the amount whilst the for each
        // loop checks if there is a number adds upon that. if there is no number puts it at 1
        public static int[] Mode(int[] source)
        {
            Dictionary<int, int> nummer = new Dictionary<int, int>();

            foreach (int num in source)
            {
                if (nummer.ContainsKey(num))
                    nummer[num]++;
                else
                    nummer[num] = 1;
            }
            //creates and int maxnummer takes the highest and most amount of number in nummer and puts it on Maxnummer
            int MaxNummers = nummer.Max(pair => pair.Value);
            //finds all the modes and adds them to the list
            List<int> Mode = nummer.Where(pair => pair.Value == MaxNummers).Select(pair => pair.Key).ToList();

            return Mode.ToArray();
        }

        public static int Range(int[] source)
        {
            Array.Sort(source);
            int min = source[0];
            int max = source[0];

            for (int i = 0; i < source.Length; i++)
                if (source[i] > max)
                    max = source[i];

            int range = max - min;
            return range;
        }

        public static double StandardDeviation(int[] source) 
        {

            double average = source.Average();
            double sumOfSquaresOfDifferences = source.Select(val => (val - average) * (val - average)).Sum();
            double sd = Math.Sqrt(sumOfSquaresOfDifferences / source.Length);

            double round = Math.Round(sd, 1);
            return round;
        }

    }
}
