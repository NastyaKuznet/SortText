using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortText.Model
{
    public class IntermediateSave
    {
        public void ExtraSaving(int i, double[] results, string nameFile, int step, string path)
        {
            FileProcessing processing = new FileProcessing();
            if (i % 500 == 0)
            {
                File.WriteAllLines(path + nameFile + ".csv", processing.GetValues(results, step));
            }
        }
        public void ExtraSaving(int i, List<string> results, string nameFile, string path)
        {
            FileProcessing processing = new FileProcessing();
            if (i % 500 == 0)
            {
                File.WriteAllLines(path + nameFile + ".csv", results);
            }
        }

        public void ExtraSaving(int i, double[,] results, string nameFile, int step, string path)
        {
            FileProcessing processing = new FileProcessing();
            if (i % 500 == 0)
            {
                File.WriteAllLines(path + nameFile + ".csv", processing.GetValues(results, step));
            }
        }
    }
}
