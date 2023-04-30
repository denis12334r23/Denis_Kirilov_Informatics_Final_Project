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
    /// Interaction logic for MyPets.xaml
    /// </summary>
    public partial class MyPets : Window
    {
        public MyPets()
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

        private void Confirm_Add_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                sqlCon.Open();
                if (Breed_Type.Text == "small" || Breed_Type.Text == "medium" || Breed_Type.Text == "large")
                {
                    string queryAdd = "Insert Into Pet_Info1 (Name1, Breed_Type) values ('" + this.Name.Text + "','" + this.Breed_Type.Text + "')";
                    SqlCommand cmdAdd = new SqlCommand(queryAdd, sqlCon);
                    cmdAdd.ExecuteNonQuery();

                    MessageBox.Show("New pet successfully added");

                }


                else
                {
                    MessageBox.Show("Enter correct breed type. Hint: small (0-10kg), medium (10-30kg), large(30+kg)");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { sqlCon.Close(); }
        }

        private void Confirm_Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlCon.Open();
                string queryCheck1 = "SELECT COUNT(*) FROM Pet_Info1 where Name1 =@Delete_Pet";
                SqlCommand cmdCheck1 = new SqlCommand(queryCheck1, sqlCon);
                cmdCheck1.CommandType = CommandType.Text;
                cmdCheck1.Parameters.AddWithValue("@Delete_Pet", Delete_Pet.Text);

                int count = Convert.ToInt32(cmdCheck1.ExecuteScalar());
                if (count > 0)
                {
                    string queryDelete = "Delete from Pet_Info1 where Name1=@Delete_Pet";
                    SqlCommand cmdDelete = new SqlCommand(queryDelete, sqlCon);
                    cmdDelete.CommandType = CommandType.Text;
                    cmdDelete.Parameters.AddWithValue("@Delete_Pet", Delete_Pet.Text);
                    cmdDelete.ExecuteNonQuery();

                    MessageBox.Show("Pet successfully deleted");

                }
                else
                {
                    MessageBox.Show("There are no pets with this name");
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { sqlCon.Close(); }

        }
        

    private void View_My_Pets_Click(object sender, RoutedEventArgs e)
    {
        try
        {
                sqlCon.Open();
            string query = "Select * from Pet_Info1";
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            MyPets1.ItemsSource = dt.DefaultView;
            adapter.Update(dt);

            MessageBox.Show("Successful loading");

            


            }
        catch (Exception)
        {

            throw;
        }
        finally { sqlCon.Close(); }
    }
    }
}

