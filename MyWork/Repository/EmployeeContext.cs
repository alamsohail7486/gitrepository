using Dapper;
using MyWork.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyWork.Repository
{
    public class EmployeeContext
    {

        static string conString = ConfigurationManager.ConnectionStrings["Data"].ConnectionString;
        SqlConnection db = new SqlConnection(conString);
        //To inserting the data fro employee...
        public void InsertEmployee(employee employee)
        {
            try
            {
                db.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@Name", employee.Name);
                param.Add("@Age", employee.Age);
                param.Add("@Contact_no", employee.Contact_no);
                param.Add("@Address", employee.Address);
                param.Add("@Salary", employee.Salary);
                param.Add("@Email_id", employee.Email_id);
                db.Execute("InsertEmployee", param, commandType: System.Data.CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Close();
            }
        }


        // Getting the data from table for employee...
        public List<employee> GetEmployee()
        {
            try
            {
                db.Open();
                List<employee> customers = SqlMapper.Query<employee>
                    (db, "EmployeeList", commandType: System.Data.CommandType.StoredProcedure).ToList();
                return customers;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            }
        }
        //Deleting data from employee..
        public void DeleteEmployee(int Id)
        {

            try
            {
                db.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@Id", Id);
                db.Execute("DeleteEmployee", param, commandType: System.Data.CommandType.StoredProcedure);

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Close();
            }
        }
        //here we are selecting the data of employee...
        public employee SelectEmployee(int Id)
        {
            try
            {
                db.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@Id", Id);
                employee employee = SqlMapper.Query<employee>(db, "SelectEmployee", param, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
                return employee;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Close();
            }
        }
        //here we are selecting the data of employee...
        public void Update(employee employee)
        {
            try
            {
                db.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@Id", employee.Id);
                param.Add("@Name", employee.Name);
                param.Add("@Age", employee.Age);
                param.Add("@Contact_no", employee.Contact_no);
                param.Add("@Address", employee.Address);
                param.Add("@Salary", employee.Salary);
                param.Add("@Email_id", employee.Email_id);
                db.Execute("UpdateRecord", param, commandType: System.Data.CommandType.StoredProcedure);


            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Close();
            }
        }
    
    }
}

