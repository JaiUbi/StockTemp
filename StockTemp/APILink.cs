using System;
using System.IO;
using System.Net;
using System.Data;
using System.Text;
using Microsoft.Data.Analysis;
using DataRead;


namespace StockTemp
{
    class APILink
    {
        static void Main(string[] args)
        {
            AlphaConnect conn = new AlphaConnect("connect");
            conn.ImportToCSV("AMC");
            DataFrame df = DataFrame.LoadCsv("calledData.csv");
            
            CsvToDataTable obj = new CsvToDataTable();
            DataTable dtData = obj.ConvertCsvToDataTable("calledData.csv");
            obj.ShowData(dtData);
        }
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


    


