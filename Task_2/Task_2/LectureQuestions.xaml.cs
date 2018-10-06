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
    /// Interaction logic for LectureQuestions.xaml
    /// </summary>
    public partial class LectureQuestions : Window
    {
        //Connection string to the data base        
        SqlConnection cn = new SqlConnection(@"Data Source=.;Initial Catalog=RECORDS;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        public static string a1, a2, a3, a4, a5;

        private void btnSaveLectureAnswers_Click(object sender, RoutedEventArgs e)
        {
            // try and catch block
            try
            {
                //checking if there is an empty text box if none then write to database 
                if (txtMemo1.Text != "" & txtMemo2.Text != "" & txtMemo3.Text != "" & txtMemo4.Text != "" & txtMemo5.Text != "")
                {
                    cn.Open();
                    cmd.CommandText = "insert into ViewMemo (answerQuestion1,answerQuestion2,answerQuestion3,answerQuestion4,answerQuestion5) values ('" + txtMemo1.Text + "', '" + txtMemo2.Text + "', '" + txtMemo3.Text + "', '" + txtMemo4.Text + "','" + txtMemo5.Text + "')";
                    cmd.ExecuteNonQuery();
                    cmd.Clone();

                    PopupNotifier popup = new PopupNotifier();
                    popup.Image = Properties.Resources.information_2_512;
                    popup.TitleText = "Lecture Answers Saved";
                    popup.ContentText = "Lecture Answers Succesfully saved to the Database";
                    popup.Popup();
                    cn.Close();
                }
                else
                {
                    PopupNotifier popup = new PopupNotifier();
                    popup.Image = Properties.Resources.information_2_512;
                    popup.TitleText = "Error in Lecture Answers";
                    popup.ContentText = "No empty spaces Allowed ";
                    popup.Popup();
                    
                }
            }
            catch (Exception c)
            {

                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.information_2_512;
                popup.TitleText = "Error ";
                popup.ContentText = " " + c.Message;
                popup.Popup();

            }
            a1 = txtMemo1.Text;
            a2 = txtMemo2.Text;
            a3 = txtMemo3.Text;
            a4 = txtMemo4.Text;
            a5 = txtMemo5.Text;

            LectureStudent.LectureAnswers.Add(a1);
            LectureStudent.LectureAnswers.Add(a2);
            LectureStudent.LectureAnswers.Add(a3);
            LectureStudent.LectureAnswers.Add(a4);
            LectureStudent.LectureAnswers.Add(a5);

        }

        public LectureQuestions()
        {
            InitializeComponent();
            cmd.Connection = cn;

        }

        private void ___btnLoadQuestions_Click(object sender, RoutedEventArgs e)
        {
            // try and catch block
            try
            {
                //checking if there is an empty text box if none then write to database
                if (txtQ1.Text != "" & txtQ2.Text != "" & txtQ3.Text != "" & txtQ4.Text != "" & txtQ5.Text != "")
                {
                    //writing to a Database                
                    cn.Open();
                    cmd.CommandText = "insert into LectureQuestions (question1,question2,question3,question4,question5) values ('" + txtQ1.Text + "', '" + txtQ2.Text + "', '" + txtQ3.Text + "', '" + txtQ4.Text + "','" + txtQ5.Text + "')";
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    PopupNotifier popup = new PopupNotifier();
                    popup.Image = Properties.Resources.information_2_512;
                    popup.TitleText = "Questions Saved";
                    popup.ContentText = "Lecture Questions saved to database successfully!!!";
                    popup.Popup();
                    cn.Close();
                }
                else
                {
                    PopupNotifier popup = new PopupNotifier();
                    popup.Image = Properties.Resources.information_2_512;
                    popup.TitleText = "Error in Lecture Questions";
                    popup.ContentText = "No empty spaces allowed";
                    popup.Popup();
                }
            }
            catch (Exception c)
            {
                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.information_2_512;
                popup.TitleText = "Error ";
                popup.ContentText = " " + c.Message;
                popup.Popup();
                

            }
           

            
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            //displaying the lecture Menu
            Home h = new Home();
            h.Show();
            this.Hide();
        }
    }
}
