using CsvHelper;
using System;
using System.Globalization;

namespace IndianStatesCensusAnalyser
{
    public class StateCensusAnalyser
    {
        public int ReadStateCensusData(string filepath)
        {
            using(var reader=new StreamReader(filepath))
            using(var csvreader=new CsvReader(reader,CultureInfo.InvariantCulture))
            {
                var records=csvreader.GetRecords<StateCensusDAO>().ToList();
                foreach(var record in records)
                {
                    Console.WriteLine(record);
                }
                return records.Count() -1;//-1 because remove the header line
            }
        }
    }
}