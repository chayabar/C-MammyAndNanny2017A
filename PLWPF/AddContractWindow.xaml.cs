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
    /// Interaction logic for AddContractWindow.xaml
    /// </summary>
    public partial class AddContractWindow : Window
    {
        string id;
        IBL bl;
        Mother mother;
        Child child ;
        Nanny nanny ;
        BE.Contract contract;
        public AddContractWindow()
        {
            InitializeComponent();
            contract = new Contract();
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
                contract.MotherID = id;
                contract.WorkTime = mother.Workhours;
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
                List<Nanny> list1 = bl.AvailableNannys(mother, child); //bl.DistanceNannys(mother);
                List<Nanny> list2 = bl.AvailableNannys(mother, child);
                List<Nanny> list3 = (list1.Intersect(list2)).ToList();
                this.nunnyIDComboBox.ItemsSource = from z in list3
                                                   select z.ID;
                contract.ChildID = id;
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
                contract.NunnyID = id;
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

        private void AddContractButton_Click(object sender, RoutedEventArgs e)
        {
            BL.FactoryBL.getBL().AddContract(contract);
            MessageBox.Show(contract.ToString());
            contract = new BE.Contract();
            DataContext = contract;
            this.Close();
        }

      }
}
