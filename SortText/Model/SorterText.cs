using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SortText.Model.Converter;
using SortText.Model.ABCSortF;

namespace SortText.Model
{
    public class SorterText
    {
        private Converter _converter = new Converter();

        private string result;
        public string Result { get { return result; } }
        public void DoSort(string lines, string nameSort)
        {
            ChoiceSort(_converter.LineInMassWordWithoutSign(lines), nameSort);
        }

        private void ChoiceSort(string[] words, string nameSort)
        {
            switch (nameSort)
            {
                case ("Bubble Sort"):
                    BubbleSort bubbleSort = new BubbleSort();
                    result = string.Join(' ', bubbleSort.DoBubbleSort(words));
                    break;
                case ("ABC Sort"):
                    ABCSort aBCSort = new ABCSort();
                    aBCSort.DoABCSort(words);
                    result = string.Join(' ', aBCSort.Result.ToArray());
                    break;
            }
        }
    }
}
