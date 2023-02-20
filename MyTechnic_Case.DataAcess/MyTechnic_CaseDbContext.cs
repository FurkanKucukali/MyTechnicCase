using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyTechnic_Case.Core.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace MyTechnic_Case.DataAcess
{
    public class MyTechnic_CaseDbContext : IdentityDbContext<User>
    {
        public MyTechnic_CaseDbContext()
        {
        }
        public DbSet<User> Employees { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<ShiftTeam> ShiftTeams { get; set; }



        public MyTechnic_CaseDbContext(DbContextOptions<MyTechnic_CaseDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }

}

