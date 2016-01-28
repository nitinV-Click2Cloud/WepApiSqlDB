using System;
using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebApi2.Model;
// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi2.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        // GET: api/User
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return new User[] { new User { Id = 1, UserName = "ABC", Password = "ABC" } };
        }

        // GET api/User/5
       [HttpGet("{id}")]
        //[ActionName("GetEmployeeByID")]
        public User Get(int id)
        {
            //    //return listEmp.First(e => e.ID == id);  
            SqlDataReader reader = null;
             SqlConnection myConnection = new SqlConnection();
            //myConnection.ConnectionString = @"Server=WSD001\SQLEXPRESS;Database=Nitin;User ID=rsinngp/nitin.vaswani;Password=Newuser@123;";
            myConnection.ConnectionString = @"Data Source = WSD001\SQLEXPRESS;Initial Catalog = Nitin;Integrated Security = True";
            SqlCommand sqlCmd = new SqlCommand();
            //sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * from [User] where Id=" + id + "";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            User emp = null;
            while (reader.Read())
            {
                emp = new User();
                emp.Id = Int32.Parse(reader.GetValue(0).ToString());
                emp.UserName = reader.GetValue(1).ToString();
                emp.Password = reader.GetValue(2).ToString();
            }
            myConnection.Close();
            return emp;
          
        }
    }
}
