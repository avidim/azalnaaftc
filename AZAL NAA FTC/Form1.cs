using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;

namespace AZAL_NAA_FTC
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        int globalID = 0;
        int localID = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DataBase.mdf;Integrated Security=True");
            try
            {
                connection.Open();
                SqlCommand command;
                SqlDataReader dataReader;

                command = new SqlCommand("SELECT * FROM Trainings", connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                    globalID = Convert.ToInt32(dataReader["ID"]);
                localID = globalID + 1;
                textBox1.Text = localID.ToString();
                dataReader.Close();

                command = new SqlCommand("SELECT * FROM Customers", connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                    comboBox1.Items.Add(dataReader["Customer"]);
                dataReader.Close();

                command = new SqlCommand("SELECT * FROM Slots", connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                    comboBox2.Items.Add(dataReader["Slot"] + "|" + dataReader["Slot_begins"] + "|" + dataReader["Slot_finishes"]);
                dataReader.Close();

                command = new SqlCommand("SELECT * FROM Simulators", connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                    comboBox3.Items.Add(dataReader["Simulator"]);
                dataReader.Close();

                command = new SqlCommand("SELECT * FROM Trainings_type", connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                    comboBox4.Items.Add(dataReader["Training_type"]);
                dataReader.Close();

                command = new SqlCommand("SELECT * FROM Training_details", connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                    comboBox5.Items.Add(dataReader["Training_type"]);
                dataReader.Close();

                command = new SqlCommand("SELECT * FROM Positions", connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    comboBox6.Items.Add(dataReader["Position"]);
                    comboBox7.Items.Add(dataReader["Position"]);
                    comboBox8.Items.Add(dataReader["Position"]);
                    comboBox9.Items.Add(dataReader["Position"]);
                }
                dataReader.Close();

                command = new SqlCommand("SELECT * FROM Employees", connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                    comboBox14.Items.Add(dataReader["Data_entered_by"]);
                dataReader.Close();

                command = new SqlCommand("SELECT * FROM Engineers", connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                    comboBox15.Items.Add(dataReader["Data_entered_by"]);
                dataReader.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            finally
            {
                connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Focus();
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DataBase.mdf;Integrated Security=True");
            try
            {
                connection.Open();
                SqlCommand command;
                if (!(String.IsNullOrWhiteSpace(comboBox1.Text) || String.IsNullOrWhiteSpace(comboBox2.Text) || String.IsNullOrWhiteSpace(comboBox3.Text) || String.IsNullOrWhiteSpace(comboBox4.Text) || String.IsNullOrWhiteSpace(comboBox5.Text) || String.IsNullOrWhiteSpace(comboBox6.Text) || String.IsNullOrWhiteSpace(comboBox7.Text) || String.IsNullOrWhiteSpace(comboBox8.Text) || String.IsNullOrWhiteSpace(comboBox9.Text) || String.IsNullOrWhiteSpace(comboBox14.Text) || String.IsNullOrWhiteSpace(textBox2.Text) || String.IsNullOrWhiteSpace(textBox3.Text) || String.IsNullOrWhiteSpace(textBox5.Text) || String.IsNullOrWhiteSpace(textBox6.Text) || String.IsNullOrWhiteSpace(textBox7.Text) || String.IsNullOrWhiteSpace(textBox8.Text) || String.IsNullOrWhiteSpace(textBox9.Text)))
                {
                    command = new SqlCommand("INSERT INTO Trainings(Customer_ID,SLOT_date,SLOT_ID,FFS_type,Training_type,SLOT_reference,SLOT_duration,Training_details,Instructor,Trainee_1,Trainee_2,Additional_crew_member,Instructor_position,Trainee_1_position,Trainee_2_position,Additional_crew_member_position,Date_and_time_of_arrival,Date_and_time_training_begin,Date_and_time_training_finished,Date_and_time_of_departure,Data_entered_by,Training_duration,Problem_report,Support_engineer) VALUES (@Customer_ID,@SLOT_date,@SLOT_ID,@FFS_type,@Training_type,@SLOT_reference,@SLOT_duration,@Training_details,@Instructor,@Trainee_1,@Trainee_2,@Additional_crew_member,@Instructor_position,@Trainee_1_position,@Trainee_2_position,@Additional_crew_member_position,@Date_and_time_of_arrival,@Date_and_time_training_begin,@Date_and_time_training_finished,@Date_and_time_of_departure,@Data_entered_by,@Training_duration,@Problem_report,@Support_engineer)", connection);
                    command.Parameters.AddWithValue("@Customer_ID", comboBox1.Text);
                    command.Parameters.AddWithValue("@SLOT_date", dateTimePicker1.Value.Date);
                    command.Parameters.AddWithValue("@SLOT_ID", comboBox2.Text);
                    command.Parameters.AddWithValue("@FFS_type", comboBox3.Text);
                    command.Parameters.AddWithValue("@Training_type", comboBox4.Text);
                    command.Parameters.AddWithValue("@SLOT_reference", textBox3.Text);
                    command.Parameters.AddWithValue("@SLOT_duration", textBox2.Text);
                    command.Parameters.AddWithValue("@Training_details", comboBox5.Text);
                    command.Parameters.AddWithValue("@Instructor", textBox5.Text);
                    command.Parameters.AddWithValue("@Trainee_1", textBox6.Text);
                    command.Parameters.AddWithValue("@Trainee_2", textBox7.Text);
                    command.Parameters.AddWithValue("@Additional_crew_member", textBox8.Text);
                    command.Parameters.AddWithValue("@Instructor_position", comboBox6.Text);
                    command.Parameters.AddWithValue("@Trainee_1_position", comboBox7.Text);
                    command.Parameters.AddWithValue("@Trainee_2_position", comboBox8.Text);
                    command.Parameters.AddWithValue("@Additional_crew_member_position", comboBox9.Text);
                    command.Parameters.AddWithValue("@Date_and_time_of_arrival", dateTimePicker2.Value.Date + dateTimePicker2.Value.TimeOfDay);
                    command.Parameters.AddWithValue("@Date_and_time_training_begin", dateTimePicker3.Value.Date + dateTimePicker3.Value.TimeOfDay);
                    command.Parameters.AddWithValue("@Date_and_time_training_finished", dateTimePicker4.Value.Date + dateTimePicker4.Value.TimeOfDay);
                    command.Parameters.AddWithValue("@Date_and_time_of_departure", dateTimePicker5.Value.Date + dateTimePicker5.Value.TimeOfDay);
                    command.Parameters.AddWithValue("@Data_entered_by", comboBox14.Text);
                    command.Parameters.AddWithValue("@Training_duration", textBox9.Text);
                    if (String.IsNullOrWhiteSpace(richTextBox1.Text))
                        command.Parameters.AddWithValue("@Problem_report", " ");
                    else
                        command.Parameters.AddWithValue("@Problem_report", richTextBox1.Text);
                    if (String.IsNullOrWhiteSpace(comboBox15.Text))
                        command.Parameters.AddWithValue("@Support_engineer", " ");
                    else
                        command.Parameters.AddWithValue("@Support_engineer", comboBox15.Text);
                    command.ExecuteNonQuery();
                    if (MessageBox.Show("Data saved successfully!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        globalID += 1;
                        localID += 1;
                        textBox1.Text = localID.ToString();
                        clearFields();
                    }
                }
                else
                    MessageBox.Show("All fields must be filled!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            finally
            {
                connection.Close();
            }
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            if (!(String.IsNullOrWhiteSpace(comboBox2.Text) || String.IsNullOrWhiteSpace(comboBox3.Text) || String.IsNullOrWhiteSpace(comboBox4.Text)))
            {
                if (!(String.IsNullOrEmpty(textBox3.Text)))
                    textBox3.Clear();
                textBox3.Text = dateTimePicker1.Text + comboBox2.Text[0] + "-" + comboBox3.Text + comboBox4.Text;
            }
            else
            {
                if (!(String.IsNullOrEmpty(textBox3.Text)))
                    textBox3.Clear();
                MessageBox.Show("SLOT ID, FFS type and Training type fields must be filled!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan span = dateTimePicker4.Value - dateTimePicker3.Value;
            textBox9.Text = span.Hours.ToString() + ":" + span.Minutes.ToString();
        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan span = dateTimePicker4.Value - dateTimePicker3.Value;
            textBox9.Text = span.Hours.ToString() + ":" + span.Minutes.ToString();
        }

        private void clearFields()
        {
            comboBox1.ResetText();
            comboBox2.ResetText();
            comboBox3.ResetText();
            comboBox4.ResetText();
            comboBox5.ResetText();
            comboBox6.ResetText();
            comboBox7.ResetText();
            comboBox8.ResetText();
            comboBox9.ResetText();
            comboBox14.ResetText();
            comboBox15.ResetText();
            textBox2.Text = "04:00";
            textBox3.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            richTextBox1.Clear();
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            dateTimePicker3.Value = DateTime.Now;
            dateTimePicker4.Value = DateTime.Now;
            dateTimePicker5.Value = DateTime.Now;
            textBox9.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Focus();
            localID += 1;
            button3.Enabled = true;
            if (localID == globalID + 1)
            {
                clearFields();
                textBox1.Text = localID.ToString();
                button2.Enabled = false;
                button1.Enabled = true;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                return;
            }
            else
            {
                textBox1.Text = localID.ToString();
                SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DataBase.mdf;Integrated Security=True");
                try
                {
                    connection.Open();
                    SqlCommand command;
                    SqlDataReader dataReader;

                    command = new SqlCommand("SELECT * FROM Trainings WHERE ID = @LOCAL_ID", connection);
                    command.Parameters.AddWithValue("@LOCAL_ID", localID);
                    dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        comboBox1.Text = dataReader["Customer_ID"].ToString();
                        dateTimePicker1.Value = Convert.ToDateTime(dataReader["SLOT_date"]);
                        comboBox2.Text = dataReader["SLOT_ID"].ToString();
                        comboBox3.Text = dataReader["FFS_type"].ToString();
                        comboBox4.Text = dataReader["Training_type"].ToString();
                        textBox3.Text = dataReader["SLOT_reference"].ToString();
                        textBox2.Text = dataReader["SLOT_duration"].ToString();
                        comboBox5.Text = dataReader["Training_details"].ToString();
                        textBox5.Text = dataReader["Instructor"].ToString();
                        textBox6.Text = dataReader["Trainee_1"].ToString();
                        textBox7.Text = dataReader["Trainee_2"].ToString();
                        textBox8.Text = dataReader["Additional_crew_member"].ToString();
                        comboBox6.Text = dataReader["Instructor_position"].ToString();
                        comboBox7.Text = dataReader["Trainee_1_position"].ToString();
                        comboBox8.Text = dataReader["Trainee_2_position"].ToString();
                        comboBox9.Text = dataReader["Additional_crew_member_position"].ToString();
                        dateTimePicker2.Value = Convert.ToDateTime(dataReader["Date_and_time_of_arrival"]);
                        dateTimePicker3.Value = Convert.ToDateTime(dataReader["Date_and_time_training_begin"]);
                        dateTimePicker4.Value = Convert.ToDateTime(dataReader["Date_and_time_training_finished"]);
                        dateTimePicker5.Value = Convert.ToDateTime(dataReader["Date_and_time_of_departure"]);
                        comboBox14.Text = dataReader["Data_entered_by"].ToString();
                        textBox9.Text = dataReader["Training_duration"].ToString();
                        richTextBox1.Text = dataReader["Problem_report"].ToString();
                        comboBox15.Text = dataReader["Support_engineer"].ToString();
                    }
                    dataReader.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Focus();
            localID -= 1;
            button2.Enabled = true;
            if (localID - 1 == 0)
                button3.Enabled = false;
            textBox1.Text = localID.ToString();
            button1.Enabled = false;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DataBase.mdf;Integrated Security=True");
            try
            {
                connection.Open();
                SqlCommand command;
                SqlDataReader dataReader;

                command = new SqlCommand("SELECT * FROM Trainings WHERE ID = @LOCAL_ID", connection);
                command.Parameters.AddWithValue("@LOCAL_ID", localID);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    comboBox1.Text = dataReader["Customer_ID"].ToString();
                    dateTimePicker1.Value = Convert.ToDateTime(dataReader["SLOT_date"]);
                    comboBox2.Text = dataReader["SLOT_ID"].ToString();
                    comboBox3.Text = dataReader["FFS_type"].ToString();
                    comboBox4.Text = dataReader["Training_type"].ToString();
                    textBox3.Text = dataReader["SLOT_reference"].ToString();
                    textBox2.Text = dataReader["SLOT_duration"].ToString();
                    comboBox5.Text = dataReader["Training_details"].ToString();
                    textBox5.Text = dataReader["Instructor"].ToString();
                    textBox6.Text = dataReader["Trainee_1"].ToString();
                    textBox7.Text = dataReader["Trainee_2"].ToString();
                    textBox8.Text = dataReader["Additional_crew_member"].ToString();
                    comboBox6.Text = dataReader["Instructor_position"].ToString();
                    comboBox7.Text = dataReader["Trainee_1_position"].ToString();
                    comboBox8.Text = dataReader["Trainee_2_position"].ToString();
                    comboBox9.Text = dataReader["Additional_crew_member_position"].ToString();
                    dateTimePicker2.Value = Convert.ToDateTime(dataReader["Date_and_time_of_arrival"]);
                    dateTimePicker3.Value = Convert.ToDateTime(dataReader["Date_and_time_training_begin"]);
                    dateTimePicker4.Value = Convert.ToDateTime(dataReader["Date_and_time_training_finished"]);
                    dateTimePicker5.Value = Convert.ToDateTime(dataReader["Date_and_time_of_departure"]);
                    comboBox14.Text = dataReader["Data_entered_by"].ToString();
                    textBox9.Text = dataReader["Training_duration"].ToString();
                    richTextBox1.Text = dataReader["Problem_report"].ToString();
                    comboBox15.Text = dataReader["Support_engineer"].ToString();
                }
                dataReader.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            finally
            {
                connection.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Focus();
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DataBase.mdf;Integrated Security=True");
            try
            {
                connection.Open();
                SqlCommand command;
                if (!(String.IsNullOrWhiteSpace(comboBox1.Text) || String.IsNullOrWhiteSpace(comboBox2.Text) || String.IsNullOrWhiteSpace(comboBox3.Text) || String.IsNullOrWhiteSpace(comboBox4.Text) || String.IsNullOrWhiteSpace(comboBox5.Text) || String.IsNullOrWhiteSpace(comboBox6.Text) || String.IsNullOrWhiteSpace(comboBox7.Text) || String.IsNullOrWhiteSpace(comboBox8.Text) || String.IsNullOrWhiteSpace(comboBox9.Text) || String.IsNullOrWhiteSpace(comboBox14.Text) || String.IsNullOrWhiteSpace(textBox2.Text) || String.IsNullOrWhiteSpace(textBox3.Text) || String.IsNullOrWhiteSpace(textBox5.Text) || String.IsNullOrWhiteSpace(textBox6.Text) || String.IsNullOrWhiteSpace(textBox7.Text) || String.IsNullOrWhiteSpace(textBox8.Text) || String.IsNullOrWhiteSpace(textBox9.Text)))
                {
                    command = new SqlCommand("UPDATE Trainings SET Customer_ID = @Customer_ID,SLOT_date = @SLOT_date,SLOT_ID = @SLOT_ID,FFS_type = @FFS_type,Training_type = @Training_type,SLOT_reference = @SLOT_reference,SLOT_duration = @SLOT_duration,Training_details = @Training_details,Instructor = @Instructor,Trainee_1 = @Trainee_1,Trainee_2 = @Trainee_2,Additional_crew_member = @Additional_crew_member,Instructor_position = @Instructor_position,Trainee_1_position = @Trainee_1_position,Trainee_2_position = @Trainee_2_position,Additional_crew_member_position = @Additional_crew_member_position,Date_and_time_of_arrival = @Date_and_time_of_arrival,Date_and_time_training_begin = @Date_and_time_training_begin,Date_and_time_training_finished = @Date_and_time_training_finished,Date_and_time_of_departure = @Date_and_time_of_departure,Data_entered_by = @Data_entered_by,Training_duration = @Training_duration,Problem_report = @Problem_report,Support_engineer = @Support_engineer WHERE ID = @LOCAL_ID", connection);
                    command.Parameters.AddWithValue("@Customer_ID", comboBox1.Text);
                    command.Parameters.AddWithValue("@SLOT_date", dateTimePicker1.Value.Date);
                    command.Parameters.AddWithValue("@SLOT_ID", comboBox2.Text);
                    command.Parameters.AddWithValue("@FFS_type", comboBox3.Text);
                    command.Parameters.AddWithValue("@Training_type", comboBox4.Text);
                    command.Parameters.AddWithValue("@SLOT_reference", textBox3.Text);
                    command.Parameters.AddWithValue("@SLOT_duration", textBox2.Text);
                    command.Parameters.AddWithValue("@Training_details", comboBox5.Text);
                    command.Parameters.AddWithValue("@Instructor", textBox5.Text);
                    command.Parameters.AddWithValue("@Trainee_1", textBox6.Text);
                    command.Parameters.AddWithValue("@Trainee_2", textBox7.Text);
                    command.Parameters.AddWithValue("@Additional_crew_member", textBox8.Text);
                    command.Parameters.AddWithValue("@Instructor_position", comboBox6.Text);
                    command.Parameters.AddWithValue("@Trainee_1_position", comboBox7.Text);
                    command.Parameters.AddWithValue("@Trainee_2_position", comboBox8.Text);
                    command.Parameters.AddWithValue("@Additional_crew_member_position", comboBox9.Text);
                    command.Parameters.AddWithValue("@Date_and_time_of_arrival", dateTimePicker2.Value.Date + dateTimePicker2.Value.TimeOfDay);
                    command.Parameters.AddWithValue("@Date_and_time_training_begin", dateTimePicker3.Value.Date + dateTimePicker3.Value.TimeOfDay);
                    command.Parameters.AddWithValue("@Date_and_time_training_finished", dateTimePicker4.Value.Date + dateTimePicker4.Value.TimeOfDay);
                    command.Parameters.AddWithValue("@Date_and_time_of_departure", dateTimePicker5.Value.Date + dateTimePicker5.Value.TimeOfDay);
                    command.Parameters.AddWithValue("@Data_entered_by", comboBox14.Text);
                    command.Parameters.AddWithValue("@Training_duration", textBox9.Text);
                    if (String.IsNullOrWhiteSpace(richTextBox1.Text))
                        command.Parameters.AddWithValue("@Problem_report", " ");
                    else
                        command.Parameters.AddWithValue("@Problem_report", richTextBox1.Text);
                    if (String.IsNullOrWhiteSpace(comboBox15.Text))
                        command.Parameters.AddWithValue("@Support_engineer", " ");
                    else
                        command.Parameters.AddWithValue("@Support_engineer", comboBox15.Text);
                    command.Parameters.AddWithValue("@LOCAL_ID", localID);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Data updated successfully!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("All fields must be filled!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            finally
            {
                connection.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label1.Focus();
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = true;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            localID = globalID + 1;
            clearFields();
            textBox1.Text = localID.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label1.Focus();
            Graphics myGraphics = this.CreateGraphics();
            Bitmap memoryImage = new Bitmap(846, 671, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Location.X + 1, this.Location.Y + 21, 0, 0, memoryImage.Size);
            SolidBrush brush = new SolidBrush(Color.White);
            memoryGraphics.FillRectangle(brush, 482, 516, 329, 42);
            Form2 form2 = new Form2(memoryImage);
            form2.Show();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            label1.Focus();
        }
    }
}