using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System
{
    class DatabaseHelper
    {
        public static SqlConnection GetConnection()
        {

            SqlConnection con = new SqlConnection("Data Source=SUDIPTA\\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=True;");

            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return con;
        }
        public static DataTable GetDiagnosisById(int diagnosis_Id)
        {
            string query = "SELECT * FROM Diagnosis WHERE Diagnosis_ID = @DiagnosisID";
            SqlParameter[] parameters = {
            new SqlParameter("@DiagnosisID", diagnosis_Id)
            };
            return ExecuteQuery(query, parameters);
        }
        public static DataTable GetBillById(int bill_Id)
        {
            string query = "SELECT * FROM Bill WHERE Bill_ID = @BillID";
            SqlParameter[] parameters = {
            new SqlParameter("@billID", bill_Id)
            };
            return ExecuteQuery(query, parameters);
        }
        // Method to execute Insert, Update, Delete Queries
        public static int ExecuteNonQuery(string query, SqlParameter[] parameters)
        {
            int rowsAffected = 0;
            using (SqlConnection con = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }
        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
    }
}
