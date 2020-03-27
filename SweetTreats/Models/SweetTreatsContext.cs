using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SweetTreats.Models
{
  public class SweetTreatsContext : IdentityDbContext<ApplicationUser>
  {
    public virtual DbSet<Treats> Treats { get; set; }
    public DbSet<Flavors> Flavors { get; set; }
    public DbSet<TreatsFlavors> TreatsFlavors { get; set; }

    public SweetTreatsContext(DbContextOptions options) : base(options) { }
  }
}