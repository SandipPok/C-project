using System;
using System.Data.SqlClient;
using Lab22.Models;

namespace Lab22.Repository
{
    public class DatabaseConnect
    {
        public string conStr = @"Data Source=LAPTOP-S3QP8D6B\SQLEXPRESS02;Database=Lab22;Integrated Security=SSPI";
        public void AddData(GetData gd)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string insertQuery = $"INSERT INTO Data (Id,Name,Gender) VALUES(" + $"{gd.Id},'{gd.Name}','{gd.Gender}')";
                SqlCommand cmd = new SqlCommand(insertQuery, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public IEnumerable<GetData> GetData()
        {
            List<GetData> dataList = new List<GetData>();
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                string query = "SELECT * FROM Data";
                SqlCommand sc = new SqlCommand(query, con);

                using(SqlDataReader reader = sc.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        GetData data = new GetData();
                        data.Id = Convert.ToInt32(reader["Id"]);
                        data.Name = reader["Name"].ToString();
                        data.Gender = reader["Gender"].ToString();
                        dataList.Add(data);
                    }
                }
                con.Close();
            }
            return dataList;
        }
    }
}
