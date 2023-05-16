using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace APIsAndJSON
{
    internal class RonVSKanyeAPI
    {
        public static void Convo()
        {
            HttpClient client = new HttpClient();

            for (int i = 0; i < 6; i++)
            {
                string kanyeURL = "https://api.kanye.rest/";
                string kanyeReponse = client.GetStringAsync(kanyeURL).Result;
                JObject kanyeObject = JObject.Parse(kanyeReponse);
                Console.WriteLine($"Kanye: {kanyeObject["quote"]}");

                Console.WriteLine();


                string ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
                string ronResponse = client.GetStringAsync(ronURL).Result;
                JArray ronObject = JArray.Parse(ronResponse);
                Console.WriteLine($"Ron: {ronObject[0]}");
                Console.WriteLine();
            }
            

        }
    }
}
