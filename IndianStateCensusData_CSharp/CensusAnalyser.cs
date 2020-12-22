using System;
using System.Collections.Generic;
using IndianStateCensusData_CSharp.POCO;

namespace IndianStateCensusData_CSharp.DTO
{
    public class CensusAnalyser
    {
        public enum Country
        {
            INDIA, US, BRAZIL
        }
        Dictionary<string, CensusDTO> dataMap;

        /// <summary>
        /// Loading CSV file data using Dictionary.
        /// </summary>
        /// <param name="country">Country_Name</param>
        /// <param name="csvFilePath">File_Path</param>
        /// <param name="dataHeaders">Header Of CSV file Data.</param>
        /// <returns></returns>
        
        public Dictionary<string, CensusDTO> LoadCensusData(Country country, string csvFilePath, string dataHeaders)
        {
            dataMap = new CSVAdapterFactory().LoadCsvData(country, csvFilePath, dataHeaders);
            return dataMap;
        }
    }
}
