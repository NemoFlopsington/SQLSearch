using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;
using System.Linq;
using DataAccess;

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
        public Dictionary<string, int> run()
        {

            string[] fileNames = getAllFileNames(repoLocation);
            var filesThatMatch = new Dictionary<string,int>();
            foreach(string fileName in fileNames)
            {
                if (!author.Equals("")) {
                    var validAuthor = validateAuthor(author, fileName);
                    if (!validAuthor)
                        continue;
                    else if (searchText.Equals(""))
                            filesThatMatch.Add(fileName, 1);
                }
                if (!searchText.Equals("")) {
                    var matchesSearchText = validateSearchText(searchText, fileName);
                    if (matchesSearchText.Count > 0)
                        filesThatMatch.Add(fileName,matchesSearchText.Count);
                }
            }
            return filesThatMatch;
        }

        private List<string> validateSearchText(string searchText, string fileName)
        {
            var Tags = getTags(repoLocation + "\\" + fileName);
            searchText = searchText.Replace(",", "").Replace("-", "");
            var searchTags = searchText.Split(' ');            
            return (List<string>)Tags.Intersect(searchTags);
        }
        private List<string> getTags(string fileName)
        {           
            var fileLines = File.ReadAllLines(fileName);
            var tags = new List<string>();
            var tagsRegex = new Regex(@"(--|/\*)*\s*Tags\s*:.*", RegexOptions.IgnoreCase);
            var descRegex = new Regex(@"(--|/\*)*\s*Description\s*:.*", RegexOptions.IgnoreCase);
            foreach (string line in fileLines)
            {
                if (tagsRegex.IsMatch(line.Trim()))
                {
                    var newLine = tagsRegex.Replace(line.Trim(), "");
                    foreach (string tag in newLine.Split(','))
                        if(!excludedTags.ContainsKey(tag))
                            tags.Add(tag.ToLower());
                }
                if (descRegex.IsMatch(line.Trim()))
                {
                    var newLine = descRegex.Replace(line.Trim(), "");
                    foreach (string tag in newLine.Split(' '))
                    {
                        var newTag = tag.Replace(",", "");
                        if (!excludedTags.ContainsKey(tag))
                            tags.Add(newTag.ToLower());
                    }
                }
            }
            var fileNameTags = Regex.Split(fileName, @"(?=\p{Lu}\p{Ll})|(?<=\p{Ll})(?=\p{Lu})");
            foreach(string tag in fileNameTags)
                tags.Add(tag);
            return tags;
        }
       
        private bool validateAuthor(string auth, string fileName)
        {
            var lines = File.ReadAllLines(repoLocation + "\\" + fileName);
            var AuthorRegex = new Regex(@"(--*|/\*)*\s*Author\s*:", RegexOptions.IgnoreCase);
            foreach (var line in lines)
            {
                if (AuthorRegex.IsMatch(line.Trim()))
                {
                    var newLine = AuthorRegex.Replace(line.Trim(), "");
                    return newLine.Contains(auth);
                }
            }
            return false;
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
