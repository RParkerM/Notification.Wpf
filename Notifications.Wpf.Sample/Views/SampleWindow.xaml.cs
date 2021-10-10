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

            var context = new SampleWindowViewModel();

            context.MessageSettingModel.Text =
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis euismod accumsan orci vel varius. Nulla consectetur egestas est,"
                + " in porttitor elit placerat non. Cras dapibus cursus magna. Nunc ac malesuada lacus. Etiam non luctus magna, nec vulputate diam."
                + " Sed porta mi at tristique bibendum. Nunc luctus libero ut mauris cursus, eget dignissim est luctus.Sed ac nibh dignissim, elementum mi ut,"
                + " tempor quam.Donec quis ornare sapien. Maecenas arcu elit, blandit quis odio eu, elementum bibendum leo."
                + " Etiam iaculis consectetur metus. Donec in bibendum massa. Nam nec facilisis eros, sit amet blandit magna.Duis vitae"
                + " justo nec nisi maximus efficitur vitae non mauris.";

            context.TitleSettingModel.Text = "Title sample text";
            context.TitleSettingModel.FontWeightSample = FontWeights.Bold;
            DataContext = context;

        }
    }
}
