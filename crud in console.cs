using System;
using System.Data.SqlClient;

namespace Lab_Report
{
    public class DatabaseConnect
    {
        public string conStr = @"Data Source=LAPTOP-S3QP8D6B\SQLEXPRESS02;Database=Lab21;Integrated Security=SSPI";
    }
    class Call
    {
        static void Main(string[] args)
        {
            char yn;
            do
            {
                Console.Write("Select the operation : 1. Insert 2. Read 3. Update 4.Delete :\t");
                int num = Convert.ToInt32(Console.ReadLine());

                DatabaseConnect dc = new DatabaseConnect();
                SqlConnection con = new SqlConnection(dc.conStr);

                if (num == 1)    //Insert
                {
                    Console.Write("Enter the id : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter the name : ");
                    string name = Console.ReadLine();

                    SqlCommand cmd = new SqlCommand($"INSERT INTO Data VALUES ('{id}','{name}')", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Console.WriteLine("Data inserted successfully! ");
                }
                else if (num == 2)   //Read
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Data;", con);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        string id = dr["id"].ToString();
                        string name = dr["name"].ToString();

                        Console.WriteLine(id + " " + name);
                    }

                    con.Close();
                }
                else if (num == 3)   //Update
                {
                    Console.Write("Insert the row to be updated : ");
                    int row = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter the new id : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter the new name : ");
                    string name = Console.ReadLine();

                    SqlCommand cmd = new SqlCommand($"UPDATE Data SET id = {id}, name = '{name}' WHERE id = {row};", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Console.WriteLine("Data Updated successfully! ");
                }
                else if (num == 4)   //Delete
                {
                    Console.Write("Insert the row to be deleted : ");
                    int row = Convert.ToInt32(Console.ReadLine());

                    SqlCommand cmd = new SqlCommand($"DELETE FROM Data where id = {row};", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Console.WriteLine("Data deleted successfully! ");
                }
                else
                {
                    Console.WriteLine("The number you enter is Invalid. ");
                }
                Console.Write("\nDo you want to continue?y/n :");
                yn = Convert.ToChar(Console.ReadLine());
            }
            while (yn == 'y');
        }
    }
}
