using IndianStatesCensusAnalyser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateCensusTestCases
{
    public class StateCodesUnitTest
    {
        public string StateCodesFilePath = @"F:\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\StateCensusTestCases\Files\StateCode - StateCode.CSV";
        public string StateCodesFilePathText = @"F:\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\StateCensusTestCases\Files\StateCode - StateCode .txt";
        public string StateCodesFilePathDelimeter = @"F:\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\StateCensusTestCases\Files\StateCode - StateCodeDelimeter.CSV";
        public string StateCodesFilePathHeader = @"F:\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\StateCensusTestCases\Files\StateCode - StateCodeHeader.CSV";
        [Test]
        public void GivenStateCodes_WhenAnalyse_ShouldReturnNoOfRecordsMatches()
        {
            StateCodesAnalyser code = new StateCodesAnalyser();
            CSVStateCodes csvcode = new CSVStateCodes();
            Assert.AreEqual(csvcode.ReadStateCodes(StateCodesFilePath), code.ReadStateCodes(StateCodesFilePath));
        }
        [Test]
        public void GivenStateCodesFileIncorrect_WhenAnalyse_ShouldReturnException()
        {
            StateCodesAnalyser code = new StateCodesAnalyser();
            try
            {
                int records = code.ReadStateCodes(StateCodesFilePathText);
            }
            catch (StateCodesException e)
            {
                Assert.AreEqual(e.Message, "File path is INCORRECT");
            }
        }
        [Test]
        public void GivenStateCodesFileDelimeter_WhenAnalyse_ShouldReturnException()
        {
            StateCodesAnalyser code = new StateCodesAnalyser();
            try
            {
                int records = code.ReadStateCodes(StateCodesFilePathDelimeter);
            }
            catch (StateCodesException ex)
            {
                Assert.AreEqual(ex.Message, "INCORRECT DELIMETER");
            }
        }
        [Test]
        public void GivenStateCodesFileHeader_WhenAnalyse_ShouldReturnException()
        {
            StateCodesAnalyser code = new StateCodesAnalyser();
            try
            {
                bool records = code.ReadStateCodesData(StateCodesFilePathHeader, "SrNo,State,Name,StateCode");
                Assert.IsTrue(records);
            }
            catch (StateCodesException e)
            {
                Assert.AreEqual(e.Message, "header is incorrect");
            }
        }
    }
}
