using NUnit.Framework;
using System.Collections.Generic;
using IndianStateCensusData_CSharp.DTO;
using IndianStateCensusData_CSharp.POCO;
using IndianStateCensusData_CSharp;
using static IndianStateCensusData_CSharp.DTO.CensusAnalyser;

namespace CensusAnalyserTest
{
    public class CensusDataTest
    {

        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indiaStateCensusFilePath = @"C:\Users\NKS\Desktop\CSharp Git problems\IndianStateCensusData_CSharp\CensusAnalyserTest\Files\IndiaStateCensesData.csv";
        static string wrongIndiaStateCensusFilePath = @"C:\Users\NKS\Desktop\CSharp Git problems\IndianStateCensusDemo\CensusAnalyserTest\Files\WrongIndiaStateCensesData.csv";
        static string wrongIndianStateCensusFileType = @"C:\Users\NKS\Desktop\CSharp Git problems\IndianStateCensusData_CSharp\CensusAnalyserTest\Files\WrongIndiaStateCensesData.txt";
        static string delimiterIndianCensusData = @"C:\Users\NKS\Desktop\CSharp Git problems\IndianStateCensusData_CSharp\CensusAnalyserTest\Files\DelimiterIndianCensusData.csv";
        static string wrongHeaderIndianStateCensusData = @"C:\Users\NKS\Desktop\CSharp Git problems\IndianStateCensusData_CSharp\CensusAnalyserTest\Files\WrongHeaderIndianStateCensusData.csv";

        static string indianStateCodeHeaders = "SrNo,StateName,TIN,StateCode";
        static string indianStateCodeFilePath = @"C:\Users\NKS\Desktop\CSharp Git problems\IndianStateCensusData_CSharp\CensusAnalyserTest\Files\IndianStateCodeCensus.csv";
        static string wrongIndianStateCodeFilePath = @"C:\Users\NKS\Desktop\CSharp Git problems\IndianStateCensusDemo\CensusAnalyserTest\Files\WrongIndiaStateCensesData.csv";
        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
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

        /// <summary>
        /// Test Case 1.2 Given the indian census data file when incorrect then return File not found exception.
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFile_WhenIncorrect_ThenShouldReturnFileNotFoundException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndiaStateCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
        }

        /// <summary>
        /// Test Case 1.3 Given the indian census data csv file when correct but type incoorect then return invalid file type exception.
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFile_WhenCorrect_ThenShouldReturnInvalidFileTypeException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusFileType, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }

        /// <summary>
        /// Test Case 1.4 Given the indian census data csv file when correct but delimiter incoorect then return incorrect delimiter exception.
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFileCorrect_WhenDelimiterIncorrect_ThenShouldReturnInvalidDelimiterException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, delimiterIndianCensusData, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }

        /// <summary>
        /// Test Case 1.5 Given the indian census data csv file when correct but header incoorect then return incorrect delimiter exception.
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFileCorrect_WhenHeaderIncorrect_ThenShouldReturnInvalidHeaderException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderIndianStateCensusData, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }

        /// <summary>
        /// Test Case 2.1 Given the indian state code file when reader should return state code data count.
        /// </summary>
        [Test]
        public void GivenIndianStateCodeCsvFile_WhenRead_ThenShouldReturnStateCodeDataCount()
        {
            stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(37, stateRecord.Count);
        }

        /// <summary>
        /// Test Case 2.2 Given the indian state code file when incorrect then return File not found exception.
        /// </summary>
        [Test]
        public void GivenIndianStateCodeCsvFile_WhenIncorrect_ThenShouldReturnFileNotFoundException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
        }
    }
}