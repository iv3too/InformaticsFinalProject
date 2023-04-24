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
    /// Interaction logic for CustomBouquets.xaml
    /// </summary>
    public partial class CustomBouquets : Window
    {
        public string[] FlowerType {get; set;}
        public string[] FlowerSize {get; set;}
        public CustomBouquets()
        {
            InitializeComponent();
            FlowerType = new string[] {"Tulips","Roses","Orchids"};
            DataContext = this;
            FlowerSize = new string[] {"small","medium","large"};
            DataContext = this;
        }

        SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Informatics\InformaticsFinalProj\InformaticsFinalProj\Database1.mdf;Integrated Security=True");

        private void AddBouquet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlCon.Open();
                string qAdd = "Insert into OrderInfo (flowerType, size) values ('"+this.Flower_Type.SelectedItem+"','"+this.sizeOfBouquet.SelectedItem+"')";
                SqlCommand cmdAdd = new SqlCommand(qAdd, sqlCon);
                cmdAdd.ExecuteNonQuery();
                MessageBox.Show("Saved successfully!");

                ConfirmOrder d = new ConfirmOrder();
                d.Show();
                this.Close();
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

        private void sizeOfBouquet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
