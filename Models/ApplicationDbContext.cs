using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestApi.ViewModel;

namespace RestApi.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<DirectoryOne> DirectoryOnes { get; set; }
        public DbSet<AutoMapperUser> AutoMapperUsers { get; set; }
    }
}
