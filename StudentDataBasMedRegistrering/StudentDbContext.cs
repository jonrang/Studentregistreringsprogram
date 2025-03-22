using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StudentDataBasMedRegistrering
{
    internal class StudentDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StudentDatabasMedRegistrering;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
