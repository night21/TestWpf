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
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:TestWpf"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:TestWpf;assembly=TestWpf"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:CustomControl1/>
    ///
    /// </summary>
    public class CustomControl1 : ContentControl
    {


        public static string GetErrorNotification(DependencyObject obj)
        {
            return (string)obj.GetValue(ErrorNotificationProperty);
        }

        public static void SetErrorNotification(DependencyObject obj, string value)
        {
            obj.SetValue(ErrorNotificationProperty, value);
        }

        // Using a DependencyProperty as the backing store for ErrorNotification.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ErrorNotificationProperty =
            DependencyProperty.RegisterAttached("ErrorNotification", typeof(string), typeof(CustomControl1), new PropertyMetadata("NoError", OnPropertyChanged));

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue == e.NewValue) return;

            var o = (CustomControl1)d;
            if (e.NewValue.ToString() == "NoError")
            {
                o.BorderBrush = Brushes.Transparent;
                o.BorderThickness = new Thickness(10);
            }
            else
            {
                o.BorderBrush = Brushes.AliceBlue;
                o.BorderThickness = new Thickness(10);
            }
        }

        static CustomControl1()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomControl1), new FrameworkPropertyMetadata(typeof(CustomControl1)));
//            TextBox.TextProperty = CustomControl1.TextProperty.AddOwner(typeof(CustomControl1), new PropertyMetadata("Hello"));
        }
    }
}
