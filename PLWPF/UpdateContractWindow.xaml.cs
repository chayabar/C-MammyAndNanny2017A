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
    /// Interaction logic for UpdateContractWindow.xaml
    /// </summary>
    public partial class UpdateContractWindow : Window
    {
        string id;
        IBL bl;
        Mother mother = new Mother();
        Child child = new Child();
        Nanny nanny = new Nanny();
        BE.Contract contract = new BE.Contract();
        public UpdateContractWindow()
        {
            InitializeComponent();
            contract.IsInterview = true;
            bl = FactoryBL.getBL();
            DataContext = contract;
            this.motherIDComboBox.ItemsSource = from z in bl.GetMothers()
                                                select z.ID;
        }
        public void motherIDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                id = motherIDComboBox.SelectedValue.ToString();
                mother = this.bl.GetMotherByID(id);
                this.childIDComboBox.ItemsSource = from z in bl.GetChildsByMother(mother)
                                                   select z.ChildID;
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

        public void childIDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                id = childIDComboBox.SelectedValue.ToString();
                child = this.bl.GetChildByID(id);
                List<Nanny> list1 = bl.DistanceNannys(mother);
                List<Nanny> list2 = bl.AvailableNannys(mother, child);
                List<Nanny> list3 = (list1.Intersect(list2)).ToList();
                this.nunnyIDComboBox.ItemsSource = from z in list3
                                                   select z.ID;
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

        public void nunnyIDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                id = nunnyIDComboBox.SelectedValue.ToString();
                nanny = this.bl.GetNannyByID(id);
                MessageBox.Show(nanny.ToString());
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

        private void UpdateContractButton_Click(object sender, RoutedEventArgs e)
        {
            BL.FactoryBL.getBL().UpdateContract(contract);
            MessageBox.Show(contract.ToString());
            contract = new BE.Contract();
            DataContext = contract;
            this.Close();
        }
    }
}

