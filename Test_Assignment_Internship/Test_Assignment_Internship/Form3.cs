using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Test_Assignment_Internship
{
    public partial class Form3 : Form
    {
        

        public Form3()
        {
            InitializeComponent();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

       
        private void Form3_Load(object sender, EventArgs e)
        {
            //connect to database
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=OSCAR\MSSQLSERVER01;Initial Catalog=AssignmentSurvey;User ID=sa;Password=Oscarngobeni26@";
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            //view data in datagridview
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM UsersDetail", cnn);
            DataSet ds = new DataSet();
            da.Fill(ds, "UsersDetail");
            dataGridView1.DataSource = ds.Tables["UsersDetail"].DefaultView;
            dataGridView1.Columns[0].HeaderText = "";

            

            //display number of survey taken
            double noOfRows = 0;
            noOfRows = dataGridView1.RowCount -1;
            totalsurvey.Text = (noOfRows.ToString());

            //calculating sum total of age rows
            int i; double sum = 0;
            for (i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
            }

            //calculating avg total of age rows 
            double countRow = dataGridView1.Rows.Count -1;
            double avg = sum / countRow;
            avg = Math.Round(avg, 1);
            AvgAge.Text = avg.ToString();


            //Calculating Oldest person who participated in survey 
            AgeMax.Text = (from DataGridViewRow row in dataGridView1.Rows
                           where row.Cells[5].FormattedValue.ToString() != string.Empty
                           select Convert.ToInt32(row.Cells[5].FormattedValue)).Max().ToString();

            //Calculating Youngest person who participated in survey
            AgeMin.Text = (from DataGridViewRow row in dataGridView1.Rows
                           where row.Cells[5].FormattedValue.ToString() != string.Empty
                           select Convert.ToInt32(row.Cells[5].FormattedValue)).Min().ToString();



            //Count how many times pizza appeared 
            SqlCommand command;
            string query = "SELECT COUNT(favourite_food)FROM UsersDetail WHERE favourite_food='pizza' OR favourite_food='pizza,Pasta' OR favourite_food='pizza,Pasta,Pap and Wors' OR favourite_food='pizza,Pasta,Pap and Wors,Chicken stir fry' OR favourite_food='pizza,Pasta,Pap and Wors,Chicken stir fry,Beef stir fry' OR favourite_food='pizza,Pasta,Pap and Wors,Chicken stir fry,Beef stir fry,Other'";

            command = new SqlCommand(query, cnn);
            //Read from database
            Int32 rowsPizaa = Convert.ToInt32(command.ExecuteScalar());
            command.Dispose();
            double pizzaPecentange = 0;
            //calculate the percentage of people who likes pizza
            pizzaPecentange = rowsPizaa / noOfRows * 100;
            pizzaPecentange = Math.Round(pizzaPecentange, 1);
            pizza.Text = pizzaPecentange.ToString() + "%";



            //Count how many times Pasta appeared 
            //SqlCommand command;
            string Query = "SELECT COUNT(favourite_food)FROM UsersDetail WHERE favourite_food='Pasta' OR favourite_food='Pasta,Pap and Wors' OR favourite_food='Pasta,Pap and Wors,Chicken stir fry' OR favourite_food='Pasta,Pap and Wors,Chicken stir fry,Beef stir fry' OR favourite_food='Pasta,Pap and Wors,Chicken stir fry,Beef stir fry,Other'";

            command = new SqlCommand(Query, cnn);
            //Read from database
            Int32 rowsPasta = Convert.ToInt32(command.ExecuteScalar());
            command.Dispose();
            double PastaPecentange = 0;
            //calculate the percentage of people who likes Pasta
            PastaPecentange = rowsPasta / noOfRows * 100;
            PastaPecentange = Math.Round(PastaPecentange, 1);
            Pasta.Text = PastaPecentange.ToString() + "%";
            


            //Count how many times Pap and Wors appeared 
            //SqlCommand command;
            string Querys = "SELECT COUNT(favourite_food)FROM UsersDetail WHERE favourite_food='Pap and Wors' OR favourite_food='Pap and Wors,Chicken stir fry' OR favourite_food='Pap and Wors,Chicken stir fry,Beef stir fry' OR favourite_food='Pap and Wors,Chicken stir fry,Beef stir fry,Other'";

            command = new SqlCommand(Querys, cnn);
            //Read from database
            Int32 rowsPap = Convert.ToInt32(command.ExecuteScalar());
            command.Dispose();
            double PapPecentange = 0;
            //calculate the percentage of people who likes Pap and Wors
            PapPecentange = rowsPap / noOfRows * 100;
            PapPecentange = Math.Round(PapPecentange, 1);
            Pap.Text = PapPecentange.ToString() + "%";



            //Count how many %of I like to eat out
            //SqlCommand command;
            string q = "SELECT COUNT(like_to_eat)FROM UsersDetail WHERE like_to_eat='Strongly Agree' OR like_to_eat='agree' OR like_to_eat='Neutral'";

            command = new SqlCommand(q, cnn);
            //Read from database
            Int32 rows_eat_out = Convert.ToInt32(command.ExecuteScalar());
            command.Dispose();
            double eat_out_Pecentange = 0;
            //calculate the percentage of people who likes pizza
            eat_out_Pecentange = rows_eat_out / noOfRows * 100;
            eat_out_Pecentange = Math.Round(eat_out_Pecentange, 1);
            eat.Text = eat_out_Pecentange.ToString() + "%";


            //Count how many %of I like to watch movies
            //SqlCommand command;
            string Qr = "SELECT COUNT(like_Movies)FROM UsersDetail WHERE like_Movies='Strongly Agree' OR like_Movies='agree'";

            command = new SqlCommand(Qr, cnn);
            //Read from database
            Int32 rows_movies = Convert.ToInt32(command.ExecuteScalar());
            command.Dispose();
            double movies_Pecentange = 0;
            //calculate the percentage of  I like to watch movies
            movies_Pecentange = rows_movies / noOfRows * 100;
            movies_Pecentange = Math.Round(movies_Pecentange, 1);
            movies.Text = movies_Pecentange.ToString() + "%";


            //Count how many %of I like to watch TV
            //SqlCommand commandQr;
            string Qry = "SELECT COUNT(like_TV)FROM UsersDetail WHERE like_TV='Strongly Agree' OR like_TV='agree' ";

            command = new SqlCommand(Qry, cnn);
            //Read from database
            Int32 rows_tv = Convert.ToInt32(command.ExecuteScalar());
            command.Dispose();
            double tv_Pecentange = 0;
            //calculate the percentage of I like to watch TV
            tv_Pecentange = rows_tv / noOfRows * 100;
            tv_Pecentange = Math.Round(tv_Pecentange, 1);
            tv.Text = tv_Pecentange.ToString() + "%";


            //Count how many %of I like to listen to the radio
            //SqlCommand command;
            string Qrys = "SELECT COUNT(like_radio)FROM UsersDetail WHERE like_radio='Strongly Agree' OR like_radio='agree'";

            command = new SqlCommand(Qrys, cnn);
            //Read from database
            Int32 rows_radio = Convert.ToInt32(command.ExecuteScalar());
            command.Dispose();
            double radio_Pecentange = 0;
            //calculate the percentage of I like to listen to the radio
            radio_Pecentange = rows_radio / noOfRows * 100;
            radio_Pecentange = Math.Round(radio_Pecentange, 1);
            radio.Text = radio_Pecentange.ToString() + "%";


            /*int xCount = this.dataGridView1.Rows.Cast<DataGridViewRow>()
                 .Select(row => row.Cells[0].Value)
                 .Count(s => s == "Oscar");
             this.New.Text = xCount.ToString();*/



            //calculate number of people who likes pizza
            /*var count = this.dataGridView1.Rows.Cast<DataGridViewRow>()
              .Count(row => row.Cells["favourite_food"].Value == "pizza");

            this.New1.Text = count.ToString();*/


            cnn.Close();
        }
    }
}
