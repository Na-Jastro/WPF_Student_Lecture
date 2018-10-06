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
using Tulpep.NotificationWindow;

namespace Task_2
{
    /// <summary>
    /// Interaction logic for Memo.xaml
    /// </summary>
    public partial class Memo : Window
    {
        //connecting to a database
        DataSet ds = new DataSet();
        SqlConnection cn = new SqlConnection(@"Data Source=.;Initial Catalog=RECORDS;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        PopupNotifier popup = new PopupNotifier();

        SqlDataAdapter da = new SqlDataAdapter();
        int correctAnswer;
        public Memo()
        {
            InitializeComponent();
        }

        private void btnViewLectureStudentAnswers_Click(object sender, RoutedEventArgs e)
        {
            // displaying Lecture memo
            try
            {
                cn.Open();
                string query = "select * from ViewMemo";
                cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();

                SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dataAdp.Fill(dt);
                dataGrid1.ItemsSource = dt.DefaultView;
                dataAdp.Update(dt);
                cn.Close();
            }
            catch (Exception ex)
            {
                // using biding notifiaction to display error            
                popup.Image = Properties.Resources.information_2_512;
                popup.TitleText = "Error";
                popup.ContentText = "Error Loading Memo";
                popup.Popup();
            }

            // displaying student answers
            try
            {
                cn.Open();
                string query = "select * from StudentAnswers";
                cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();

                SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dataAdp.Fill(dt);
                dataGrid2.ItemsSource = dt.DefaultView;
                dataAdp.Update(dt);
                cn.Close();
            }
            catch (Exception ex)
            {
                // using biding notifiaction to display error            
                popup.Image = Properties.Resources.information_2_512;
                popup.TitleText = "Error";
                popup.ContentText = "Error Loading Student Answers";
                popup.Popup();
                
            }
        }

        private void btnMemo_Click(object sender, RoutedEventArgs e)
        {
            PopupNotifier popup = new PopupNotifier();
            // Display student Marks
            for (int i = 0; i < LectureStudent.LectureAnswers.Count; i++)
            {
                
                if (LectureStudent.LectureAnswers[i].ToString() == LectureStudent.StudentAnswer[i].ToString())
                {
                    correctAnswer = correctAnswer + 1;
                }
                else if (LectureStudent.LectureAnswers[i].ToString() != LectureStudent.StudentAnswer[i].ToString())
                {

                }
            }
            // using biding notifiaction to display marks            
            popup.Image = Properties.Resources.information_2_512;
            popup.TitleText = "Marks";
            popup.ContentText = "Total: " + correctAnswer + "/5";
            popup.Popup();
            
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            // displaying the home Page
            Home h = new Home();
            h.Show();
            this.Hide();
        }
    }
}
