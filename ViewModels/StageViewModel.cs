using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOE_UI.ViewModels
{
    public class StageViewModel : BaseViewModel
    {
        private int _stage_order;
        public int StageOrder
        {
            get => _stage_order;
            set => SetProperty(ref _stage_order, value);
        }

        private string _command;
        public string Command
        {
            get => _command;
            set => SetProperty(ref _command, value);
        }

        private ObservableCollection<CriterionViewModel> _criteria;
        public ObservableCollection<CriterionViewModel> Criteria
        {
            get => _criteria;
            set => SetProperty(ref _criteria, value);
        }

        public StageViewModel(int stageOrder, string command, ObservableCollection<CriterionViewModel> criteria)
        {
            StageOrder = stageOrder;
            Command = command;
            Criteria = new ObservableCollection<CriterionViewModel>(criteria);
        }
    }
}
