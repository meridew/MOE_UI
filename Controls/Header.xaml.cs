using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MOE_UI.Controls
{
    /// <summary>
    /// Interaction logic for Header.xaml
    /// </summary>
    public partial class Header : UserControl
    {
        // Routed event declaration
        public static readonly RoutedEvent CloseButtonClickEvent = EventManager.RegisterRoutedEvent(
            "CloseButtonClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Header));

        public static readonly RoutedEvent MinimiseButtonClickEvent = EventManager.RegisterRoutedEvent(
       "MinimiseButtonClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Header));

        public static readonly RoutedEvent MaximiseButtonClickEvent = EventManager.RegisterRoutedEvent(
       "MaximiseButtonClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Header));

        // .NET event wrapper
        public event RoutedEventHandler CloseButtonClick
        {
            add { AddHandler(CloseButtonClickEvent, value); }
            remove { RemoveHandler(CloseButtonClickEvent, value); }
        }

        public event RoutedEventHandler MinimiseButtonClick
        {
            add { AddHandler(MinimiseButtonClickEvent, value); }
            remove { RemoveHandler(MinimiseButtonClickEvent, value); }
        }

        public event RoutedEventHandler MaximiseButtonClick
        {
            add { AddHandler(MaximiseButtonClickEvent, value); }
            remove { RemoveHandler(MaximiseButtonClickEvent, value); }
        }


        public Header()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            // Raise the routed event, which bubbles up in the element tree
            RaiseEvent(new RoutedEventArgs(CloseButtonClickEvent));
        }

        private void MinimiseButton_Click(object sender, RoutedEventArgs e)
        {
            // Raise the routed event, which bubbles up in the element tree
            RaiseEvent(new RoutedEventArgs(MinimiseButtonClickEvent));
        }

        private void MaximiseButton_Click(object sender, RoutedEventArgs e)
        {
            // Raise the routed event, which bubbles up in the element tree
            RaiseEvent(new RoutedEventArgs(MaximiseButtonClickEvent));
        }
    }

}
