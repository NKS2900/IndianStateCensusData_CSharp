using NUnit.Framework;
using System.Collections.Generic;
using IndianStateCensusData_CSharp.DTO;
using IndianStateCensusData_CSharp.POCO;

using static IndianStateCensusData_CSharp.DTO.CensusAnalyser;

namespace CensusAnalyserTest
{
    public class CensusDataTest
    {

        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indiaStateCensusFilePath = @"C:\Users\NKS\Desktop\CSharp Git problems\IndianStateCensusDemo\CensusAnalyserTest\Files\IndiaStateCensesData.csv";

        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
        }

        /// <summary>
        /// Given Data Should Return CensusData Count.
        /// UC1_TC_1.1
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFile_WhenReade_ThenShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indiaStateCensusFilePath, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }
    }
}