﻿using System;
using System.IO;
using System.Data;
using System.Text;

namespace DataRead
{


   
       public class CsvToDataTable
            
        {
             
            public DataTable ConvertCsvToDataTable(string filepath)
            {
            string blank = "       ";
                string[] rows = File.ReadAllLines(filepath);

                DataTable dtData = new DataTable();
                string[] rowvalues = null;
                DataRow dr = dtData.NewRow();

                if (rows.Length > 0)
                {
                    foreach (string columnName in rows[0].Split(','))
                        dtData.Columns.Add(columnName + blank);

                }

                for (int row = 1; row < rows.Length; row++)
                {
                    rowvalues = rows[row].Split(',');
                    dr = dtData.NewRow();
                    dr.ItemArray = rowvalues;
                    dtData.Rows.Add(dr);

                }

                return dtData;
            }

            public void ShowData(DataTable dtData)
                {
                    if (dtData != null && dtData.Rows.Count > 0)
                    {
                        foreach (DataColumn dc in dtData.Columns)
                        {



                            Console.Write(dc.ColumnName + " ");
                        }
                        Console.WriteLine("\n----------------------------------------------------------------------------------------------------------------------------------");

                        foreach (DataRow dr in dtData.Rows)
                        {
                            foreach (var item in dr.ItemArray)
                            {
                                Console.Write(item.ToString() + "       ");

                            }
                            Console.Write("\n");
                        }
                        Console.ReadKey();
                    }
                }

            }
        }
    

    




