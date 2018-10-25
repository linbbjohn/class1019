using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using ConsoleApp1.Models;
namespace ConsoleApp1.Repository
{
    class OpenDataReository
    {
        public string ConnectionString
        {
            get
            {
                return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\xxz31\Source\Repos\class1019\ConsoleApp1\ConsoleApp1\APP_Data\Database1.mdf;Integrated Security=True";
            }
        }
        public void Insert(OpenData item)
        {
            var newItem = item;
            var connection = new SqlConnection(ConnectionString);
            connection.Open();

            var command = new SqlCommand("", connection);
            command.CommandText = string.Format(@"
            INSERT INTO OpenData(服務分類, 資料集名稱, 主要欄位說明)
            VALUES              (N'{0}', N'{1}', N'{2}')
            ", newItem.服務分類, newItem.資料集名稱, newItem.主要欄位說明.Replace("'", ""));

            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}
