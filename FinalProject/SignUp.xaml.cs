using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace FinalProject
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

        SqlConnection sqlCon = new SqlConnection(@"Data Source = DENISKIRILO9C3F\SQLEXPRESS; Initial Catalog = project; Integrated Security = True");
        private void SignUp_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlCon.Open();

                if (this.Email.Text.Contains("@")) {
                    if (this.Password.Password == this.Confirm.Password) {
                        string querySignUp = "Insert into User_LogIn_Info (Email_Address, Password) values ('" + this.Email.Text + "','" + this.Password.Password + "')" 
                            + "Insert into Contact_Information (Email_Address) values ('" + this.Email.Text + "')" ;
                        SqlCommand cmdSignUp = new SqlCommand(querySignUp, sqlCon);
                        cmdSignUp.ExecuteNonQuery();
                        MessageBox.Show("You signed up successfully!");
                        LogIn a = new LogIn();
                        a.Show();
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("Passwords must match.");
                    }
                }
                else
                {
                    MessageBox.Show("Please input a valid email address.");
                }

                sqlCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            }

        private void LogIn_Button_Click(object sender, RoutedEventArgs e)
        {
            LogIn li = new LogIn();
            li.Show();
            this.Close();
        }
    }
}
