using OnlineLibraryMS2.Models.Maps;
using OnlineLibraryMS2.Models.Tables;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;

namespace OnlineLibraryMS2.Models.Context
{
    public class LibraryContextInitializer : IDatabaseInitializer<LibraryContext>
    {
        public void InitializeDatabase(LibraryContext context)
        {
            DbInterception.Add(new MySqlVersionInterceptor());
        }
    }

    [DbConfigurationType(typeof(OnlineLibraryMS2.MySqlConfiguration))]
    public class LibraryContext : DbContext
    {
        public LibraryContext() : base("Name=librarydb")
        {
            DbInterception.Add(new MySqlVersionInterceptor());
        }

        public DbSet<tbl_users_model> tbl_users { get; set; }
        public DbSet<tbl_categories_model> tbl_categories { get; set; }
        public DbSet<tbl_books_models> tbl_books { get; set; }
        public DbSet<tbl_borrows_models> tbl_borrows { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new tbl_users_maps());
            modelBuilder.Configurations.Add(new tbl_categories_maps());
            modelBuilder.Configurations.Add(new tbl_books_maps());
            modelBuilder.Configurations.Add(new tbl_borrows_maps());
        }
    }
}