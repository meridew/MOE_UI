using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MOE_UI.Services
{
    internal interface IMessageService
    {
        MessageBoxResult ShowMessage(string message, string caption, MessageBoxButton buttons, MessageBoxImage icon);
    }
}
