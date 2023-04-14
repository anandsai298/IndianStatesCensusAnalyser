using CsvHelper;
using System;
using System.Globalization;

namespace IndianStatesCensusAnalyser
{
    public class StateCensusAnalyser
    {
        public int ReadStateCensusData(string filepath)
        {
            if (!File.Exists(filepath))
                throw new StateCensusException(StateCensusException.ExceptionType.FILE_INCORRECT, "File path is INCORRECT");
            if(!filepath.EndsWith(".CSV"))
                throw new StateCensusException(StateCensusException.ExceptionType.FILE_INCORRECT, "File path is INCORRECT");
            var read=File.ReadAllLines(filepath);
            string header = read[0];
            if(header.Contains("/"))
                throw new StateCensusException(StateCensusException.ExceptionType.DELIMETER_INCORRECT, "INCORRECT DELIMETER");
            using (var reader=new StreamReader(filepath))
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
        public bool ReadStateCensusData(string filepath,string actualHeader)
        {
            var read=File.ReadAllLines(filepath);
            string header = read[0];
            if (header.Equals(actualHeader))
                return true;
            else 
                throw new StateCensusException(StateCensusException.ExceptionType.HEADER_INCORRECT,"header is incorrect");
        }
    }
}