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
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        public SignUp()
        {
            InitializeComponent();
        }

        SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Informatics\InformaticsFinalProj\InformaticsFinalProj\Database1.mdf;Integrated Security=True");
                                                        
        private void SignUp_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlCon.Open();
                string querySignUp = "Insert into [dbo].[UserInfo] ([FirstName], [LastName], [username], [email], [password]) values ('"+this.FirstName.Text+"','"+this.LastName.Text+"','"+ this.username.Text+"','"+this.email.Text+"','"+this.password.Password+"')";
                SqlCommand cmdSignUp = new SqlCommand(querySignUp, sqlCon);
                cmdSignUp.ExecuteNonQuery();
                MessageBox.Show("You signed up successfully!");
                LogIn a = new LogIn();
                a.Show();
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
