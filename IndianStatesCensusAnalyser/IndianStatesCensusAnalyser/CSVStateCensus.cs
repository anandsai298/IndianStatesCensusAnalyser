using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStatesCensusAnalyser
{
    public class CSVStateCensus
    {
        public int ReadStateCensusData(string filepath)
        {
            using (var reader = new StreamReader(filepath))
            using (var csvreader = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csvreader.GetRecords<StateCensusDAO>().ToList();
                foreach (var record in records)
                {
                    Console.WriteLine(record);
                }
                return records.Count() - 1;//-1 because remove the header line
            }
        }
    }
}
