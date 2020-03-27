using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SweetTreats.Models
{
  public class SweetTreatsContextFactory : IDesignTimeDbContextFactory<SweetTreatsContext>
  {

    SweetTreatsContext IDesignTimeDbContextFactory<SweetTreatsContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<SweetTreatsContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");

      builder.UseMySql(connectionString);

      return new SweetTreatsContext(builder.Options);
    }
  }
}