using System;
using System.IO;
using System.Net;
using Microsoft.Data.Analysis;

namespace StockTemp
{
    class Program
    {
        static void Main(string[] args)
        {
            AlphaConnect conn = new AlphaConnect("connect");
            conn.ImportToCSV("cxr");
            DataFrame df = DataFrame.LoadCsv("calledData.csv");
            Console.WriteLine(df);
            

        }
    }

    public class AlphaConnect
    {
        private readonly string _apiKey;


        public AlphaConnect(string apiKey)
        {

            this._apiKey = "AIIPH2TZ7PVCRVP2";
        }

        public void ImportToCSV(string symbol)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://" + $@"www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol={symbol}&apikey={this._apiKey}&datatype=csv");
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string results = sr.ReadToEnd();
            sr.Close();
            File.WriteAllText("calledData.csv", results);
        }
    }

}
