using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineLibraryMS2.Models.Tables
{
    public class tbl_books_models
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int? CategoryID { get; set; }
        public string Status { get; set; }
        public DateTime? DateAdded { get; set; }

    }
}