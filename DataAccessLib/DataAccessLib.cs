using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Configuration;

namespace DataAccessLayer
{
    public class DataAccessLib
    {
        public List<Employee> GetEmployees
        {
            get
            {
                string con = System.Configuration.ConfigurationManager.ConnectionStrings["connectionStr"].ToString();
                SqlConnection sql_conn = new SqlConnection(con);
                sql_conn.Open();
                List<Employee> empList = new List<Employee>();
                Employee emp;
                SqlDataReader reader = null;
                DataTable dt_scheduled_appts = new DataTable();
                using (SqlCommand sql_command = new SqlCommand("uspGetEmployee", sql_conn))
                {
                    sql_command.CommandType = CommandType.StoredProcedure;
                    sql_command.Parameters.Clear();
                    reader = sql_command.ExecuteReader();

                    while (reader.Read())
                    {
                        emp = new Employee();
                        emp.Id = Convert.ToInt32(reader["id"]);
                        emp.Name = reader["Name"].ToString();
                        emp.Designation = reader["Designation"].ToString();
                        emp.Gender = reader["Gender"].ToString();
                        emp.Role = reader["Role"].ToString();
                        emp.Salary = Convert.ToDouble(reader["Salary"]);
                        emp.City = reader["City"].ToString();
                        emp.State = reader["State"].ToString();
                        emp.Zip = reader["Zip"].ToString();
                        emp.Address = reader["Address"].ToString();
                        empList.Add(emp);
                    }
                    return empList;
                }
            }

        }

        public void AddEmployees(Employee emp)
        {
            string con = System.Configuration.ConfigurationManager.ConnectionStrings["connectionStr"].ToString();
            SqlConnection sql_conn = new SqlConnection(con);
            sql_conn.Open();
            using (SqlCommand sql_command = new SqlCommand("uspInsertEmployee", sql_conn))
            {
                sql_command.CommandType = CommandType.StoredProcedure;
                sql_command.Parameters.Clear();
                sql_command.Parameters.AddWithValue("@name", emp.Name);
                sql_command.Parameters.AddWithValue("@designation", emp.Designation);
                sql_command.Parameters.AddWithValue("@gender", emp.Gender);
                sql_command.Parameters.AddWithValue("@role", emp.Role);
                sql_command.Parameters.AddWithValue("@salary", emp.Salary);
                sql_command.Parameters.AddWithValue("@city", emp.City);
                sql_command.Parameters.AddWithValue("@state", emp.State);
                sql_command.Parameters.AddWithValue("@zip", emp.Zip);
                sql_command.Parameters.AddWithValue("@address", emp.Address);
                sql_command.ExecuteNonQuery();
            }

        }

        public void DeleteEmployees(int id)
        {

            string con = System.Configuration.ConfigurationManager.ConnectionStrings["connectionStr"].ToString();
            SqlConnection sql_conn = new SqlConnection(con);
            sql_conn.Open();
            DataTable dt_scheduled_appts = new DataTable();
            using (SqlCommand sql_command = new SqlCommand("uspDeleteEmployee", sql_conn))
            {
                sql_command.CommandType = CommandType.StoredProcedure;
                sql_command.Parameters.Clear();
                sql_command.Parameters.AddWithValue("@id", id);
                sql_command.ExecuteNonQuery();
            }


        }

        public void UpdateEmployees(Employee emp)
        {
            string con = System.Configuration.ConfigurationManager.ConnectionStrings["connectionStr"].ToString();
            SqlConnection sql_conn = new SqlConnection(con);
            sql_conn.Open();
            using (SqlCommand sql_command = new SqlCommand("uspEditEmployee", sql_conn))
            {
                sql_command.CommandType = CommandType.StoredProcedure;
                sql_command.Parameters.Clear();
                sql_command.Parameters.AddWithValue("@name", emp.Name);
                sql_command.Parameters.AddWithValue("@designation", emp.Designation);
                sql_command.Parameters.AddWithValue("@gender", emp.Gender);
                sql_command.Parameters.AddWithValue("@role", emp.Role);
                sql_command.Parameters.AddWithValue("@salary", emp.Salary);
                sql_command.Parameters.AddWithValue("@city", emp.City);
                sql_command.Parameters.AddWithValue("@state", emp.State);
                sql_command.Parameters.AddWithValue("@zip", emp.Zip);
                sql_command.Parameters.AddWithValue("@address", emp.Address);
                sql_command.ExecuteNonQuery();
            }
        }
    }
}

