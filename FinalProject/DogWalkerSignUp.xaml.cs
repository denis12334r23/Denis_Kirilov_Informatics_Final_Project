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
    /// Interaction logic for DogWalkerSignUp.xaml
    /// </summary>
    public partial class DogWalkerSignUp : Window
    {
        public DogWalkerSignUp()
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

        private void View_Dog_Walkers_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlCon.Open();
                string query = "Select * from Dog_Walker_Info1";
                SqlCommand cmd = new SqlCommand(query, sqlCon);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                Dog_Walker_Info.ItemsSource = dt.DefaultView;
                adapter.Update(dt);

                MessageBox.Show("Successful loading");




            }
            catch (Exception)
            {

                throw;
            }
            finally { sqlCon.Close(); }
        }

        private void Cotact_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlCon.Open();
                string check = Convert.ToString(new SqlCommand("SELECT Breed_Type FROM Pet_Info1 Where Name1= '" + this.Select_Pet.Text + "'", sqlCon).ExecuteScalar());
                string check2 = Convert.ToString(new SqlCommand("SELECT Specialization FROM Dog_Walker_Info1 Where Name= '" + this.Name1.Text + "'", sqlCon).ExecuteScalar());
                if (check == check2)
                {
                    string contact1 = Convert.ToString(new SqlCommand("SELECT Contact_Number FROM Dog_Walker_Info1 Where Name= '" + this.Name1.Text + "'", sqlCon).ExecuteScalar());
                    string contact2 = Convert.ToString(new SqlCommand("SELECT Email_Address FROM Dog_Walker_Info1 Where Name= '" + this.Name1.Text + "'", sqlCon).ExecuteScalar());
                    MessageBox.Show($@"You have successfully signed up for the services of {this.Name1.Text}.
They will contact you shortly. If there is significant delay, contact them at {contact1} or {contact2}");

                    MessageBox.Show("Thank you for using our services");

                    Home h = new Home();
                    h.Show();
                    this.Close();

                }


                else
                {
                    MessageBox.Show("Please select a dog walker with the correct specialization");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { sqlCon.Close(); }
        }
    }
}
