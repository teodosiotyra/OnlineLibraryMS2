using OnlineLibraryMS2.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.ModelConfiguration; 
using System.Linq;
using System.Web;

namespace OnlineLibraryMS2.Models.Maps
{
    public class tbl_users_maps : EntityTypeConfiguration<tbl_users_model>
    {
        public tbl_users_maps()
        {
            HasKey(i => i.UserID);
            Property(i => i.UserID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(i => i.DateRegistered).HasColumnName("DateRegistered");
            ToTable("users");
        }
    }
}