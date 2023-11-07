using System;

namespace MOE_UI.ViewModels
{
    public class CriteriaViewModel : BaseViewModel
    {
        public string[] Operands { get; } = new[] { "=", "!=", ">", "<", ">=", "<=" };
        public string[] DeviceOsFamilies { get; } = new[] { "ios", "android" };
        
        string _selectedTargetDeviceOsFamilyField = "target_os_family";

        public string SelectedTargetOsFamily
        {
            get => _selectedTargetDeviceOsFamilyField;
            set => SetProperty(ref _selectedTargetDeviceOsFamilyField, value);
        }

        string _selectedTargetDeviceOsFamilyOperand = string.Empty;
        public string SelectedTargetOsFamilyOperand
        {
            get => _selectedTargetDeviceOsFamilyOperand;
            set => SetProperty(ref _selectedTargetDeviceOsFamilyOperand, value);
        }

        string _selectedTargetDeviceOsFamilyValue = string.Empty;
        public string SelectedTargetOsFamilyValue
        {
            get => _selectedTargetDeviceOsFamilyValue;
            set => SetProperty(ref _selectedTargetDeviceOsFamilyValue, value);
        }

        string _selectedTargetDeviceOsVersionField = "target_device_os";
        public string SelectedTargetDeviceOsField
        {
            get => _selectedTargetDeviceOsVersionField;
            set => SetProperty(ref _selectedTargetDeviceOsVersionField, value);
        }

        string _selectedTargetDeviceOsVersionOperand = string.Empty;
        public string SelectedTargetDeviceOsOperand
        {
            get => _selectedTargetDeviceOsVersionOperand;
            set => SetProperty(ref _selectedTargetDeviceOsVersionOperand, value);
        }

        string _selectedTargetDeviceOsVersionValue = string.Empty;

        public string SelectedTargetDeviceOsValue
        {
            get => _selectedTargetDeviceOsVersionValue;
            set => SetProperty(ref _selectedTargetDeviceOsVersionValue, value);
        }

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

        public virtual void ValidateProperty(string propertyName, object value)
        {
            throw new NotImplementedException();
        }
    }
}
