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
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        public LogIn()
        {
            InitializeComponent();
        }

        SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Informatics\InformaticsFinalProj\InformaticsFinalProj\Database1.mdf;Integrated Security=True");

        private void LogIn_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sqlCon.State == System.Data.ConnectionState.Closed)
                {
                    sqlCon.Open();
                }
                string queryLogIn = "SELECT COUNT(1) FROM UserInfo where username=@username and password=@password";
                SqlCommand cmdLogIn = new SqlCommand(queryLogIn, sqlCon);
                cmdLogIn.CommandType = CommandType.Text;
                cmdLogIn.Parameters.AddWithValue("@username", username.Text);
                cmdLogIn.Parameters.AddWithValue("@password", password.Password);

                int count = Convert.ToInt32(cmdLogIn.ExecuteScalar());
                if (count == 1)
                {
                    MessageBox.Show("You logged in successfully!");

                    //Catalog b = new Catalog();
                    //b.Show();
                    //this.Close();
                }
                else
                {
                    MessageBox.Show("Username or password are not correct!");
                }
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
