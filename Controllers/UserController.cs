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
            _con = new SqlConnection("Server= localhost; Database= l5r; Integrated Security=True;");
            DataTable _dt = new DataTable();
            var query = "select * from Users";
            _adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, _con)
            };
            _adapter.Fill(_dt);
            List<User> users = new List<User>(_dt.Rows.Count);

            if(_dt.Rows.Count > 0)
            {
                foreach(DataRow userRecord in _dt.Rows)
                {
                    users.Add(new ReadUser(userRecord));
                }
            }

            return users;
        }

        // GET: api/User/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
