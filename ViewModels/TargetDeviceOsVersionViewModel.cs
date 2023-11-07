using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOE_UI.ViewModels
{
    public class TargetDeviceOsVersionViewModel : BaseViewModel
    {
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

        public virtual void ValidateProperty(string propertyName, object value)
        {
            throw new NotImplementedException();
        }
    }
}
