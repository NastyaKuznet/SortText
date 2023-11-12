using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.IO;
using System.Windows.Input;
using SortText.Model;
using static SortText.Model.WorkerFiles;

namespace SortText.ViewModel
{
    public class MainVM: BaseViewModel
    {
        private Converter _conventer = new Converter();
        private CounterWord counter = new CounterWord();
        private bool[] _workStart = new bool[2];

        private bool _isEnabledComb = true;
        public bool IsEnabledComb
        {
            get { return _isEnabledComb; }
            set
            {
                OnPropertyChanged();
            }
        }


        private List<string> _sortingAlgorithms = new List<string> { "Bubble Sort", "ABC Sort" };
        public List<string> ListOfAlgorithms
        {
            get { return _sortingAlgorithms; }
            set
            {
                _sortingAlgorithms = value;
                OnPropertyChanged();
            }
        }

        private string _currentAlg;
        public string CurrentAlg
        {
            get { return _currentAlg; }
            set
            {
                _currentAlg = value;
                OnPropertyChanged();
            }
        }

        private string _nameFile;
        public string NameFile
        {
            get { return _nameFile; }
            set
            {
                _nameFile = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<string> _textFile;
        public ObservableCollection<string> TextFile
        {
            get { return _textFile; }
            set
            {
                _textFile = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<string> _movements = new ObservableCollection<string>();
        public ObservableCollection<string> Movements
        { 
            get { return _movements; } 
            set { 
                _movements = value; 
                OnPropertyChanged();
            }
        }

        private int _slider = 500;
        public int Slider
        {
            get { return _slider; }
            set
            {
                _slider = value;
                OnPropertyChanged();
            }
        }

        private DataTable tableCountWord = new DataTable();
        public DataTable TableCountWord
        {
            get { return tableCountWord; }
            set
            {
                tableCountWord = value;
                OnPropertyChanged();
            }
        }

        private string _path;
        public string Path
        {
            get { return _path; }
            set
            {
                _path = value;
                OnPropertyChanged();
            }
        }

        private List<string> _listCount = new List<string> { "10", "50", "100", "500", "1000" };
        public List<string> ListCount
        {
            get { return _listCount; }
            set
            {
                _listCount = value;
                OnPropertyChanged();
            }
        }

        private string _selectedCount;
        public string SelectedCount
        {
            get { return _selectedCount; }
            set
            {
                _selectedCount = value;
                OnPropertyChanged();
            }
        }

        private bool _isEnabledAnaliz;
        public bool IsEnabledAnaliz
        {
            get { return _isEnabledAnaliz; }
            set
            {
                _isEnabledAnaliz = value;
                OnPropertyChanged();
            }
        }

        private string _content;
        public string Content
        {
            get { return _content; }
            set
            {
                _content = value;
                OnPropertyChanged();
            }
        }
        private bool stopAnaliz = false;


        private string text;
        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                OnPropertyChanged();
            }
        }

        private bool _isEnabledSort;
        public bool IsEnabledSort
        {
            get { return _isEnabledSort; }
            set
            {
                _isEnabledSort = value;
                OnPropertyChanged();
            }
        }


        public ICommand Open => new CommandDelegate(param =>
        {
            string lines = ContentFile();
            if (lines == null) return;
            Text = lines;
            _workStart[0] = true;
        });

        public ICommand Accept => new CommandDelegate(param =>
        {
            IsEnabledSort = !(string.IsNullOrEmpty(CurrentAlg) || string.IsNullOrWhiteSpace(CurrentAlg)
            || string.IsNullOrEmpty(Text) || string.IsNullOrWhiteSpace(Text));
        });

        public ICommand Start => new CommandDelegate(param =>
        {
            if (!_workStart[0] || CurrentAlg == null || string.IsNullOrEmpty(CurrentAlg)) return;
            SorterText sorterText = new SorterText();
            sorterText.DoSort(Text, CurrentAlg);
            Text = sorterText.Result;
        });

        public ICommand Count => new CommandDelegate(param =>
        {
            if (!_workStart[0]) return;
            TableCountWord = _conventer.DictInDataTable(counter.CountWord(_conventer.LineInMassWordWithoutSign(Text)));
        });

        public ICommand ChoiceFolderSaveAnaliz => new CommandDelegate(param =>
        {
            Path = CallFolderBrowserDialog();
        });

        public ICommand Check => new CommandDelegate(param =>
        {
            IsEnabledAnaliz = !(string.IsNullOrEmpty(Path) || string.IsNullOrWhiteSpace(Path) 
            || string.IsNullOrEmpty(SelectedCount) || string.IsNullOrWhiteSpace(SelectedCount)
            || string.IsNullOrEmpty(CurrentAlg) || string.IsNullOrWhiteSpace(CurrentAlg));
        });

        public ICommand Analiz => new CommandDelegate(param =>
        {
            AnalizerText analizer = new AnalizerText();
            analizer.DoAnaliz(Text, CurrentAlg, int.Parse(SelectedCount), Path);
            Text = analizer.Result;
        });       
    }
}
