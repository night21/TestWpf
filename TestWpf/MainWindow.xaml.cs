using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StackPanel_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = (bool)chkBoxInner.IsChecked;
            tBlock.Text += RoutedEventArgsToString(e, "inner StackPanel");
        }

        private void StackPanelOuter_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = (bool)chkBoxOuter.IsChecked;
            tBlock.Text += RoutedEventArgsToString(e, "outer StackPanel");
        }

        private string RoutedEventArgsToString(RoutedEventArgs e, string prefix)
        {
            return prefix + " " + e.Source.ToString() + " " + e.RoutedEvent.RoutingStrategy.ToString() + " " + e.Handled.ToString() + "\n";
        }

        private void StackPanel_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = (bool)chkBox.IsChecked;
            tBlock.Text += "MouseDown " + e.Source.ToString() + " " + e.Handled.ToString() + "\n"; 
        }

        private void StackPanel_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            tBlock.Text += "MouseUp " + e.Source.ToString() + " " + e.Handled.ToString() + "\n";
        }
    }
}
