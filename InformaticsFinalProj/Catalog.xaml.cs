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
    /// Interaction logic for Catalog.xaml
    /// </summary>
    public partial class Catalog : Window
    {
        public Catalog()
        {
            InitializeComponent();
        }

        SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Informatics\InformaticsFinalProj\InformaticsFinalProj\Database1.mdf;Integrated Security=True");

        private void LoadAvailability_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlCon.Open();
                string queryAvailability = "Select * from FlowerAvailability";
                SqlCommand cmdLoadAvailability = new SqlCommand(queryAvailability, sqlCon);
                cmdLoadAvailability.ExecuteNonQuery();
                SqlDataAdapter adapterLoad = new SqlDataAdapter(cmdLoadAvailability);
                DataTable dtLoad = new DataTable();
                adapterLoad.Fill(dtLoad);
                DataGridAvailability.ItemsSource = dtLoad.DefaultView;
                adapterLoad.Update(dtLoad);

                MessageBox.Show("Successful Loading");
               
                CustomBouquets c = new CustomBouquets();
                c.Show();
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
    }
}
