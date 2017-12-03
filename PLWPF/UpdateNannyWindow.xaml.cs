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
using BE;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for UpdateNannyWindow.xaml
    /// </summary>
    public partial class UpdateNannyWindow : Window
    {
        IBL bl;
        Nanny nanny;
        String id;
        public UpdateNannyWindow()
        {
            InitializeComponent();
            bl = FactoryBL.getBL();
            nanny = new Nanny();
            this.grid1.DataContext = nanny;
            this.iDComboBox.ItemsSource = from z in bl.GetNannys()
                                          select z.ID;
        }

        public void idCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                id = iDComboBox.SelectedValue.ToString();
                nanny = this.bl.GetNannyByID(id);
                this.grid1.DataContext = nanny;
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
        private void UpdateNannyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BL.FactoryBL.getBL().UpdateNanny(nanny);
                MessageBox.Show(nanny.ToString());
                nanny = new BE.Nanny();
                DataContext = nanny;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
