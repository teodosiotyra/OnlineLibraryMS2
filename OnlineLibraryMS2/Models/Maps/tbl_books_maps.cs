using OnlineLibraryMS2.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace OnlineLibraryMS2.Models.Maps
{
    public class tbl_books_maps : EntityTypeConfiguration<tbl_books_models>
    {
        public tbl_books_maps()
        {
            HasKey(i => i.BookID);

            Property(i => i.BookID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(i => i.Title)
                .HasMaxLength(100);

            Property(i => i.Author)
                .HasMaxLength(100);

            Property(i => i.Status)
                .HasMaxLength(20);

            Property(i => i.DateAdded)
                .HasColumnName("DateAdded");

            
            ToTable("Books");
        }
    }
}