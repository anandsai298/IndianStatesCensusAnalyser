using IndianStatesCensusAnalyser;
using NUnit.Framework;
namespace StateCensusTestCases
{
    public class Tests
    {
        public string StateCensusFilePath = @"F:\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\StateCensusTestCases\Files\StateCensusData - StateCensusData.CSV";
        public string StateCensusFilePathtext = @"F:\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\StateCensusTestCases\Files\StateCensusData - StateCensusData.txt";
        public string StateCensusFilePathDelimeter = @"F:\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\StateCensusTestCases\Files\StateCensusData - StateCensusData - .CSV";
        public string StateCensusFilePathHeader = @"F:\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\StateCensusTestCases\Files\StateCensusData - StateCensusDataHeader.csv";
        public string StateCodesFilePath = @"F:\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\StateCensusTestCases\Files\StateCode - StateCode.csv";
        [Test]
        public void GivenStateCensusData_WhenAnalyse_ShouldReturnNoOfRecordsMatches()
        {
            StateCensusAnalyser sca= new StateCensusAnalyser();
            CSVStateCensus csv=new CSVStateCensus();
            Assert.AreEqual(csv.ReadStateCensusData(StateCensusFilePath),sca.ReadStateCensusData(StateCensusFilePath));
        }
        [Test]
        public void GivenStateCensusDataFileIncorrect_WhenAnalyse_ShouldReturnException()
        {
            StateCensusAnalyser sca = new StateCensusAnalyser();
            try
            {
                int records = sca.ReadStateCensusData(StateCensusFilePathtext);
            }
            catch(StateCensusException e)
            {
                Assert.AreEqual(e.Message, "File path is INCORRECT");
            }
        }
        [Test]
        public void GivenStateCensusDataFileDelimeter_WhenAnalyse_ShouldReturnException()
        {
            StateCensusAnalyser sca = new StateCensusAnalyser();
            try
            {
                int records = sca.ReadStateCensusData(StateCensusFilePathDelimeter);
            }
            catch (StateCensusException ex)
            {
                Assert.AreEqual(ex.Message, "INCORRECT DELIMETER");
            }
        }
        [Test]
        public void GivenStateCensusDataFileHeader_WhenAnalyse_ShouldReturnException()
        {
            StateCensusAnalyser sca = new StateCensusAnalyser();
            try
            {
                bool records = sca.ReadStateCensusData(StateCensusFilePathHeader, "State,Population,AreaInSqKm,DensityPerSqKm");
                Assert.IsTrue(records);
            }
            catch (StateCensusException e)
            {
                Assert.AreEqual(e.Message, "header is incorrect");
            }
        }
    }
}