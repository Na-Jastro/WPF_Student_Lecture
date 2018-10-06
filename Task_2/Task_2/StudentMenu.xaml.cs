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

namespace Task_2
{
    /// <summary>
    /// Interaction logic for StudentMenu.xaml
    /// </summary>
    public partial class StudentMenu : Window
    {
        public StudentMenu()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            //displaying Home xaml page
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void btnTakeTest_Click(object sender, RoutedEventArgs e)
        {
            //displaying TakeTest Page
            TakeTest tt = new TakeTest();
            tt.Show();
            this.Show();
        }
    }
}
