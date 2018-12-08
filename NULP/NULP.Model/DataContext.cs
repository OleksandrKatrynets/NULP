using System;
using Microsoft.EntityFrameworkCore;
using NULP.Model.Models;

namespace NULP.Model
{
    public class DataContext : DbContext
    {
        private static string ConnectionString
        {
            get
            {
                const string password = "SetTv0195";
                if (string.IsNullOrEmpty(password))
                {
                    throw new NotImplementedException();
                }
                return $@"
                    Server=127.0.0.1,1433;
                    Database=NULP;
                    User Id=SA;
                    Password={password}
                ";                
            }
        } 
        
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Person> Persons { get; set; }
 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }
    }
}