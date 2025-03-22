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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProductApps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Product cProduct;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                cProduct = new Product(Convert.ToDecimal(priceTextBox.Text), Convert.ToInt16(quantityTextBox.Text));
                cProduct.calTotalPayment();
                totalPaymentTextBlock.Text = Convert.ToString(cProduct.TotalPayment);


                // Add $25 delivery charge
                decimal deliveryCharge = 25.00m;
                decimal totalCharge = cProduct.TotalPayment + deliveryCharge;
                totalChargeTextBox.Text = totalCharge.ToString("C"); // Shows currency format


                // Calculate wrapping charge
                decimal wrappingCharge = 5.00m;
                decimal totalChargeWithWrap = totalCharge + wrappingCharge;
                wrapChargeTextBox.Text = totalChargeWithWrap.ToString("C"); // Shows currency format

                // Step 4: GST
                decimal totalChargeWithGST = totalChargeWithWrap * 1.1m;
                gstChargeTextBox.Text = totalChargeWithGST.ToString("C");

            }


            catch (FormatException)
            {
                MessageBox.Show("Enter data again", "Data Entry Error");
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            productTextBox.Text = "";
            priceTextBox.Text = "";
            quantityTextBox.Text = "";
            totalPaymentTextBlock.Text = "";
            totalChargeTextBox.Text = ""; // Also clear total charge
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
