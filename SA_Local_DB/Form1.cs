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
                richTextBox1.AppendText("Подключение открыто");
                // Вывод информации о подключении
                richTextBox1.AppendText("Свойства подключения:");
                richTextBox1.AppendText($"\nСтрока подключения: {connection.ConnectionString}");
                richTextBox1.AppendText($"\nБаза данных: {connection.Database}");
                richTextBox1.AppendText($"\nСервер: {connection.DataSource}");
                richTextBox1.AppendText($"\nВерсия сервера: {connection.ServerVersion}");
                richTextBox1.AppendText($"\nСостояние: {connection.State}");
                richTextBox1.AppendText($"\nWorkstationld: {connection.WorkstationId}");

                SqlCommand command = new SqlCommand();
                // определяем выполняемую команду
                //command.CommandText = "CREATE TABLE Users (Id INT PRIMARY KEY IDENTITY, Age INT NOT NULL, Name NVARCHAR(100) NOT NULL)";
                // определяем используемое подключение
                command.Connection = connection;
                // выполняем команду
                // command.ExecuteNonQuery();
                //command.CommandText = "INSERT INTO Users (Name, Age) VALUES ('Tom', 36)";
                command.CommandText = "SELECT* FROM Users";
                // определяем используемое подключение
                // выполняем команду
                command.ExecuteNonQuery();
                SqlDataReader DataReader = command.ExecuteReader();
                if (DataReader.HasRows)
                {
                    DataTable data = new DataTable();
                    data.Load(DataReader);
                    dataGridView1.DataSource = data;
                }
            }
            richTextBox1.AppendText("\nПодключение закрыто...");
            richTextBox1.AppendText("\nПрограмма завершила работу.");
          
        }
       
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

}
