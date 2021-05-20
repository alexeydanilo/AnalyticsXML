using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using System.Text.Json;

namespace AnalyticsXML
{
    class Program
    {
        static void Main(string[] args)
        {

            XDocument xdoc = XDocument.Load("XMLFile.xml");
            List<CD> cds = xdoc.Root.Elements("CD")
                .Select(x => new CD()
                {
                    Title = (string)x.Element("TITLE"),
                    Artist = (string)x.Element("ARTIST"),
                    Country = (string)x.Element("COUNTRY"),
                    Company = (string)x.Element("COMPANY"),
                    Price = (double)x.Element("PRICE"),
                    Year = Convert.ToInt32((string)x.Element("YEAR"))
                }).ToList();

            int minYear = cds.Min(x => x.Year);
            int maxYear = cds.Max(x => x.Year);
            int cdsCount = cds.Count();
            double sum = cds.ToArray().Sum(x => x.Price);

            Analytics analytics = new Analytics
            {
                CdsCount = cdsCount,
                PricesSum = sum,
                MinYear = minYear,
                MaxYear = maxYear,
                Artists = cds.Select(x => x.Artist).ToList(),
                Companies = cds.Select(x => x.Company).ToList(),
                Countries = cds.Select(x => x.Country).ToList(),
                Titles = cds.Select(x => x.Title).ToList()
            };
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string json = JsonSerializer.Serialize<Analytics>(analytics, options);
            
            Console.WriteLine(json);





            Console.ReadLine();
        }
    }
}
