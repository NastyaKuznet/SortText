using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortText.Model
{
    public class BubbleSort
    {
        public string[] DoBubbleSort(string[] words)
        {
            string temp;
            for (int i = 0; i < words.Length - 1; i++)
            {
                for (int j = 0; j < words.Length - i - 1; j++)
                {
                    if (words[j].CompareTo(words[j + 1]) > 0)
                    {
                        temp = words[j];
                        words[j] = words[j + 1];
                        words[j + 1] = temp;
                    }
                }
            }
            return words;
        }
    }
}
