using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Task_2
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

        private void btnLecture_Click(object sender, RoutedEventArgs e)
        {
            //displaying Lecture Menu xaml page
            LectureMenu lm = new LectureMenu();
            lm.Show();
            this.Hide();
        }

        private void btnStudent_Click(object sender, RoutedEventArgs e)
        {
            //Displaying Student Menu xaml page
            StudentMenu sm = new StudentMenu();
            sm.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
