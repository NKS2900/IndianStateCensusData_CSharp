﻿using System;
using System.Collections.Generic;
using IndianStateCensusData_CSharp.POCO;
using System.Linq;

namespace IndianStateCensusData_CSharp
{
    public class IndianCensusAdapter : CensusAdapter
    {
        string[] censusData;
        Dictionary<string, CensusDTO> dataMap;

        /// <summary>
        /// Adding CSV file data into the Dictionary.
        /// </summary>
        /// <param name="csvFilePath"></param>
        /// <param name="dataHeaders"></param>
        /// <returns></returns>
        
        public Dictionary<string, CensusDTO> LoadCensusData(string csvFilePath, string dataHeaders)
        {
            dataMap = new Dictionary<string, CensusDTO>();
            censusData = GetCensusData(csvFilePath, dataHeaders);
            foreach (string data in censusData.Skip(1))
            {
                if (!data.Contains(","))
                {
                    throw new CensusAnalyserException("File Contains Wrong Delimiter", CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER);
                }
                string[] column = data.Split(",");
                
                if (csvFilePath.Contains("IndiaStateCensesData.csv"))
                    dataMap.Add(column[0], new CensusDTO(new CensusDataDAO(column[0], column[1], column[2], column[3])));
               
                if (csvFilePath.Contains("IndianStateCodeCensus.csv"))
                {
                    dataMap.Add(column[1], new CensusDTO(new StateCodeDAO(column[0], column[1], column[2], column[3])));
                }
            }
            return dataMap.ToDictionary(p => p.Key, p => p.Value);
        }
    }
}

