using Microsoft.EntityFrameworkCore;
using School_Management_System_Practicum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School_Management_System_Practicum.Models
{
    public class OurDbContext: DbContext
{
        public OurDbContext(DbContextOptions<OurDbContext> options) : base(options)
        {

        }
        public DbSet<Registration> registration { get; set; }
        public DbSet<User> user { get; set; }
        public DbSet<Addinfo> Addinfo { get; set; }
        public DbSet<Notice> Notice { get; set; }
        public DbSet<Form> form { get; set; }
        public DbSet<Image> image { get; set; }
        public DbSet<Attendence> attendence { get; set; }
      
        public DbSet<Result> Result{ get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<Time> Time { get; set; }
        public DbSet<Selectcourse> Selectcourse { get; set; }
        public DbSet<Fpayment> Fpayment { get; set; }
        public DbSet<Sfees> Sfees { get; set; }
    }
}
