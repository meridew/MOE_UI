using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOE_UI.ViewModels
{
    public class TargetLastCommunicatedDaysViewModel : BaseViewModel
    {
        string _selectedTargetLastCommunicatedDays = "last_communicated_days";

        public string SelectedTargetLastCommunicatedDays
        {
            get => _selectedTargetLastCommunicatedDays;
            set => SetProperty(ref _selectedTargetLastCommunicatedDays, value);
        }

        string _selectedTargetLastCommunicatedDaysOperand = string.Empty;

        public string SelectedTargetLastCommunicatedDaysOperand
        {
            get => _selectedTargetLastCommunicatedDaysOperand;
            set => SetProperty(ref _selectedTargetLastCommunicatedDaysOperand, value);
        }

        string _selectedTargetLastCommunicatedDaysValue = string.Empty;

        public string SelectedTargetLastCommunicatedDaysValue
        {
            get => _selectedTargetLastCommunicatedDaysValue;
            set => SetProperty(ref _selectedTargetLastCommunicatedDaysValue, value);
        }

        public virtual void ValidateProperty(string propertyName, object value) { }
    }
}
