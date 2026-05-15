using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineLibraryMS2.Models.Tables
{
    public class tbl_users_model
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public DateTime? DateRegistered { get; set; }

    }
}