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

namespace FinalProject
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

        private void LogIn_Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source = DENISKIRILO9C3F\SQLEXPRESS; Initial Catalog = project; Integrated Security = True");

            try
            {
                if (sqlCon.State == System.Data.ConnectionState.Closed)
                {
                    sqlCon.Open();
                }
                string queryLogIn = "SELECT COUNT(1) FROM User_LogIn_Info where Email_Address=@Email_Address and Password=@Password";
                SqlCommand cmdLogIn = new SqlCommand(queryLogIn, sqlCon);
                cmdLogIn.CommandType = CommandType.Text;
                cmdLogIn.Parameters.AddWithValue("@Email_Address", Email_Address.Text);
                cmdLogIn.Parameters.AddWithValue("@Password", Password.Password);

                int count = Convert.ToInt32(cmdLogIn.ExecuteScalar());
                if (count == 1)
                {
                    
                    MessageBox.Show("You logged in successfully!");

                    Home b = new Home();
                    b.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Email or password are not correct!");
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

        private void SignUp_Button_Click(object sender, RoutedEventArgs e)
        {

            SignUp su = new SignUp();
            su.Show();
            this.Close();

        }
    }
}
