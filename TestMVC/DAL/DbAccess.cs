using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using WebApplication1.Models;
namespace WebApplication1.DAL
{
    public class DbAccess
    {
        public DataTable GetEmployee(int id)
        {
            DataSet ds = new DataSet();
            string sqlstr = "select * from Employee where Empid = " + id.ToString();
            using (SqlCommand cmd = new SqlCommand(sqlstr))
            {
                //SqlCommand cmd = new SqlCommand(sqlstr);
                cmd.Connection = DbConnection();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            return ds.Tables[0];
            
        }

        public DataTable GetEmployees()
        {
            DataSet ds = new DataSet();
            string sqlstr = "select * from Employee";
            using (SqlCommand cmd = new SqlCommand(sqlstr))
            {
                //SqlCommand cmd = new SqlCommand(sqlstr);
                cmd.Connection = DbConnection();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            return ds.Tables[0];

        }

        public void SaveEmployee(Employee employee, bool isNew)
        {
            string sqlstr;
            if (isNew)
            {
                sqlstr = "Insert into Employee (EmpId, EmpName, Location) values (" + employee.EmployeeId + ",'" + employee.EmployeeName + "','" + employee.Location + "')";
            }
            else
            {
                sqlstr = "Update Employee set EmpName ='" + employee.EmployeeName + "', Location='" + employee.Location + "' where EmpId =" + employee.EmployeeId;
            }
            using (SqlCommand cmd = new SqlCommand(sqlstr,DbConnection()))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public SqlConnection DbConnection()
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDB"].ToString());
            sqlCon.Open();
            return sqlCon;
        }
        public void DeleteEmployee(int Employeeid)
        {
            string sqlstr = "Delete from Employee where EmpId=" + Employeeid.ToString();
            using (SqlCommand cmd = new SqlCommand(sqlstr, DbConnection()))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}
