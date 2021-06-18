using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EFwithDropdown.Models
{
    public class EmployeeDetails
    {
        public DataTable DisplayEmployee(string Name)
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection("data source =DESKTOP-8CS1DM6; Integrated security= true;database = AdventureWorks2019");
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Emp_by_dep", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", Name);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;

        }

        //public int BusinessEntityID { get; set; }

        //public string FirstName { get; set; }
        //public string Gender { get; set; }
        //public string MaritalStatus { get; set; }
        //public DateTime Hiredate { get; set; }

        //public DataTable dt { get; set; } 

        public DataTable GetDepartment()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection("data source =DESKTOP-8CS1DM6; Integrated security= true;database = AdventureWorks2019");
            SqlCommand cmd = new SqlCommand("select DepartmentID,Name from HumanResources.Department", con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }
    }
}