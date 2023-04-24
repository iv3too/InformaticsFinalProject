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
    /// Interaction logic for ConfirmOrder.xaml
    /// </summary>
    public partial class ConfirmOrder : Window
    {
        public ConfirmOrder()
        {
            InitializeComponent();
        }

        SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Informatics\InformaticsFinalProj\InformaticsFinalProj\Database1.mdf;Integrated Security=True");

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlCon.Open();
                string qDelete = "delete from OrderInfo where flowerType='"+this.flowerType.Text+"'";
                SqlCommand cmdDelete = new SqlCommand(qDelete, sqlCon);
                cmdDelete.ExecuteNonQuery();
                MessageBox.Show("You successfully deleted the bouquet!");
                CustomBouquets f = new CustomBouquets();
                f.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Informatics\InformaticsFinalProj\InformaticsFinalProj\Database1.mdf;Integrated Security=True");
                sqlCon.Open();
                string qUpdate = "update OrderInfo set size=' " + this.size.Text + " ' where flowerType='" + this.flowerType.Text + "' ";
                SqlCommand cmdUpdate = new SqlCommand(qUpdate, sqlCon);
                cmdUpdate.ExecuteNonQuery();
                MessageBox.Show("Order was successfully updated!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlCon.Open();
                string queryLoadOrder = "Select flowerType, size from OrderInfo";
                SqlCommand cmdLoadOrder = new SqlCommand(queryLoadOrder, sqlCon);
                cmdLoadOrder.ExecuteNonQuery();
                SqlDataAdapter adapterLoad = new SqlDataAdapter(cmdLoadOrder);
                DataTable dtLoadOrder = new DataTable();
                adapterLoad.Fill(dtLoadOrder);
                DataGridOrder.ItemsSource = dtLoadOrder.DefaultView;
                adapterLoad.Update(dtLoadOrder);

                MessageBox.Show("Successful Loading of Current Order!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }

        }

        private void Continue_Click(object sender, RoutedEventArgs e)
        {
            PaymentInfo g = new PaymentInfo();
            g.Show();
            this.Close();
        }
    }
}
