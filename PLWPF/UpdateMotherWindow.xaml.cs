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
using BL;
using BE;
namespace PLWPF
{
    /// <summary>
    /// Interaction logic for UpdateMotherWindow.xaml
    /// </summary>
    public partial class UpdateMotherWindow : Window
    {
        IBL bl;
        Mother mother;
        String id;
        public UpdateMotherWindow()
        {
            InitializeComponent();
            bl = FactoryBL.getBL();
            mother = new Mother();
            this.grid1.DataContext = mother;
            this.iDComboBox.ItemsSource =from z in bl.GetMothers()
                                          select z.ID;
        }
        public void idCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                id = iDComboBox.SelectedValue.ToString();
                mother = this.bl.GetMotherByID(id);
                this.grid1.DataContext = mother;

            }
            catch (FormatException)
            {
                MessageBox.Show("Incorrect input");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void UpdateMotherButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BL.FactoryBL.getBL().UpdateMother(mother);
                MessageBox.Show(mother.ToString());
                mother = new BE.Mother();
                DataContext = mother;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
