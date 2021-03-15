using System;
using System.IO;
using System.Net;
using System.Data;
using System.Text;
using Microsoft.Data.Analysis;
using DataRead;

namespace APIConnect
{
    public class AlphaConnect
    {
       // Initialise project-wide variables
        public readonly string _apiKey;  // read-only, as APIKey should be private
        public static string _minute;
              
    
         public AlphaConnect(string apiKey) // creates method containing a definition for APIKey
        {

            _apiKey = "AIIPH2TZ7PVCRVP2";
            
        }
        
        // creating methods for each timeframe

        public void ImportToCSVDaily(string symbol)  // daily timeframe

        { 
        
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://" + $@"www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol={symbol}&apikey={_apiKey}&datatype=csv");
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                StreamReader sr = new StreamReader(resp.GetResponseStream());
                string results = sr.ReadToEnd();
                sr.Close();
                File.WriteAllText("calledData.csv", results);
            }
        public void ImportToCSVIntraDay(string symbol) // intraday timeframe

        {

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://" + $@"www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol={symbol}&interval={_minute}&apikey={_apiKey}&datatype=csv");
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string results = sr.ReadToEnd();
            sr.Close();
            File.WriteAllText("calledData.csv", results);
        }

        public void ImportToCSVCurrent(string symbol) // Todays Trading timeframe

        {

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://" + $@"www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol={symbol}&apikey={_apiKey}&datatype=csv");
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string results = sr.ReadToEnd();
            sr.Close();
            File.WriteAllText("calledData.csv", results);
        }
    }
}


    
