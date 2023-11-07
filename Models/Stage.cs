using MOE_UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOE_UI.Models
{
    public class Stage : BaseViewModel
    {
        private string _command;
        public string Command
        {
            get => _command;
            set => SetProperty(ref _command, value);
        }

        private ObservableCollection<Criterion> _criteria;
        public ObservableCollection<Criterion> Criteria
        {
            get => _criteria;
            set => SetProperty(ref _criteria, value);
        }

        public Stage(string command, ObservableCollection<Criterion> criteria)
        {
            Command = command;
            Criteria = new ObservableCollection<Criterion>(criteria);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
