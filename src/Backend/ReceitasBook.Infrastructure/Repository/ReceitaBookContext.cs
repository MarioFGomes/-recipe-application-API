using Microsoft.EntityFrameworkCore;
using ReceitasBook.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReceitasBook.Infrastructure.Repository;

public class ReceitaBookContext:DbContext
{
    public ReceitaBookContext(DbContextOptions<ReceitaBookContext> options):base(options){}
     
    public DbSet<Usuario> Usuarios { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ReceitaBookContext).Assembly);
    }
}
