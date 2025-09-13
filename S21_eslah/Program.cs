using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace S21_Refactored
{
    
    public static class CollectionHelpers
    {
     
        public static IEnumerable<T> GrabFirstItems<T>(this IEnumerable<T> collection, int limit)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (limit < 0) throw new ArgumentOutOfRangeException(nameof(limit));

            var resultList = new List<T>();
            using (var enumerator = collection.GetEnumerator())
            {
                while (limit > 0 && enumerator.MoveNext())
                {
                    resultList.Add(enumerator.Current);
                    limit--;
                }
            }
            return resultList;
        }

      
        public static IEnumerable<T> StreamFirstItems<T>(this IEnumerable<T> collection, int limit)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (limit < 0) throw new ArgumentOutOfRangeException(nameof(limit));

            foreach (var element in collection)
            {
                if (limit <= 0)
                    yield break;
                
                yield return element;
                limit--;
            }
        }
    }

   
    class CsvProcessor
    {
     
        public static IEnumerable<string> GenerateSampleNames()
        {
            yield return "Nima";
            yield return "Tara";
            yield return "Kian";
        }
       private static (string Country, int Year, double Rate) ParseCsvRecord(string csvLine)
        {
            string[] fields = csvLine.Split(',');
            string country = fields[0].Trim();
            int year = int.Parse(fields[2].Trim());
            double rate = double.Parse(fields[3].Trim());
            return (country, year, rate);
        }


        static void Main(string[] args)
        {
            Console.WriteLine("--- دمو متد تولید نام ---");
            var sampleNames = GenerateSampleNames();
            foreach (var name in sampleNames)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("\n--- پردازش فایل CSV ---");
          
            try
            {
                var lines = File.ReadAllLines("children-per-woman-UN.csv");

                var records = lines
                    .Skip(1) 
                    .Select(ParseCsvRecord);

                var groupedByCountry = records
                    .GroupBy(record => record.Country);

                var finalReport = groupedByCountry
                    .Select(group => (
                        CountryName: group.Key, 
                        AverageRate: group.Average(record => record.Rate)
                    ))
                    .OrderBy(result => result.AverageRate)
                    .Take(5);

                Console.WriteLine("۵ کشور با کمترین میانگین نرخ باروری:");
              
                foreach (var item in finalReport)
                {
                    Console.WriteLine($" - کشور: {item.CountryName}, میانگین: {item.AverageRate:F2}");
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("خطا: فایل 'children-per-woman-UN.csv' یافت نشد.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"یک خطای غیرمنتظره رخ داد: {ex.Message}");
            }
        }
    }
}