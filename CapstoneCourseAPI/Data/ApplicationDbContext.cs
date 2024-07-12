using CapstoneCourseAPI.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CapstoneCourseAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
    }
}
