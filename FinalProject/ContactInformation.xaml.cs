using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for ContactInformation.xaml
    /// </summary>
    public partial class ContactInformation : Window
    {
        public ContactInformation()
        {
            InitializeComponent();
        }

        SqlConnection sqlCon = new SqlConnection(@"Data Source = DENISKIRILO9C3F\SQLEXPRESS; Initial Catalog = project; Integrated Security = True");
        private void Back_To_Home_Button_Click(object sender, RoutedEventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Close();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sqlCon.State == System.Data.ConnectionState.Closed)
                {
                    sqlCon.Open();
                }
                string queryCheck = "SELECT COUNT(1) FROM User_LogIn_Info where Password=@Password";

                


                SqlCommand cmdLogIn = new SqlCommand(queryCheck, sqlCon);
                cmdLogIn.CommandType = CommandType.Text;
                cmdLogIn.Parameters.AddWithValue("@Password", Password.Password);

                int count = Convert.ToInt32(cmdLogIn.ExecuteScalar());
                if (count == 1)
                {
                    string queryUpdate = "Update Contact_Information Set First_Name = @First_Name, Last_name = @Last_Name, Phone_Number " +
                        "= @Phone_Number, Street_Address = @Street_Address Where Email_Address = @Email";
                    SqlCommand cmdUpdate = new SqlCommand(queryUpdate, sqlCon);
                
                    cmdUpdate.CommandType = CommandType.Text;
                    cmdUpdate.Parameters.AddWithValue("@First_Name", First_Name.Text);
                    cmdUpdate.Parameters.AddWithValue("@Last_Name", Last_name.Text);
                    cmdUpdate.Parameters.AddWithValue("@Phone_Number", Phone_Number.Text);
                    cmdUpdate.Parameters.AddWithValue("@Street_Address", Street_Address.Text);
                    cmdUpdate.Parameters.AddWithValue("@Email", Email.Text);

                    cmdUpdate.ExecuteNonQuery();

                    MessageBox.Show("Contact information successfully updated");

                }
                else
                {
                    MessageBox.Show("Enter correct password");
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
