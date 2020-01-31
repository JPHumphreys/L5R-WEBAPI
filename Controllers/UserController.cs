using L5R_API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace L5R_API.Controllers
{
    public class UserController : ApiController
    {

        //declare sql connection
        private SqlConnection _con;
        private SqlDataAdapter _adapter;

        // GET: api/User
        public List<User> Get()
        {
            _con = new SqlConnection("Server= localhost; Database=l5r; Integrated Security=True;");
            DataTable _dt = new DataTable();
            var query = "SELECT * FROM Users";
            _adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, _con)
            };
            _adapter.Fill(_dt);
            List<User> users = new List<Models.User>(_dt.Rows.Count);

            if(_dt.Rows.Count > 0)
            {
                foreach(DataRow userRecord in _dt.Rows)
                {
                    users.Add(new ReadUser(userRecord));
                }
            }

            return users;
        }

        // GET: api/User/username
        public List<User> Get(string username)
        {
            _con = new SqlConnection("Server= localhost; Database=l5r; Integrated Security=True;");
            DataTable _dt = new DataTable();
            var query = "SELECT * FROM Users WHERE username= '" + username + "'";
            _adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, _con)
            };
            _adapter.Fill(_dt);
            List<User> users = new List<Models.User>(_dt.Rows.Count);

            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow userRecord in _dt.Rows)
                {
                    users.Add(new ReadUser(userRecord));
                }
            }

            return users;
        }

        // POST: api/User
        public string Post([FromBody]CreateUser value)
        {

            _con = new SqlConnection("Server= localhost; Database=l5r; Integrated Security=True;");
            var query = "INSERT INTO Users (username, password) VALUES(@username, @password)";
            SqlCommand insertCommand = new SqlCommand(query, _con);

            insertCommand.Parameters.AddWithValue("@username", value.username);
            insertCommand.Parameters.AddWithValue("@password", value.password);

            _con.Open();
            int result = insertCommand.ExecuteNonQuery();
            if(result > 0)
            {
                return "true";
            }
            else
            {
                return "false";
            }

        }

        // PUT: api/User/name
        public string Put(string id, [FromBody]CreateUser value)
        {
            _con = new SqlConnection("Server= localhost; Database=l5r; Integrated Security=True;");
            var query = "UPDATE Users SET username=@username,password=@password WHERE username= '" + id + "'";
            SqlCommand insertCommand = new SqlCommand(query, _con);

            insertCommand.Parameters.AddWithValue("@username", value.username);
            insertCommand.Parameters.AddWithValue("@password", value.password);

            _con.Open();
            int result = insertCommand.ExecuteNonQuery();
            if (result > 0)
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }

        // DELETE: api/User/5
        public string Delete(string id)
        {
            _con = new SqlConnection("Server= localhost; Database=l5r; Integrated Security=True;");
            var query = "DELETE FROM Users WHERE username= '" + id + "'";
            SqlCommand insertCommand = new SqlCommand(query, _con);

            _con.Open();
            int result = insertCommand.ExecuteNonQuery();
            if (result > 0)
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }
    }
}
