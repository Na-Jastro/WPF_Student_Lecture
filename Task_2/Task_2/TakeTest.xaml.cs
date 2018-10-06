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
    /// Interaction logic for TakeTest.xaml
    /// </summary>
    public partial class TakeTest : Window
    {
        //connecting to a database
        DataSet ds = new DataSet();
        SqlConnection cn = new SqlConnection(@"Data Source=.;Initial Catalog=RECORDS;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();

        SqlDataAdapter da = new SqlDataAdapter();
        public static string q1, q2, q3, q4, q5;

        private void btnMemo_Click(object sender, RoutedEventArgs e)
        {
            // Displaying Memo page 
            Memo m = new Memo();
            m.Show();
            this.Hide();
        }

        public TakeTest()
        {
            InitializeComponent();
            cmd.Connection = cn;
        }

        private void btnLoadTest_Click(object sender, RoutedEventArgs e)
        {
            // displaying Lecture Questions
            try
            {
                cn.Open();
                string query = "select * from LectureQuestions";
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
                // Using popup Notification to diplay Error
                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.information_2_512;
                popup.TitleText = "Error ";
                popup.ContentText = " " + ex.Message;
                popup.Popup();
            }
        }

        private void btnSaveAnswers_Click(object sender, RoutedEventArgs e)
        {
            //try and catch block
            try
            {
                if (txtAnswer1.Text != "" & txtAnswer2.Text != "" & txtAnswer3.Text != "" & txtAnswer4.Text != "" & txtAnswer5.Text != "")
                {
                    //  writing answers to the Database
                    cn.Open();
                    cmd.CommandText = "insert into StudentAnswers (studentAnswer1,studentAnswer2,studentAnswer3,studentAnswer4,studentAnswer5) values ('" + txtAnswer1.Text + "', '" + txtAnswer2.Text + "', '" + txtAnswer3.Text + "', '" + txtAnswer4.Text + "','" + txtAnswer5.Text + "')";
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    PopupNotifier popup = new PopupNotifier();
                    popup.Image = Properties.Resources.information_2_512;
                    popup.TitleText = "Student Answers";
                    popup.ContentText = "Student Answers SAVED!!!";
                    popup.Popup();
                    cn.Close();
                }
                else
                {
                    //Using Popup Notification To show Error
                    PopupNotifier popup = new PopupNotifier();
                    popup.Image = Properties.Resources.information_2_512;
                    popup.TitleText = "Error in Student Answers";
                    popup.ContentText = "No empty spaces allowed!!!!";
                    popup.Popup();
                }
            }
            catch (Exception c)
            {
                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.information_2_512;
                popup.TitleText = "Error ";
                popup.ContentText = " " + c.Message;

            }
            //transfering text box data in declared string variables
            q1 = txtAnswer1.Text;
            q2 = txtAnswer2.Text;
            q3 = txtAnswer3.Text;
            q4 = txtAnswer4.Text;
            q5 = txtAnswer5.Text;

            //inserting string variables string array<list>
            LectureStudent.StudentAnswer.Add(q1);
            LectureStudent.StudentAnswer.Add(q2);
            LectureStudent.StudentAnswer.Add(q3);
            LectureStudent.StudentAnswer.Add(q4);
            LectureStudent.StudentAnswer.Add(q5);
        }
    }
    }
