using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab23.Models;

namespace Lab23.Data
{
    public class Lab23Context : DbContext
    {
        public Lab23Context (DbContextOptions<Lab23Context> options)
            : base(options)
        {
        }

        public DbSet<Lab23.Models.Student> Student { get; set; } = default!;
    }
}
