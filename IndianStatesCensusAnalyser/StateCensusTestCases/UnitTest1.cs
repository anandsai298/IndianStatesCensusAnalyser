using IndianStatesCensusAnalyser;
using NUnit.Framework;
namespace StateCensusTestCases
{
    public class Tests
    {
        public string StateCensusFilePath = @"F:\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\StateCensusTestCases\Files\StateCensusData - StateCensusData.csv";
        [Test]
        public void GivenStateCensusData_WhenAnalyse_ShouldReturnNoOfRecordsMatches()
        {
            StateCensusAnalyser sca= new StateCensusAnalyser();
            CSVStateCensus csv=new CSVStateCensus();
            Assert.AreEqual(csv.ReadStateCensusData(StateCensusFilePath),sca.ReadStateCensusData(StateCensusFilePath));
        }
    }
}