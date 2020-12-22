using System;
using System.Collections.Generic;
using IndianStateCensusData_CSharp.DTO;
using IndianStateCensusData_CSharp.POCO;

namespace IndianStateCensusData_CSharp
{
    public class CSVAdapterFactory
    {
        /// <summary>
        /// Loading CSV file 
        /// </summary>
        /// <param name="country">Country_Name</param>
        /// <param name="csvFilePath">File Path</param>
        /// <param name="dataHeaders">Header Of CSV file data</param>
        /// <returns></returns>
        public Dictionary<string, CensusDTO> LoadCsvData(CensusAnalyser.Country country, string csvFilePath, string dataHeaders)
        {
            switch (country)
            {
                case (CensusAnalyser.Country.INDIA):
                    return new IndianCensusAdapter().LoadCensusData(csvFilePath, dataHeaders);
                default:
                    throw new CensusAnalyserException("No Such Country", CensusAnalyserException.ExceptionType.NO_SUCH_COUNTRY);
            }
        }
    }
}
