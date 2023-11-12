using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortText.Model
{
    public class FileProcessing
    {
        public List<string> GetValues(double[] results, int step)
        {
            List<string> newResilt = new List<string>();
            newResilt.Add($"{1};{results[0]}");
            for (int i = 1; i < results.Length - 1; i++)
            {
                if ((results[i] != results[i + 1] || results[i] != results[i - 1]) && i % step == 0)
                {
                    newResilt.Add($"{i + 1};{results[i]}");
                }
            }
            newResilt.Add($"{results.Length};{results[results.Length - 1]}");
            return newResilt;
        }

        public List<string> GetValues(double[,] results, int step)
        {
            List<string> newResilt = new List<string>();
            for (int i = 0; i < results.GetLength(0); i++)
            {
                StringBuilder str = new StringBuilder();
                for (int j = 0; j < results.GetLength(0); j++)
                {
                    str.Append(results[i, j]);
                    str.Append(';');
                }
                newResilt.Add(str.ToString());
            }
            return newResilt;
        }
    }
}
