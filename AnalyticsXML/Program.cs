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

           

            Analytics analytics = new Analytics
            {
                CdsCount = cds.Count(),
                PricesSum = cds.ToArray().Sum(x => x.Price),
                MinYear = cds.Min(x => x.Year),
                MaxYear = cds.Max(x => x.Year),
                Artists = cds.Select(x => x.Artist).Distinct().ToList(),
                Companies = cds.Select(x => x.Company).Distinct().ToList(),
                Countries = cds.Select(x => x.Country).Distinct().ToList(),
                Titles = cds.Select(x => x.Title).Distinct().ToList()
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
