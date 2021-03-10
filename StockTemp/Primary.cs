using System;
using System.IO;
using System.Net;
using System.Data;
using System.Text;
using Microsoft.Data.Analysis;
using DataRead;
using APIConnect;
using System.Web;



namespace StockTemp

{
    public class Ticker
    {
        public string decoded;
        
    }
}
    public class Primary
    {
        

         public static void Main(string[] args)
        {
            
            Console.WriteLine("Enter stock ticker: ");
            string Ticker = Console.ReadLine();
            Console.WriteLine("Enter Timeframe: ");
            string? TimeFrame = Console.ReadLine();
            
            if (TimeFrame == "daily")
            {
            
                var encoded = "https://" + $@"www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol={Ticker}&apikey=AIIPH2TZ7PVCRVP2&datatype=csv";
             var decoded = HttpUtility.HtmlDecode(encoded);
        }
            else
            {

            
            var encoded = "https://" + $@"www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol={Ticker}&apikey=AIIPH2TZ7PVCRVP2&datatype=csv";
             var decoded = HttpUtility.HtmlDecode(encoded);
        }




            AlphaConnect conn = new AlphaConnect("connect");
            conn.ImportToCSV(Ticker);
            DataFrame df = DataFrame.LoadCsv("calledData.csv");
          
            CsvToDataTable obj = new CsvToDataTable();
            DataTable dtData = obj.ConvertCsvToDataTable("calledData.csv");
             obj.ShowData(dtData);
        }
    }


    


   

    


