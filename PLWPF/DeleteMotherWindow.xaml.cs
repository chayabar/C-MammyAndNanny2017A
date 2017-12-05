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
    /// Interaction logic for DeleteMotherWindow.xaml
    /// </summary>
    public partial class DeleteMotherWindow : Window
    {

        BE.Mother mother = new BE.Mother();
        public DeleteMotherWindow()
        {
            InitializeComponent();
            DataContext = mother.ID;
        }

        private void DeleteMotherButton_Click(object sender, RoutedEventArgs e)
        {
            mother = BL.FactoryBL.getBL().GetMotherByID(mother.ID);
            BL.FactoryBL.getBL().DeleteMother(mother);
            MessageBox.Show("the mother is deleted");
            mother = new BE.Mother();
            DataContext = mother.ID;
            this.Close();
        }
    }
}
