using System;
using System.IO;
using System.Net;
using System.Data;
using System.Text;
using Microsoft.Data.Analysis;
using DataRead;
using APIConnect;


namespace StockTemp
{
    public class Primary
    {
        

         public static void Main(string[] args)
        {

            Console.WriteLine("Enter stock ticker: ");
            string? Ticker = Console.ReadLine();
            Console.WriteLine("Enter Timeframe: ");
            string? TimeFrame = Console.ReadLine();
            if(TimeFrame == "daily")
            {
                string? TimeFrameOutput = "https://" + $@"www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol={Ticker}&apikey=AIIPH2TZ7PVCRVP2&datatype=csv";
            }
            else
            {
                string? TimeFrameOutput = "https://" + $@"www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol={Ticker}&apikey=AIIPH2TZ7PVCRVP2&datatype=csv";
            }

            

            AlphaConnect conn = new AlphaConnect("connect");
            conn.ImportToCSV(Ticker);
            DataFrame df = DataFrame.LoadCsv("calledData.csv");
          
            CsvToDataTable obj = new CsvToDataTable();
            DataTable dtData = obj.ConvertCsvToDataTable("calledData.csv");
             obj.ShowData(dtData);
        }
    }


        }
    


   

    


