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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for AddChildWindow.xaml
    /// </summary>

    public partial class AddChildWindow : Window
    {
        BE.Child child = new BE.Child();
        public AddChildWindow()
        {
            InitializeComponent();
            DataContext = child;
        }

        private void AddChildButton_Click(object sender, RoutedEventArgs e)
        {
            BL.FactoryBL.getBL().AddChild(child);
            MessageBox.Show(child.ToString());
            child = new BE.Child();
            DataContext = child;
        }

    }
}
