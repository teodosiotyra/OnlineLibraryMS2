using OnlineLibraryMS2.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace OnlineLibraryMS2.Models.Maps
{
    public class tbl_borrows_maps : EntityTypeConfiguration<tbl_borrows_models>
    {
        public tbl_borrows_maps()
        {
            HasKey(i => i.BorrowID);

            Property(i => i.BorrowID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(i => i.Status)
                .HasMaxLength(20);

            

            ToTable("Borrows");
        }
    }
}