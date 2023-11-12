using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortText.Model
{
    public class CounterWord
    {
        public Dictionary<string, int> CountWord(string[] words)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            foreach(string word in words)
            {
                if(dictionary.ContainsKey(word))
                {
                    dictionary[word] += 1;     
                }
                else
                {
                    dictionary.Add(word, 1);
                }
            }
            return dictionary;
        }
    }
}
