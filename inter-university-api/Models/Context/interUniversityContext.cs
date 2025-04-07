using inter_university_api.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inter_university_api.Models.Context
{
    public partial class interUniversityContext : DbContext
    {
        public interUniversityContext()
        {

        }

        public interUniversityContext(DbContextOptions<interUniversityContext> options) : base(options)
        {

        }

        public static string GetConnectionString()
        {
            return Startup.db_inter_university;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var con = GetConnectionString();
                optionsBuilder.UseSqlServer(con);
            }
        }

        #region DataSet 
        public virtual DbSet<Student> student { get; set; }
        public virtual DbSet<Subjet> subjets { get; set; }
        public virtual DbSet<ClassRegistration> ClassRegistrations { get; set; }
        public virtual DbSet<ClassParnertsModel> ClassParnertsModel { get; set; }
        public virtual DbSet<Login> LoginModel { get; set; }
        #endregion
    }
}
