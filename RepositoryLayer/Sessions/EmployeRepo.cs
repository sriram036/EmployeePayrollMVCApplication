using ModelLayer.Models;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Sessions
{
    public class EmployeRepo : IEmployeRepo
    {
        private readonly string ConnectionString = "Server=DESKTOP-62VIJ9H\\SQLEXPRESS;Database=EmployeePayrollDB;Trusted_Connection=True;MultipleActiveResultSets=true";

        public bool AddEmployee(Employee employee)
        {
            bool isFound = false;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                isFound = true;
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", employee.EmployeeName);
                cmd.Parameters.AddWithValue("@Profile", employee.EmployeeProfile);
                cmd.Parameters.AddWithValue("@Gender", employee.EmployeeGender);
                cmd.Parameters.AddWithValue("@Department", employee.EmployeeDepartment);
                cmd.Parameters.AddWithValue("@Salary", employee.EmployeeSalary);
                cmd.Parameters.AddWithValue("@StartDate", employee.EmployeeStartDate);
                cmd.Parameters.AddWithValue("@Notes", employee.EmployeeNotes);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return isFound;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            List<Employee> Employees = new List<Employee>();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader Reader = cmd.ExecuteReader();

                while (Reader.Read())
                {
                    Employee employee = new Employee();

                    employee.EmployeeId = Convert.ToInt64(Reader["EmployeeId"]);
                    employee.EmployeeName = Reader["EmployeeName"].ToString();
                    employee.EmployeeProfile = Reader["EmployeeProfile"].ToString();
                    employee.EmployeeGender = Reader["EmployeeGender"].ToString();
                    employee.EmployeeDepartment = Reader["EmployeeDepartment"].ToString();
                    employee.EmployeeSalary = Convert.ToInt64(Reader["EmployeeSalary"]);
                    employee.EmployeeStartDate = Convert.ToDateTime(Reader["EmployeeStartDate"]);
                    employee.EmployeeNotes = Reader["EmployeeNotes"].ToString();

                    Employees.Add(employee);
                }
                con.Close();
            }
            return Employees;
        }

        public Employee GetEmployeeData(long id)
        {
            Employee employee = new Employee();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                string sqlQuery = "select * from Employees where EmployeeId= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                while(Reader.Read())
                {
                    employee.EmployeeId = Convert.ToInt64(Reader["EmployeeId"]);
                    employee.EmployeeName = Reader["EmployeeName"].ToString();
                    employee.EmployeeProfile = Reader["EmployeeProfile"].ToString();
                    employee.EmployeeGender = Reader["EmployeeGender"].ToString();
                    employee.EmployeeDepartment = Reader["EmployeeDepartment"].ToString();
                    employee.EmployeeSalary = Convert.ToInt64(Reader["EmployeeSalary"]);
                    employee.EmployeeStartDate = Convert.ToDateTime(Reader["EmployeeStartDate"]);
                    employee.EmployeeNotes = Reader["EmployeeNotes"].ToString();
                }
            }
            return employee;
        }

        public bool UpdateEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id",employee.EmployeeId);
                cmd.Parameters.AddWithValue("@Name", employee.EmployeeName);
                cmd.Parameters.AddWithValue("@Profile", employee.EmployeeProfile);
                cmd.Parameters.AddWithValue("@Gender", employee.EmployeeGender);
                cmd.Parameters.AddWithValue("@Department", employee.EmployeeDepartment);
                cmd.Parameters.AddWithValue("@Salary", employee.EmployeeSalary);
                cmd.Parameters.AddWithValue("@StartDate", employee.EmployeeStartDate);
                cmd.Parameters.AddWithValue("@Notes", employee.EmployeeNotes);
                cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return true;
        }

        public bool DeleteEmployee(long id)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return true;
        }

        public long Login(LoginModel loginModel)
        {
            long Id = 0;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spLoginEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", loginModel.EmployeeId);
                cmd.Parameters.AddWithValue("@Name", loginModel.EmployeeName);

                con.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                
                while (Reader.Read())
                {
                    Id = Convert.ToInt64(Reader["EmployeeId"]);
                }
                con.Close();
            }
            
            return Id;
        }
    }
}
