using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class ScriptInfo : IComparable
    {
        public string fileName { get; set; }
        public string Author { get; set; }
        public string description { get; set; }        
        public List<string> tags { get; set; }        
        public List<string> searchTags { get; set; }
        public int numMatches { get; set; }
        public ScriptInfo()
        {
            tags = new List<string>();
            searchTags = new List<string>();
        }

        public int CompareTo(Object o)
        {
            var scriptInfo  = o as ScriptInfo;
            return numMatches.CompareTo(scriptInfo.numMatches);
        }
    }
}
