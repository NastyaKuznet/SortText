using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortText.Model
{
    public class Converter
    {
        public ObservableCollection<string> MassInObsColl(string[] lines)
        {
            ObservableCollection<string> collection = new ObservableCollection<string>();
            foreach (string line in lines)
            {
                collection.Add(line);
            }
            return collection;
        }

        public string[] ObsCollInMassWorld(ObservableCollection<string> collection)
        {
            List<string> result = new List<string>();
            foreach(string element in collection)
            {
                string[] line = element.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach(string word in line)
                {
                    result.Add(word);
                }
            }
            return result.ToArray();
        }

        public ObservableCollection<string> MassWordsInObsColl(string[] words)
        {
            ObservableCollection<string> collection = new ObservableCollection<string>();
            StringBuilder stringBuilder = new StringBuilder();
            foreach (string line in words)
            {
                stringBuilder.Append(line);
            }
            collection.Add(stringBuilder.ToString());
            return collection;
        }

        public DataTable DictInDataTable(Dictionary<string, int> dict)
        {
            DataTable result = new DataTable();
            DataColumn word = new DataColumn();
            word.ColumnName = "word";
            word.ReadOnly = true;
            result.Columns.Add(word);
            DataColumn count = new DataColumn();
            count.ColumnName = "count";
            count.ReadOnly = true;
            result.Columns.Add(count);
            foreach(string key in dict.Keys)
            {
                DataRow row = result.NewRow();
                row[0] = key;
                row[1] = dict[key];
                result.Rows.Add(row);
            }
            return result;
        }

        public string[] LineInMassWordWithoutSign(string line)
        {
            List<string> result = new List<string>();
            StringBuilder newWord = new StringBuilder();
            foreach (char letter in line)
            {
                if (letter >= 'a' && letter <='z')
                    newWord.Append(letter);
                if (letter.Equals(' '))
                {
                    if (newWord.Length == 0) continue;
                    result.Add(newWord.ToString());
                    newWord.Clear();
                }
            }
            return result.ToArray();
        }
    }
}
