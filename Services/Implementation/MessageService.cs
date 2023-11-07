using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MOE_UI.Services.Interfaces
{
    internal class MessageService : IMessageService
    {
        public MessageBoxResult ShowMessage(string message, string caption, MessageBoxButton buttons, MessageBoxImage icon)
        {
            // You can place this on the UI thread if needed using Dispatcher.Invoke if necessary.
            return MessageBox.Show(message, caption, buttons, icon);
        }
    }
}
