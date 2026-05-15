using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace OnlineLibraryMS2.Models.Tables
{
    public class tbl_borrows_models
    {
        public int BorrowID { get; set; }
        public int? UserID { get; set; }
        public int? BookID { get; set; }
        public DateTime? BorrowDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Status { get; set; }

    }

}