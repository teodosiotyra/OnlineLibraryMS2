using OnlineLibraryMS2.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace OnlineLibraryMS2.Models.Maps
{
    public class tbl_categories_maps : EntityTypeConfiguration<tbl_categories_model>
    {
        public tbl_categories_maps()
        {
            HasKey(i => i.CategoryID);

            Property(i => i.CategoryID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(i => i.CategoryName)
                .HasMaxLength(50);

            ToTable("Categories");
        }
    }
}