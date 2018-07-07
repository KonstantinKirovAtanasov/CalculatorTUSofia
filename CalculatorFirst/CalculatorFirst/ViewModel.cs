using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace CalculatorFirst
{
    public class ViewModel : ICommand, INotifyPropertyChanged
    {
        public event EventHandler CanExecuteChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        private OpetarionEntity operation = new OpetarionEntity();

        private string input = ""; 
        public string Input
        {
            get { return input.ToString(); }
            set
            {
                operation.AddSymbol(value);
                input = operation.ToString();
                historyLine.history = operation.History;
                OnPropertyChanged("Input");
                OnPropertyChanged("HistoryLine");
            }
        }
        private HistoryEntity historyLine =new HistoryEntity();
        public string HistoryLine
        {
            get { return historyLine.ToString(); }
            private set {; }
        }
        
        private void OnPropertyChanged(string PropChanged)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropChanged));
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Input = (string)parameter;
        }
    }
}
