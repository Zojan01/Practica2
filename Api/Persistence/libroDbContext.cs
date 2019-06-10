using Microsoft.EntityFrameworkCore;
using System;
using Model;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public class libroDbContext : DbContext
    {
       
        public DbSet<Libro> Libro { get; set; }


        public libroDbContext(DbContextOptions<libroDbContext> options) : base(options) { }
        

    }
}
