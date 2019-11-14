using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using MultipleChoiceMVVM.Model;

namespace MultipleChoiceMVVM.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private RelayCommand _loadTest;
        private RelayCommand _submitAnswer;
        private RelayCommand _loadNewQuestions;
        private string _question;
        private string _answera;
        private string _answerb;
        private string _answerc;
        private string _answerd;
        private string correct_answer;

        private bool _rdoanswera;
        private bool _rdoanswerb;
        private bool _rdoanswerc;
        private bool _rdoanswerd;

        private bool _isAnswered;

        CancellationTokenSource cts;

        public ICommand LoadTest
        {
            get
            {
                if (_loadTest == null)
                {
                    _loadTest = new RelayCommand(param => this.FireTestAsync());
                }
                return _loadTest;
            }
        }

        public ICommand SubmitAnswer
        {
            get
            {
                if(_submitAnswer == null)
                {
                    _isAnswered = true;
                    _submitAnswer = new RelayCommand(param => this.AnswerQuestion());
                }
                return _submitAnswer;
            }
        }

        public ICommand LoadNewQuestions
        { 
            get
            {
                if (_loadNewQuestions == null)
                {
                    _loadNewQuestions = new RelayCommand(param => this.LoadQuestions());
                }
                return _loadNewQuestions;
            }
        }

        public void LoadQuestions()
        {
            DataModel dm = new DataModel();
            // open the document
            // read all lines in to list
            // call the function to import the database
            List<string> data = new List<string>();
            string filename = "";
            string databasename = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "%USERDIR%";
            ofd.Title = "Open Questions";
            ofd.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (ofd.ShowDialog() == true)
            {
                filename = ofd.FileName;
                
                string[] lines = File.ReadAllLines(filename, Encoding.UTF8);
                foreach (string line in lines)
                {
                    data.Add(line);
                }
            }
                      

            ofd.Title = "Open Database";
            ofd.InitialDirectory = "%USERDIR%";
            ofd.Filter = "Database Files (*.db)|*.db";
            if (ofd.ShowDialog() == true)
            {
                databasename = ofd.FileName;
            }


            dm.SaveQuestionsToDatabase(data, databasename);
        }


        public void AnswerQuestion()
        {
            if (Rdoanswera)
            {
                if (Answera.Equals(correct_answer))
                {
                    MessageBox.Show("Correct", "Correct", MessageBoxButton.OK);
                    cts.Cancel();
                }
                else
                {
                    MessageBox.Show("Incorrect", "Wrong", MessageBoxButton.OK);
                    cts.Cancel();
                }
            }
            else if(Rdoanswerb)
            {
                if (Answerb.Equals(correct_answer))
                {
                    MessageBox.Show("Correct", "Correct", MessageBoxButton.OK);
                    cts.Cancel();
                }
                else
                {
                    MessageBox.Show("Incorrect", "Wrong", MessageBoxButton.OK);
                    cts.Cancel();
                }
            }
            else if (Rdoanswerc)
            {
                if (Answerc.Equals(correct_answer))
                {
                    MessageBox.Show("Correct", "Correct", MessageBoxButton.OK);
                    cts.Cancel();
                }
                else
                {
                    MessageBox.Show("Incorrect", "Wrong", MessageBoxButton.OK);
                    cts.Cancel();
                }
            }
            else if (Rdoanswerd)
            {
                if (Answerd.Equals(correct_answer))
                {
                    MessageBox.Show("Correct", "Correct", MessageBoxButton.OK);
                    cts.Cancel();
                }
                else
                {
                    MessageBox.Show("Incorrect", "Wrong", MessageBoxButton.OK);
                    cts.Cancel();
                }
            }
        }

        public async Task FireTestAsync()
        {
            DataModel dm = new DataModel();

            string databasename = "";
            IsAnswered = false;
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                databasename = ofd.FileName;
            }
            List<List<string>> data = new List<List<string>>();

            data = dm.ConnectToDataBase(databasename);

            data = data.OrderBy(a => Guid.NewGuid()).ToList();

            for(int i = 0; i < data.Count; i++)
            {
                cts = new CancellationTokenSource();
                DisplayQuestion(data[i]);
                await WaitToComplete();
            }
        }

        async Task WaitToComplete()
        {
            try
            {
                await Task.Delay(90000, cts.Token);
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
                Debug.WriteLine(ex);

            }
        }

        private void DisplayQuestion(List<string> data)
        {
            Question = data[1];

            List<string> answers = new List<string>();
            answers.Add(data[2]);
            answers.Add(data[3]);
            answers.Add(data[4]);
            answers.Add(data[5]);

            correct_answer = data[2];

            answers = answers.OrderBy(a => Guid.NewGuid()).ToList();
            Answera = answers[0];
            Answerb = answers[1];
            Answerc = answers[2];
            Answerd = answers[3];
        }

        public string Question
        {
            get { return _question; }
            set
            {
                if (_question != value)
                {
                    _question = value;
                    RaisePropertyChanged("Question");
                }
            }
        }

        public string Answera
        {
            get { return _answera; }
            set
            {
                if (_answera != value)
                {
                    _answera = value;
                    RaisePropertyChanged("Answera");
                }
            }
        }
        public string Answerb
        {
            get { return _answerb; }
            set
            {
                if (_answerb != value)
                {
                    _answerb = value;
                    RaisePropertyChanged("Answerb");
                }
            }
        }
        public string Answerc
        {
            get { return _answerc; }
            set
            {
                if (_answerc != value)
                {
                    _answerc = value;
                    RaisePropertyChanged("Answerc");
                }
            }
        }
        public string Answerd
        {
            get { return _answerd; }
            set
            {
                if (_answerd != value)
                {
                    _answerd = value;
                    RaisePropertyChanged("Answerd");
                }
            }
        }

        public bool Rdoanswera
        {
            get { return _rdoanswera; }
            set
            {
                if(_rdoanswera != value)
                {
                    _rdoanswera = value;
                    RaisePropertyChanged("Rdoanswera");
                }
            }
        }
        public bool Rdoanswerb
        {
            get { return _rdoanswerb; }
            set
            {
                if (_rdoanswerb != value)
                {
                    _rdoanswerb = value;
                    RaisePropertyChanged("Rdoanswera");
                }
            }
        }
        public bool Rdoanswerc
        {
            get { return _rdoanswerc; }
            set
            {
                if (_rdoanswerc != value)
                {
                    _rdoanswerc = value;
                    RaisePropertyChanged("Rdoanswera");
                }
            }
        }
        public bool Rdoanswerd
        {
            get { return _rdoanswerd; }
            set
            {
                if (_rdoanswerd != value)
                {
                    _rdoanswerd = value;
                    RaisePropertyChanged("Rdoanswera");
                }
            }
        }

        public bool IsAnswered
        {
            get { return _isAnswered; }
            set
            {
                if (_isAnswered != value)
                {
                    _isAnswered = value;
                    RaisePropertyChanged("IsAnswered");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
