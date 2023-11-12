using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using static SortText.Model.CheckErrorText;

namespace SortText.Model
{
    public static class WorkerFiles
    {
        public static string CallFileDialog()
        {
            var dialog =  new Microsoft.Win32.OpenFileDialog();
            dialog.DefaultExt = ".txt";
            dialog.Filter = "Text documents (.txt)|*.txt";
            bool? result = dialog.ShowDialog();
            string fineName = "";
            if (result == true)
                fineName = dialog.FileName;

            return fineName;
        }

        public static string ContentFile()
        {
            string path = CallFileDialog();
            if (string.IsNullOrEmpty(path)) return null;

            return File.ReadAllText(path);
        }

        public static string CallFolderBrowserDialog()
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();
            string folder = "";
            if (result == DialogResult.OK)
                folder = dialog.SelectedPath;

            return folder;
        }
    }
}
