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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for Grouping.xaml
    /// </summary>
    public partial class Grouping : Window
    {
        IBL bl;
        public Grouping()
        {
            InitializeComponent();
            bl = FactoryBL.getBL();
        }
        private void GroupContByDistanceButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                ContractDistance cd = new ContractDistance();
                cd.Source = bl.GroupContractsByDistance();
                this.page.Content = cd;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GroupNannyByAddressButton_Click(object sender, RoutedEventArgs e)

        {
            try
            {
                NannyByAddress na = new NannyByAddress();
                na.Source = bl.GroupNannysByAddress();
                this.page.Content = na;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GroupRangeChildAgeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RangeChildAge ra = new RangeChildAge();
                ra.Source = bl.GroupNannysByRangeChildAge();
                this.page.Content = ra;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GroupNannyWithTMTButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NannyWithTMT nTMT = new NannyWithTMT();
                nTMT.Source = bl.NannysWithTMT();

                this.page.Content = nTMT;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

