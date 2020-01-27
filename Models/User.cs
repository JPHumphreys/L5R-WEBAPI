using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace L5R_API.Models
{
    public class User
    {
        public string username { get; set; } = "";
        public string password { get; set; } = "";
    }

    public class CreateUser : User
    {

    }

    public class ReadUser : User
    {
        public ReadUser(DataRow row)
        {
            username = row["username"].ToString();
            password = row["password"].ToString();
        }

        //add variables here
        public string username { get; set; } = "";
        public string password { get; set; } = "";
    }
}