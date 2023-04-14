using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStatesCensusAnalyser
{
    public class StateCodesAnalyser
    {
        public int ReadStateCodes(string filepath)
        {

            if (!File.Exists(filepath))
                throw new StateCodesException(StateCodesException.ExceptionType.FILE_INCORRECT, "File path is INCORRECT");
            if (!filepath.EndsWith(".CSV"))
                throw new StateCodesException(StateCodesException.ExceptionType.FILE_INCORRECT, "File path is INCORRECT");
            var read = File.ReadAllLines(filepath);
            string header = read[0];
            if (header.Contains("/"))
                throw new StateCodesException(StateCodesException.ExceptionType.DELIMETER_INCORRECT, "INCORRECT DELIMETER");
            using (var reader = new StreamReader(filepath))
            using (var csvreader = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csvreader.GetRecords<StateCodesDAO>().ToList();
                foreach (var record in records)
                {
                    Console.WriteLine(record);
                }
                return records.Count() - 1;//-1 because remove the header line
            }
        }
        public bool ReadStateCodesData(string filepath, string actualHeader)
        {
            var read = File.ReadAllLines(filepath);
            string header = read[0];
            if (header.Equals(actualHeader))
                return true;
            else
                throw new StateCodesException(StateCodesException.ExceptionType.HEADER_INCORRECT, "header is incorrect");
        }
    }
}
