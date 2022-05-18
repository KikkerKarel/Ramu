using CsvHelper;
using HtmlAgilityPack;
using System.IO;
using System.Collections.Generic;
using System.Globalization;

namespace API.Microservice.Util
{
    public class Webscraper : IWebScaper
    {
        public List<Row> Scrape()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load("https://open.spotify.com/artist/2vjeuQwzSP5ErC1S41gONX");

            //var nodes = doc.DocumentNode.SelectNodes("//div[@id='main']");
            var nodes = doc.DocumentNode.SelectNodes("//div[@id='main']//@div");
            var nodes2 = doc.DocumentNode.SelectSingleNode("/html/body/div[4]/div/div[2]/div[3]/div[1]/div[1]/div");

            var titles = new List<Row>();
            foreach (HtmlAgilityPack.HtmlNode node in nodes)
            {
                //HtmlNode div = node.SelectSingleNode("/html/body/div[4]/div/div[2]/div[3]/div[1]/div[1]/div/div[1]");

                //titles.Add(new Row { Title = item.InnerHtml });
            }

            using (var writer = new StreamWriter("Util/test.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(titles);
            }

            return titles;
        }
    }

    public class Row
    {
        public string Title { get; set; }
    }
}
