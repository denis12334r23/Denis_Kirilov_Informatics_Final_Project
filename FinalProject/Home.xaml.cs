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
using System.Windows.Shapes;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();

        }

        private void Contact_Info_Click(object sender, RoutedEventArgs e)
        {
            ContactInformation ci = new ContactInformation();
            ci.Show();
            this.Close();
        }


        private void Dog_Walker_SignUp_Click(object sender, RoutedEventArgs e)
        {
            DogWalkerSignUp dws = new DogWalkerSignUp();
            dws.Show();
            this.Close();
        }

        private void Pet_Click(object sender, RoutedEventArgs e)
        {
            MyPets mp = new MyPets();
            mp.Show();
            this.Close();
        }

        private void Log_Out_Click(object sender, RoutedEventArgs e)
        {
            LogIn li = new LogIn();
            li.Show();
            this.Close();
        }
    }
}
