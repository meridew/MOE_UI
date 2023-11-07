using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOE_UI.ViewModels
{
    public class EmailViewModel : BaseViewModel
    {
        string _emailaddresses;
        public string EmailAddresses
        {
            get => _emailaddresses; 
            set
            {
                SetProperty(ref _emailaddresses, value);
                UpdateEmailAddressCount();
            }
        }

        int _emailAddressCount;
        public int EmailAddressCount
        {
            get => _emailAddressCount; 
            set => SetProperty(ref _emailAddressCount, value);
        }

        public void UpdateEmailAddressCount()
        {
            if(!string.IsNullOrEmpty(EmailAddresses))
            {
                EmailAddressCount = EmailAddresses.Split('\n').Length;
            }
        }


    }
}
