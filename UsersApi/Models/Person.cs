using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsersApi.Models
{
    public class Person
    {

        public long id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string email { get; set; }
    }
}