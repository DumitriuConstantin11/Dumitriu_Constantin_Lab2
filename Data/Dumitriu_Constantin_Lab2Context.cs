using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dumitriu_Constantin_Lab2.Models;

namespace Dumitriu_Constantin_Lab2.Data
{
    public class Dumitriu_Constantin_Lab2Context : DbContext
    {
        public Dumitriu_Constantin_Lab2Context (DbContextOptions<Dumitriu_Constantin_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Dumitriu_Constantin_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Dumitriu_Constantin_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Dumitriu_Constantin_Lab2.Models.Author> Author { get; set; } = default!;
        public DbSet<Dumitriu_Constantin_Lab2.Models.Category> Category { get; set; } = default!;
        public DbSet<Dumitriu_Constantin_Lab2.Models.Member> Member { get; set; } = default!;
        public DbSet<Dumitriu_Constantin_Lab2.Models.Borrowing> Borrowing { get; set; } = default!;
    }
}
