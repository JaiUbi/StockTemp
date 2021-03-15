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
            // Initialising variables + increases window size to facilitate all data 
            Console.WindowWidth = 180;
            bool InLength = false;
            string Ticker = "";
            string IntervalChoice = "";
            
            do
            { 
                // Reads in Ticker input
                Console.WriteLine("Enter stock ticker: ");
                Ticker = Console.ReadLine();
                // Makes sure Ticker length is less than 6 otherwise loops and restarts
                if (Ticker.Length < 6)
                {
                    InLength = true;
                }
                else
                {
                    Console.WriteLine("Invalid Ticker Retry");
                    InLength = false;
                }
            } while (InLength == false); // If ticker length is valid program continues
            bool a = false;
            do
            {
                Console.WriteLine("Choose a timeframe: " + "\n1: Todays Trading" + "\n2: Intraday" + "\n3: Daily");
                string TimeFrame = Console.ReadLine();
                switch (TimeFrame)
                {
                    case "1":
                        Console.Clear();
                        AlphaConnect conn = new AlphaConnect("connect"); // calls the variable conn from APIConnect class
                        conn.ImportToCSVCurrent(Ticker);
                        DataFrame df = DataFrame.LoadCsv("calledData.csv"); // imports the csv file containing stock data into a dataframe

                        CsvToDataTable obj = new CsvToDataTable(); // calls CSVtoDataTable Method
                        DataTable dtData = obj.ConvertCsvToDataTable("calledData.csv");
                        obj.ShowData(dtData); // outputs data
                        a = true;
                        break;
                    case "2": // secondary menu
                        Console.WriteLine(
                            "Choose the intervals: " +
                            "\n1: 1 Minute:" +
                            "\n2: 5 Minutes" +
                            "\n3: 15 Minutes" +
                            "\n4: 30 Minutes" +
                            "\n5: 60 Minutes"
                            );
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


                        conn = new AlphaConnect("connect"); // calls the variable conn from APIConnect class
                        conn.ImportToCSVIntraDay(Ticker);
                        df = DataFrame.LoadCsv("calledData.csv"); // imports the csv file containing stock data into a dataframe

                        obj = new CsvToDataTable(); // calls CSVtoDataTable Method
                        dtData = obj.ConvertCsvToDataTable("calledData.csv");
                        obj.ShowData(dtData); // outputs the stock data
                        a = true;
                        break;



                    case "3":
                        string choice = "Daily";
                        Console.Clear();
                        Console.WriteLine(
                            "Your ticker is: " + Ticker +
                            "\nYour selected timeframe is: " + choice +
                            "\nPlease Wait..."
                            );

                        conn = new AlphaConnect("connect"); // calls the variable conn from the APIConnect Class
                        conn.ImportToCSVDaily(Ticker);
                        df = DataFrame.LoadCsv("calledData.csv"); // imports the csv file containging stock data into a dataframe

                        obj = new CsvToDataTable(); // calls CSVtoDataTable Method
                        dtData = obj.ConvertCsvToDataTable("calledData.csv");
                        obj.ShowData(dtData); // outputs the stock data
                        a = true;
                     break;

            }
            } while (a == false);
        }
    }
}