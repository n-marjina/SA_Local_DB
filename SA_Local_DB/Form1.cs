using Microsoft.Data.SqlClient;
using System.Data;

namespace SA_Local_DB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DB_Connection();


        }
        public void DB_Connection()
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=master;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                richTextBox1.AppendText("����������� �������");
                // ����� ���������� � �����������
                richTextBox1.AppendText("�������� �����������:");
                richTextBox1.AppendText($"\n������ �����������: {connection.ConnectionString}");
                richTextBox1.AppendText($"\n���� ������: {connection.Database}");
                richTextBox1.AppendText($"\n������: {connection.DataSource}");
                richTextBox1.AppendText($"\n������ �������: {connection.ServerVersion}");
                richTextBox1.AppendText($"\n���������: {connection.State}");
                richTextBox1.AppendText($"\nWorkstationld: {connection.WorkstationId}");

                SqlCommand command = new SqlCommand();
                // ���������� ����������� �������
                //command.CommandText = "CREATE TABLE Users (Id INT PRIMARY KEY IDENTITY, Age INT NOT NULL, Name NVARCHAR(100) NOT NULL)";
                // ���������� ������������ �����������
                command.Connection = connection;
                // ��������� �������
                // command.ExecuteNonQuery();
                //command.CommandText = "INSERT INTO Users (Name, Age) VALUES ('Tom', 36)";
                command.CommandText = "SELECT* FROM Users";
                // ���������� ������������ �����������
                // ��������� �������
                command.ExecuteNonQuery();
                SqlDataReader DataReader = command.ExecuteReader();
                if (DataReader.HasRows)
                {
                    DataTable data = new DataTable();
                    data.Load(DataReader);
                    dataGridView1.DataSource = data;
                }
            }
            richTextBox1.AppendText("\n����������� �������...");
            richTextBox1.AppendText("\n��������� ��������� ������.");
          
        }
       
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

}
