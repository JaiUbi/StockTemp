using APIConnect;
using DataRead;
using Microsoft.Data.Analysis;
using System;
using System.Data;


namespace StockTemp
{
    public class Primary
    {


        public static void Main(string[] args)
        {

            bool InLength = false;
            string Ticker = "";
            string TimeFrameOutput = "";
            do
            {
                Console.WriteLine("Enter stock ticker: ");
                Ticker = Console.ReadLine();
                if (Ticker.Length < 6)
                {
                    InLength = true;
                }
                else
                {
                    Console.WriteLine("Invalid Ticker Retry");
                    InLength = false;
                }
            } while (InLength == false);
            bool a = false;
            do
            {
                Console.WriteLine("Choose a timeframe: " + "\n1: Daily" + "\n2: Hourly");
                string TimeFrame = Console.ReadLine();
                switch (TimeFrame)
                {
                    case "1":
                        string choice = "Daily";
                        Console.Clear();
                        Console.WriteLine(
                            "Your ticker is: " + Ticker +
                            "\nYour selected timeframe is: " + choice +
                            "\nPlease Wait..."
                            );
                        TimeFrameOutput = $@"https://" + $@"www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol={Ticker}&apikey={APIConnect.AlphaConnect._apiKey}&datatype=csv";
                        AlphaConnect conn = new AlphaConnect("connect");
                        conn.ImportToCSVDaily(Ticker);
                        DataFrame df = DataFrame.LoadCsv("calledData.csv");

                        CsvToDataTable obj = new CsvToDataTable();
                        DataTable dtData = obj.ConvertCsvToDataTable("calledData.csv");
                        obj.ShowData(dtData);
                        a = true;
                        break;

                    case "2":
                        choice = "Hourly";
                        Console.Clear();
                        Console.WriteLine(
                            "Your ticker is: " + Ticker +
                            "\nYour selected timeframe is: " + choice +
                            "\nPlease Wait..."
                            );

                        TimeFrameOutput = $@"https://" + $@"www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol={Ticker}&apikey={APIConnect.AlphaConnect._apiKey}&datatype=csv";
                        conn = new AlphaConnect("connect");
                        conn.ImportToCSVIntraDay(Ticker);
                        df = DataFrame.LoadCsv("calledData.csv");

                        obj = new CsvToDataTable();
                        dtData = obj.ConvertCsvToDataTable("calledData.csv");
                        obj.ShowData(dtData);
                        a = true;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine(
                            "Invalid Entry" +
                            "\nYour selected ticker is {0}", Ticker
                            );
                        break;
                }
            } while (a == false);
        }
    }
}