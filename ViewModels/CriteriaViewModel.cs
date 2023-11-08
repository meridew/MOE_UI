using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace MOE_UI.ViewModels
{
    public class CriteriaViewModel : BaseViewModel
    {
        public CriteriaViewModel()
        {
            ValidateProperty(nameof(SelectedTargetDeviceOsFamilyOperand), SelectedTargetDeviceOsFamilyOperand);
            ValidateProperty(nameof(SelectedTargetDeviceOsFamilyValue), SelectedTargetDeviceOsFamilyValue);
            ValidateProperty(nameof(SelectedTargetDeviceOsVersionOperand), SelectedTargetDeviceOsVersionOperand);
            ValidateProperty(nameof(SelectedTargetDeviceOsVersionValue), SelectedTargetDeviceOsVersionValue);
            ValidateProperty(nameof(SelectedTargetLastCommunicatedDaysOperand), SelectedTargetLastCommunicatedDaysOperand);
            ValidateProperty(nameof(SelectedTargetLastCommunicatedDaysValue), SelectedTargetLastCommunicatedDaysValue);
        }
        
        public string[] Operands { get; } = new[] { "=", ">", "<" };
        public string[] DeviceOsFamilies { get; } = new[] { "ios", "android" };
        
        string _selectedTargetDeviceOsFamilyField = "target_os_family";

        public string SelectedTargetDeviceOsFamilyField
        {
            get => _selectedTargetDeviceOsFamilyField;
            set => SetProperty(ref _selectedTargetDeviceOsFamilyField, value);
        }

        string _selectedTargetDeviceOsFamilyOperand = string.Empty;
        public string SelectedTargetDeviceOsFamilyOperand
        {
            get => _selectedTargetDeviceOsFamilyOperand;
            set => SetProperty(ref _selectedTargetDeviceOsFamilyOperand, value);
        }

        string _selectedTargetDeviceOsFamilyValue = string.Empty;
        public string SelectedTargetDeviceOsFamilyValue
        {
            get => _selectedTargetDeviceOsFamilyValue;
            set => SetProperty(ref _selectedTargetDeviceOsFamilyValue, value);
        }

        string _selectedTargetDeviceOsVersionField = "target_os_version";
        public string SelectedTargetDeviceOsVersionField
        {
            get => _selectedTargetDeviceOsVersionField;
            set => SetProperty(ref _selectedTargetDeviceOsVersionField, value);
        }

        string _selectedTargetDeviceOsVersionOperand = string.Empty;
        public string SelectedTargetDeviceOsVersionOperand
        {
            get => _selectedTargetDeviceOsVersionOperand;
            set => SetProperty(ref _selectedTargetDeviceOsVersionOperand, value);
        }

        string _selectedTargetDeviceOsVersionValue = string.Empty;

        public string SelectedTargetDeviceOsVersionValue
        {
            get => _selectedTargetDeviceOsVersionValue;
            set => SetProperty(ref _selectedTargetDeviceOsVersionValue, value);
        }

        string _selectedTargetLastCommunicatedDaysField = "target_last_communicated_days";

        public string SelectedTargetLastCommunicatedDaysField
        {
            get => _selectedTargetLastCommunicatedDaysField;
            set => SetProperty(ref _selectedTargetLastCommunicatedDaysField, value);
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

        public ObservableCollection<CriterionViewModel> GetCriteria()
        {
            var criteria = new ObservableCollection<CriterionViewModel>
                {
                    new CriterionViewModel(SelectedTargetDeviceOsVersionField, SelectedTargetDeviceOsVersionOperand, SelectedTargetDeviceOsVersionValue),
                    new CriterionViewModel(SelectedTargetDeviceOsFamilyField, SelectedTargetDeviceOsFamilyOperand, SelectedTargetDeviceOsFamilyValue),
                    new CriterionViewModel(SelectedTargetLastCommunicatedDaysField, SelectedTargetLastCommunicatedDaysOperand, SelectedTargetLastCommunicatedDaysValue)
                };
            return criteria;
        }

        public override void ValidateProperty(string propertyName, object value)
        {
            base.ValidateProperty(propertyName, value);

            ClearError(propertyName);

            switch (propertyName)
            {
                case nameof(SelectedTargetDeviceOsFamilyOperand):
                    if (string.IsNullOrEmpty(SelectedTargetDeviceOsFamilyOperand))
                    {
                        AddError(propertyName, "Operand is required.");
                    }
                    break;
                case nameof(SelectedTargetDeviceOsFamilyValue):
                    if (string.IsNullOrEmpty(SelectedTargetDeviceOsFamilyValue))
                    {
                        AddError(propertyName, "Value is required.");
                    }
                    break;
                case nameof(SelectedTargetDeviceOsVersionOperand):
                    if (string.IsNullOrEmpty(SelectedTargetDeviceOsVersionOperand))
                    {
                        AddError(propertyName, "Operand is required.");
                    }
                    break;
                case nameof(SelectedTargetDeviceOsVersionValue):
                    if (string.IsNullOrEmpty(SelectedTargetDeviceOsVersionValue))
                    {
                        AddError(propertyName, "Value is required.");
                    }
                    else if(!Regex.IsMatch(SelectedTargetDeviceOsVersionValue, @"^\d+(\.\d+)?(\.[^\s.]+)?(\.[^\s.]+)?$"))
                    {
                        AddError(propertyName, "Value invalid format");
                    }
                    break;
                case nameof(SelectedTargetLastCommunicatedDaysOperand):
                    if (string.IsNullOrEmpty(SelectedTargetLastCommunicatedDaysOperand))
                    {
                        AddError(propertyName, "Operand is required.");
                    }
                    break;
                case nameof(SelectedTargetLastCommunicatedDaysValue):
                    if (string.IsNullOrEmpty(SelectedTargetLastCommunicatedDaysValue))
                    {
                        AddError(propertyName, "Value is required.");
                    }
                    break;
            }
        }   
    }
}
