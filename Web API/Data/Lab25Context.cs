using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab25.Model;

namespace Lab25.Data
{
    public class Lab25Context : DbContext
    {
        public Lab25Context (DbContextOptions<Lab25Context> options)
            : base(options)
        {
        }

        public DbSet<Lab25.Model.Product> Product { get; set; } = default!;
    }
}
