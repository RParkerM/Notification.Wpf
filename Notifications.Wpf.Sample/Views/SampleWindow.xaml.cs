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
using System.Windows.Shapes;

using Notification.Wpf.Sample.ViewModels;

namespace Notification.Wpf.Sample.Views
{
    /// <summary>
    /// Логика взаимодействия для SampleWindow.xaml
    /// </summary>
    public partial class SampleWindow : Window
    {

        public SampleWindow()
        {
            InitializeComponent();
            var workArea = SystemParameters.WorkArea;
            Left = workArea.Left;
            Top = workArea.Top;
            Width = workArea.Width;
            Height = workArea.Height;
        }
    }
}
