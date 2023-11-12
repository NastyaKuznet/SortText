using SortText.Model.ABCSortF;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Resources.ResXFileRef;

namespace SortText.Model
{
    public class AnalizerText
    {
        private Converter _converter = new Converter();
        private string done = "Готово!";

        private string result;
        public string Result { get { return result; } }


        public void DoAnaliz(string lines, string nameSort, int count, string path)
        {
            ChoiceAnaliz(_converter.LineInMassWordWithoutSign(lines), nameSort, count, path);
        }

        private void ChoiceAnaliz(string[] words, string nameSort, int count, string path)
        {
            switch (nameSort)
            {
                case ("Bubble Sort"):
                    BubbleSort bubbleSort = new BubbleSort();
                    WorkingForm1(bubbleSort.DoBubbleSort, "\\BubbleSort" + count, words, count, path);
                    result = done;
                    break;
                case ("ABC Sort"):
                    ABCSort aBCSort = new ABCSort();
                    WorkingForm2(aBCSort.DoABCSort, "\\ABCSort" + count, words, count, path);
                    result = done;
                    break;
            }
        }

        private delegate string[] MassivInMassiv(string[] vector);
        private delegate void MassivInVoid(string[] vector);
        private void WorkingForm1(MassivInMassiv method, string nameFile, string[] lines, int counts, string path)
        {
            List<double> results = new List<double>();
            var watсh = new Stopwatch();
            for (int n = 1; n <= lines.Length; n = n + counts)
            {
                watсh.Reset();
                double sumWorks = 0;

                for (int count = 0; count < 5; count++)
                {
                    string[] vector = CreateVector(n, lines);
                    watсh.Start();
                    method(vector);
                    watсh.Stop();
                    double s = (double)watсh.Elapsed.TotalSeconds;
                    //Console.WriteLine($"n = {n} : {s.ToString("F8")}");
                    sumWorks += s;
                }
                results.Add((double)(sumWorks) / 5.0);
                IntermediateSave interSave = new IntermediateSave();
                interSave.ExtraSaving(n, results.ToArray(), nameFile, counts, path);
            }
            FileProcessing fileProcessing = new FileProcessing();
            File.WriteAllLines(path + nameFile + ".csv", fileProcessing.GetValues(results.ToArray(), 1));
        }

        private void WorkingForm2(MassivInVoid method, string nameFile, string[] lines, int counts, string path)
        {
            List<double> results = new List<double>();
            var watсh = new Stopwatch();
            for (int n = 1; n <= lines.Length; n = n + counts)
            {
                watсh.Reset();
                double sumWorks = 0;

                for (int count = 0; count < 5; count++)
                {
                    string[] vector = CreateVector(n, lines);
                    watсh.Start();
                    method(vector);
                    watсh.Stop();
                    double s = (double)watсh.Elapsed.TotalSeconds;
                    //Console.WriteLine($"n = {n} : {s.ToString("F8")}");
                    sumWorks += s;
                }
                results.Add((double)(sumWorks) / 5.0);
                IntermediateSave interSave = new IntermediateSave();
                interSave.ExtraSaving(n, results.ToArray(), nameFile, counts, path);
            }
            FileProcessing fileProcessing = new FileProcessing();
            File.WriteAllLines(path + nameFile + ".csv", fileProcessing.GetValues(results.ToArray(), 1));
        }

        public static string[] CreateVector(int n, string[] array)
        {
            string[] newArray = new string[n];
            for (int i = 0; i < n; i++)
            {
                newArray[i] = array[i];
            }
            return newArray;
        }
    }
}
