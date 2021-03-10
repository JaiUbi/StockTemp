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
        public string Ticker { get; set; }
        public string TimeFrame { get; set; }
        public string TimeFrameOutput { get; set; }
        private readonly string _apiKey;


        public AlphaConnect(string apiKey)
        {

            this._apiKey = "AIIPH2TZ7PVCRVP2";
        }

        public void ImportToCSV(string symbol)

        { 
                
                HttpWebRequest? req = (HttpWebRequest)WebRequest.Create(Ticker.decoded);
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                StreamReader sr = new StreamReader(resp.GetResponseStream());
                string results = sr.ReadToEnd();
                sr.Close();
                File.WriteAllText("calledData.csv", results);
            }
           
}
    }


    
