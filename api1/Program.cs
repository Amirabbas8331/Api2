
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace API
{
    public class Program
    {
        public async void Main()
        {
            HttpClient Apiclient = new HttpClient();
            string url = "http://api.kucoin.com/api/v1/market/stats?symbol=BTC-USTD";
            HttpResponseMessage respons = await Apiclient.GetAsync(url);
            if (respons.IsSuccessStatusCode)
            {
                string apirespons = await respons.Content.ReadAsStringAsync();
                Console.WriteLine(apirespons);
                Console.WriteLine();
                Root Deserialize = JsonConvert.DeserializeObject<Root>(apirespons);
                List<Data> data = Deserialize.data;
                foreach (var item in data)
                {
                    Console.WriteLine($"Time:{item.time}");
                    Console.WriteLine($"");
                    Console.WriteLine($"");
                    Console.WriteLine($"");

                }
            }
        }
    }
    public class Data
    {
        public long time { get; set; }
        public string symbol { get; set; }
        public object buy { get; set; }
        public object sell { get; set; }
        public object changeRate { get; set; }
        public object changePrice { get; set; }
        public object high { get; set; }
        public object low { get; set; }
        public object vol { get; set; }
        public object volValue { get; set; }
        public object last { get; set; }
        public object averagePrice { get; set; }
        public object takerFeeRate { get; set; }
        public object makerFeeRate { get; set; }
        public object takerCoefficient { get; set; }
        public object makerCoefficient { get; set; }
    }

    public class Root
    {
        public string code { get; set; }
        public List<Data> data { get; set; }
    }


}