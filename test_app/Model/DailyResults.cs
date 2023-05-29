using System;
using System.Net.Http;
using System.Xml.Linq;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

namespace test_api.Model
{
    public class DailyResults
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            string xmlUrl = "https://www.nationallottery.co.za/xmlfeed/dailylotto.xml";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(xmlUrl);
                if (response.IsSuccessStatusCode)
                {
                    string xmlData = await response.Content.ReadAsStringAsync();
                    XDocument xmlDoc = XDocument.Parse(xmlData);
                    string jsonData = JsonConvert.SerializeXNode(xmlDoc, Formatting.Indented);
                    Console.WriteLine(jsonData);
                }
                else
                {
                    Console.WriteLine("Error retrieving XML data. Status code: " + response.StatusCode);
                }
            }
        }
    }
}
