﻿using System;
using System.IO;
using System.Net;
using System.Data;
using System.Text;
using Microsoft.Data.Analysis;
using DataRead;
using APIConnect;


namespace StockTemp
{
    class Primary
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter stock ticker:");
            string Ticker = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine();


            AlphaConnect conn = new AlphaConnect("connect");
            conn.ImportToCSV(Ticker);
            DataFrame df = DataFrame.LoadCsv("calledData.csv");
          
            CsvToDataTable obj = new CsvToDataTable();
            DataTable dtData = obj.ConvertCsvToDataTable("calledData.csv");
             obj.ShowData(dtData);
        }
    }


        }
    


   

    


