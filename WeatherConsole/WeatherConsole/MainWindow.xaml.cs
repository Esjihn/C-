using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
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
using MySql.Data.MySqlClient;

namespace WeatherConsole
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DbConnection();
            InitializeComponent();
        }






        public static void DbConnection()
        {
            string connectionString = "Server=localhost; User Id=root; Database=grades; Password=Verizon1; SslMode = none";
            string databaseTable = "scores";
            string language = "1";
            string selectQuery = String.Format("SELECT * FROM {0} WHERE [GradeEntryID] = {1}; ",
                databaseTable);

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(selectQuery, connection);
                    command.Connection = connection;
                    command.CommandText = selectQuery;
                    var result = command.ExecuteReader();
                    var rdr = result.Read();
              
                    DataTable dataTable = new DataTable();
                    dataTable.Load(result);



                    for (int j = 0; j < dataTable.Rows.Count; j++)
                    {
                        for (int i = 0; i < dataTable.Columns.Count; i++)
                        {
                            Console.Write(dataTable.Columns[i].ColumnName + " ");
                            Console.WriteLine(dataTable.Rows[j].ItemArray[i]);
                        }
                    }
                    var exists = result.HasRows;
                }
            }
            catch (Exception e)
            { 
                Console.WriteLine(e);

            }
        }
    }


}
