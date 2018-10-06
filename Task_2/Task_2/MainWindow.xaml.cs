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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Connecting to the database 
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=RECORDS;Integrated Security=True");
        SqlCommand createCommand = new SqlCommand();
        public MainWindow()
        {
            InitializeComponent();
            createCommand.Connection = con;
        }

       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           
        }

        private void ___btnLoadQuestions_Click(object sender, RoutedEventArgs e)
        {
            //SqlConnection con = new SqlConnection();
            try
            {
                con.Open();
                string query = "select * from LectureQuestions";
                createCommand = new SqlCommand(query, con);
                createCommand.ExecuteNonQuery();

                SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
                DataTable dt = new DataTable();
                dataAdp.Fill(dt);
                dataGrid1.ItemsSource = dt.DefaultView;
                dataAdp.Update(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex, "Error", MessageBoxButton.OK);
            }
        }
    }
}
