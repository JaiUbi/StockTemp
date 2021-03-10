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
            string IntervalChoice = "";
            
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
                Console.WriteLine("Choose a timeframe: " + "\n1: Daily" + "\n2: Intraday");
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
                        
                        AlphaConnect conn = new AlphaConnect("connect");
                        conn.ImportToCSVDaily(Ticker);
                        DataFrame df = DataFrame.LoadCsv("calledData.csv");

                        CsvToDataTable obj = new CsvToDataTable();
                        DataTable dtData = obj.ConvertCsvToDataTable("calledData.csv");
                        obj.ShowData(dtData);
                        a = true;
                        break;

                    case "2":
                        Console.WriteLine("Choose the intervals: " + "\n1: 1 Minute:" + "\n2: 5 Minutes" + "\n3: 15 Minutes" + "\n4: 30 Minutes" + "\n5: 60 Minutes");
                        string Interval = Console.ReadLine();
                        switch (Interval)
                        {
                            case "1":
                                IntervalChoice = "1 Minute";
                                AlphaConnect._minute = "1min";
                                break;
                            case "2":
                                IntervalChoice = "5 Minutes";
                                AlphaConnect._minute = "5min";
                                break;
                            case "3":
                                IntervalChoice = "15 Minutes";
                                AlphaConnect._minute = "15min";
                                break;
                            case "4":
                                IntervalChoice = "30 Minutes";
                                AlphaConnect._minute = "30min";
                                break;
                            case "5":
                                IntervalChoice = "60 Minutes";
                                AlphaConnect._minute = "60min";
                                break;
                        }
                        Console.Clear();
                        Console.WriteLine(
                            "Your ticker is: " + Ticker +
                            "\nYour selected timeframe is: " + IntervalChoice +
                            "\nPlease Wait..."
                            );

                        
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