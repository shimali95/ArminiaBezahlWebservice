using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ArminiaBezahlWebservice.Models;

namespace ArminiaBezahlWebservice.Data
{
    public class ArminiaBezahlWebserviceContext : DbContext
    {
        public ArminiaBezahlWebserviceContext (DbContextOptions<ArminiaBezahlWebserviceContext> options)
            : base(options)
        {
        }

        public DbSet<Account> Account { get; set; }
        public DbSet<Getraenk_Account> Getraenk_Account { get; set; }
        public DbSet<Getraenk> Getraenk { get; set; }
    }
}
