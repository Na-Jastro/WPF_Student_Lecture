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
    /// Interaction logic for LectureMenu.xaml
    /// </summary>
    public partial class LectureMenu : Window
    {
        public LectureMenu()
        {
            InitializeComponent();

        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Displaying Home xaml page 
            Home h = new Home();
            h.Show();
            this.Hide();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //Displaying Set test xaml page 
            LectureQuestions lq = new LectureQuestions();
            lq.Show();
            this.Hide();

        }
    }
}
