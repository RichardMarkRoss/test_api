using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using test_app.Model;

namespace test_app.Data
{
    public class test_appContext : DbContext
    {
        public test_appContext (DbContextOptions<test_appContext> options)
            : base(options)
        {
        }
        public DbSet<test_app.Model.Users>? Users { get; set; } = default!;
        public DbSet<test_app.Model.LottoTickets>? LottoTickets { get; set; }
        public DbSet<test_app.Model.WinningNumbers>? WinningNumbers { get; set; }
        public DbSet<test_app.Model.InfoNumbers>? InfoNumbers { get; set; }
    }
}
