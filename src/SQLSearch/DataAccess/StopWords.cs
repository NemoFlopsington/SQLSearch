using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public static class StopWords
    {
        public static Dictionary<string,bool> getEnglishStopWords()
        {
            string stopWordsDirectory = @"C:\Users\Nehemiah\Documents\coding stuff\SQLSearch\SQLSearch\src\SQLSearch\DataAccess\EnglishStopWords.txt";
             var stopWordList = System.IO.File.ReadAllLines(stopWordsDirectory)
                .Skip((1));
            Dictionary<string, bool> returnDict = new Dictionary<string, bool>();
            foreach(string word in stopWordList)
            {
                returnDict.Add(word, true);
            }
            return returnDict;
        }
    }
}
