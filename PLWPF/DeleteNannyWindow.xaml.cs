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
    /// Interaction logic for DeleteNannyWindow.xaml
    /// </summary>
    public partial class DeleteNannyWindow : Window
    {
        BE.Nanny nanny = new BE.Nanny();
        public DeleteNannyWindow()
        {
            InitializeComponent();
            DataContext = nanny.ID;
        }

        private void DeleteNannyButton_Click(object sender, RoutedEventArgs e)
        {
            nanny = BL.FactoryBL.getBL().GetNannyByID(nanny.ID);
            BL.FactoryBL.getBL().DeleteNanny(nanny);
            MessageBox.Show("the nanny is deleted");
            nanny = new BE.Nanny();
            DataContext = nanny.ID;
        }
    }
}

