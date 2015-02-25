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
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class NameGetter : UserControl
    {
        public string MyBulshit
        {
            get { return (string)GetValue(MyBulshitProperty); }
            set { SetValue(MyBulshitProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Name.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyBulshitProperty =
            DependencyProperty.Register("MyBulshit", typeof(string), typeof(UserControl), new PropertyMetadata("Hello", OnPropertyChanged, OnCoerceValueCAllback), OnValidateValueCallback);

        private static bool OnValidateValueCallback(object value)
        {
            var str = value.ToString();
            return str.Contains("Szia") || str.Contains("Hello");
        }

        public string ErrorData
        {
            get { return (string)GetValue(ErrorDataProperty); }
            set { SetValue(ErrorDataProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ErrorData.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ErrorDataProperty =
            DependencyProperty.Register("ErrorData", typeof(string), typeof(NameGetter), new PropertyMetadata("NoError"));



        private static object OnCoerceValueCAllback(DependencyObject d, object baseValue)
        {
            string returnValue = baseValue.ToString();
            if (returnValue.Length > 5)
            {
                var o = (NameGetter)d;
                returnValue = "Szi" + returnValue.Substring(4);
            }
            return returnValue;
        }

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var o = (NameGetter)d;
            o.OldValue = e.OldValue.ToString();
        }

        public string OldValue { get; set; }

        //public string MyBulshit { get; set; }

        public int count = 0;

        public NameGetter()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyBulshit = "Szia" + count++;
            if (count % 2 == 0)
            {
                ErrorData = "NoError";
            }
            else
            {
                ErrorData = "Error";
            }
        }
    }
}
