using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortText.Model.ABCSortF
{
    public class ItemLetterTracker
    {
        private Dictionary<string, int> downLetterTracker = new Dictionary<string, int>();

        public Dictionary<string, int> DownLetterTracker { get { return downLetterTracker; } }

        public ItemLetterTracker() 
        {
            for(int i = 'a'; i <= 'z'; i++)
            {
                downLetterTracker[((char)i).ToString()] = 0;
            }
        }
    }
}
