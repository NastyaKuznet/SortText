using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortText.Model.ABCSortF
{
    public class ItemWordTracker
    {
        private int _id;
        private string _content;
        private int _tracker;
        public int ID { get { return _id; } }
        public string Content { get { return _content; } set { _content = value; } }
        public int Tracker { get { return _tracker;} set { _tracker = value; } }

        public ItemWordTracker(int id, string content, int tracker)
        {
            _id = id;
            _content = content;
            _tracker = tracker;
        }
    }
}
