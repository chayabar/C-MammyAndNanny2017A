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
    /// Interaction logic for addMotherWindow.xaml
    /// </summary>
    public partial class AddMotherWindow : Window
    {
        BE.Mother mother = new BE.Mother();
        public AddMotherWindow()
        {
            InitializeComponent();
            DataContext = mother;
        }

        private void AddMotherButton_Click(object sender, RoutedEventArgs e)
        {
            BL.FactoryBL.getBL().AddMother(mother);
            MessageBox.Show(mother.ToString());
            mother = new BE.Mother();
            DataContext = mother;
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            AvailableTime availableTime = new AvailableTime();
            bool? result = availableTime.ShowDialog();
            if (result != false)
            {
                mother.Workhours = availableTime.Mystuff;
            }
        }
        private void AddAddress_Click(object sender, RoutedEventArgs e)
        {
            Address address = new Address();
            bool? result = address.ShowDialog();
            if (result != false)
            {
                mother.Address = address.myaddress;
            }
        }
    }
}