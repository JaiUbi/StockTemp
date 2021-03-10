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
       
        public static string _apiKey;


        public AlphaConnect(string apiKey)
        {

            _apiKey = "AIIPH2TZ7PVCRVP2";
        }

        public void ImportToCSVDaily(string symbol)

        { 
        
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://" + $@"www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol={symbol}&apikey={_apiKey}&datatype=csv");
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                StreamReader sr = new StreamReader(resp.GetResponseStream());
                string results = sr.ReadToEnd();
                sr.Close();
                File.WriteAllText("calledData.csv", results);
            }
        public void ImportToCSVIntraDay(string symbol)

        {

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://" + $@"www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol={symbol}&interval=5min&apikey={_apiKey}&datatype=csv");
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string results = sr.ReadToEnd();
            sr.Close();
            File.WriteAllText("calledData.csv", results);
        }
    }
    }


    
