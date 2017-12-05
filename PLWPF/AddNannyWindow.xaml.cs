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
    /// Interaction logic for addNannyWindow.xaml
    /// </summary>
    public partial class AddNannyWindow : Window
    {
        IBL bl;
        string id;
        BE.Nanny nanny = new BE.Nanny();
        public AddNannyWindow()
        {
            InitializeComponent();
            bl = FactoryBL.getBL();
            this.grid1.DataContext = nanny;
            this.BankNameComboBox.ItemsSource = from z in bl.GetBankBranchs()
                                          select z;
            this.BankBranchComboBox.ItemsSource = from z in bl.GetBankBranchs()
                                                select z;
        }
        public void BankNameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                id = BankNameComboBox.SelectedValue.ToString();
                //nanny = this.bl.GetNannyByID(id);
                //set bank account for nanny
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
        public void BankBranchComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                id = BankBranchComboBox.SelectedValue.ToString();
                //nanny = this.bl.GetNannyByID(id);
                //this.grid1.DataContext = nanny;
                //set bank account for nanny
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
        private void AddNannyButton_Click(object sender, RoutedEventArgs e)
        {
            BL.FactoryBL.getBL().AddNanny(nanny);
            MessageBox.Show(nanny.ToString());
            nanny = new BE.Nanny();
            DataContext = nanny;
            this.Close();
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            AvailableTime availableTime = new AvailableTime();
            bool? result = availableTime.ShowDialog();
            if (result != false)
            {
                nanny.AvailableTime = availableTime.Mystuff;
            }
        }

        private void AddAddress_Click(object sender, RoutedEventArgs e)
        {
            Address address = new Address();
            bool? result = address.ShowDialog();
            if (result != false)
            {
                nanny.Address = address.myaddress;
            }
        }
    }
}
