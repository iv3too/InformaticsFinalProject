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
using System.Data.SqlClient;
using System.Data;

namespace InformaticsFinalProj
{
    /// <summary>
    /// Interaction logic for PaymentInfo.xaml
    /// </summary>
    public partial class PaymentInfo : Window
    {
        public PaymentInfo()
        {
            InitializeComponent();
        }

        SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Informatics\InformaticsFinalProj\InformaticsFinalProj\Database1.mdf;Integrated Security=True");

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlCon.Open();
                string qAddOrder = "update OrderInfo set address='"+this.address.Text+ "',creditCardNumber='" + this.creditCardNumber.Text 
                    + "', creditCardHolder='" + this.creditCardHolder.Text + "' where flowerType='" + this.flowerType.Text + "' and size='" + this.size.Text + "'";
                SqlCommand cmdAddOrder = new SqlCommand(qAddOrder, sqlCon);
                cmdAddOrder.ExecuteNonQuery();
                MessageBox.Show("saved successfully");
            }
            catch (Exception exA)
            {
                MessageBox.Show(exA.Message);

            }
            finally
            {
                sqlCon.Close();
            }

        }
    }
}
