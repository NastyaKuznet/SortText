using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SortText.Model.ABCSortF
{
    public class ABCSort
    {
        private Dictionary<string, int> unicNo = new Dictionary<string, int>();
        private List<ItemWordTracker> wordTracker = new List<ItemWordTracker>();
        private List<ItemLetterTracker> letterTracker = new List<ItemLetterTracker>();
        private Queue<int> ids = new Queue<int>();
        private List<string> result = new List<string>();
        public List<string> Result { get { return result; } }

        public void DoABCSort(string[] words)
        {
            DoBaseWordTracker(words.ToList<string>());
            Group(0);
            DoABCSortRec();
        }

        private void DoABCSortRec(int i = 1)
        {
            while (!IsEmptyLetterLine(i - 1))
            {
                DoNewIds(i);
                if (ids.Count == 1)
                {
                    Exit(i);
                    continue;
                }
                Group(i);
                DoABCSortRec(i + 1);
            }
            letterTracker.RemoveAt(letterTracker.Count - 1);
        }

        private void Exit(int i)
        {
            int id = ids.Dequeue() - 1;
            string word = wordTracker[id].Content;
            for (int j = 0; j < unicNo[word]; j++)
                result.Add(word);
            
            letterTracker[i - 1].DownLetterTracker[word[i - 1].ToString().ToLower()] = 0;
        }

        private void DoBaseWordTracker(List<string> container)
        {
            int i = 1;
            foreach(string word in container)
            {
                if (unicNo.ContainsKey(word))
                {
                    unicNo[word] += 1;
                }
                else
                {
                    unicNo.Add(word, 1);
                    ItemWordTracker itemWordTracker = new ItemWordTracker(i, word, 0);
                    wordTracker.Add(itemWordTracker);
                    ids.Enqueue(i);
                    i++;
                }
            }
        }

        private void Group(int i)
        {
            ItemLetterTracker itemLetterTracker = new ItemLetterTracker();
            while (ids.Count != 0)
            {
                int idCurrent = ids.Dequeue();
                ItemWordTracker word = wordTracker[idCurrent - 1];
                if(word.Content.Length == i)
                {
                    for (int j = 0; j < unicNo[word.Content]; j++)
                        result.Add(word.Content);
                    continue;
                }

                word.Tracker = itemLetterTracker.DownLetterTracker[word.Content[i].ToString().ToLower()];
                itemLetterTracker.DownLetterTracker[word.Content[i].ToString().ToLower()] = idCurrent;
            }
            letterTracker.Add(itemLetterTracker);
        }

        private string DoLetterToContain(int i)
        {
            foreach (string letter in letterTracker[i].DownLetterTracker.Keys)
            {
                if (letterTracker[i].DownLetterTracker[letter] != 0)
                    return letter;
            }
            return "!";
        }

        private bool IsEmptyLetterLine(int i)
        {
            foreach(string key in letterTracker[i].DownLetterTracker.Keys)
            {
                if (letterTracker[i].DownLetterTracker[key] != 0) return false;
            }
            return true;
        } 

        private void DoNewIds(int i)
        {
            string letter = DoLetterToContain(i - 1);
            ItemWordTracker current = wordTracker[letterTracker[i - 1].DownLetterTracker[letter] - 1];
            int id = current.ID;
            while (true)
            {
                ids.Enqueue(current.ID);
                id = current.Tracker;
                if (id == 0) break;
                current = wordTracker[current.Tracker - 1];
            }
            letterTracker[i - 1].DownLetterTracker[letter] = 0;
        }
    }
}
