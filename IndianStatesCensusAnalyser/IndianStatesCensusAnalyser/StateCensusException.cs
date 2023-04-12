using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStatesCensusAnalyser
{
    public class StateCensusException:Exception
    {
        public enum ExceptionType
        {
            FILE_INCORRECT,TYPE_INCORRECT,DELIMETER_INCORRECT,HEADER_INCORRECT
        }
        public ExceptionType Type;
        public StateCensusException(ExceptionType Type,string message) : base(message)
        {
            this.Type = Type;
        }
    }
}
