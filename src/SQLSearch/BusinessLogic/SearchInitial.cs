using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;
using System.Linq;
using DataAccess;
using BusinessLogic.Models;

namespace BusinessLogic
{
    public class SearchInitial
    {
        string searchText;
        string author;
        string repoLocation;
        Dictionary<string,bool> excludedTags;
        public SearchInitial(string searchText, string author, string repoLocation)
        {
            this.searchText = searchText;
            this.author = author;
            this.repoLocation = repoLocation;
            excludedTags = StopWords.getEnglishStopWords();
        }
        public List<ScriptInfo> Run()
        {

            string[] fileNames = getAllFileNames(repoLocation);
            var filesThatMatch = new List<ScriptInfo>();
            foreach(string fileName in fileNames)
            {
                var scriptInfo = buildScriptInfo(repoLocation + "\\"+fileName);
                if (!author.Equals("") && !validateAuthor(scriptInfo, author)) {
                    continue;
                    /*
                    var validAuthor = validateAuthor(author, fileName);
                    if (!validAuthor)
                        continue;
                        
                    else if (searchText.Equals(""))
                            filesThatMatch.Add(fileName, 1);*/
                }
                if (!searchText.Equals("")) {
                    if (!(scriptInfo.numMatches > 0))
                        continue;
                }
                filesThatMatch.Add(scriptInfo);
            }
            filesThatMatch.Sort();
            return filesThatMatch;
        }

        private int GetNumMatches(string searchText, ScriptInfo scriptInfo)
        {
            //var Tags = getTags(repoLocation + "\\" + fileName);
            searchText = searchText.Replace(",", "");
            var searchTags = searchText.Split(' ');
            return (scriptInfo.searchTags.Intersect(searchTags)).Count();
        }       
       
        private bool validateAuthor(ScriptInfo scriptInfo, string author)
        {
            return scriptInfo.Author.Equals(author, StringComparison.CurrentCultureIgnoreCase);
        }
        
        private ScriptInfo buildScriptInfo(string filePath)
        {
            ScriptInfo returnVal = new ScriptInfo();
            returnVal.description = "";
            var fileLines = File.ReadAllLines(filePath);
            var tagsRegex = new Regex(@"(--|/\*)*\s*Tags\s*:", RegexOptions.IgnoreCase);
            var descRegex = new Regex(@"(--|/\*)*\s*Description\s*:", RegexOptions.IgnoreCase);
            var AuthorRegex = new Regex(@"(--*|/\*)*\s*Author\s*:", RegexOptions.IgnoreCase);
            foreach (string line in fileLines)
            {                
                if (AuthorRegex.IsMatch(line.Trim()))
                {
                    var newLine = AuthorRegex.Replace(line.Trim(), "").Trim();
                    returnVal.Author = newLine;
                }
                else if (tagsRegex.IsMatch(line.Trim()))
                {
                    var newLine = tagsRegex.Replace(line.Trim(), "");
                    foreach (string tag in newLine.Split(','))
                    {

                        var processedTag = tag.Replace(",", "").Replace("\\t", "").Replace("*/","").ToLower().Trim();
                        if (!excludedTags.ContainsKey(tag))
                        {
                            returnVal.tags.Add(processedTag);
                            returnVal.searchTags.Add(processedTag);
                        }
                    }
                }
                else if (descRegex.IsMatch(line.Trim()))
                {
                    var newLine = descRegex.Replace(line.Trim(), "");
                    returnVal.description = returnVal.description + newLine;
                    foreach (string tag in newLine.Split(' '))
                    {
                        if (!excludedTags.ContainsKey(tag))
                        {
                            var processedTag = tag.ToLower().Trim().Replace(". ", "");
                            returnVal.searchTags.Add(processedTag);
                        }
                    }
                }
            }
            var IndexOfFileName = filePath.LastIndexOf("\\");

            var fileName = filePath.Substring(IndexOfFileName+1);
            returnVal.fileName = fileName;

            var fileNameTags = Regex.Split(fileName, @"(?=\p{Lu}\p{Ll})|(?<=\p{Ll})(?=\p{Lu})");
            foreach (string tag in fileNameTags)
                if (!excludedTags.ContainsKey(tag))
                    returnVal.searchTags.Add(tag.ToLower());
            returnVal.numMatches = GetNumMatches(searchText, returnVal);
            return returnVal;
        }

        private string[] getAllFileNames(string repo)
        {            
            DirectoryInfo d = new DirectoryInfo(repo);

            FileInfo[] Files = d.GetFiles("*.sql");
            List<string> fileNames = new List<string>();

            foreach (FileInfo file in Files)
            {
                fileNames.Add(file.Name);
            }
            return fileNames.ToArray();
        }
    }
}
