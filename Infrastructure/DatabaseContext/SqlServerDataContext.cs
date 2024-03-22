using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.DatabaseContext;

public class SqlServerDataContext(IConfiguration configuration) : DataContext
{
    private readonly IConfiguration _configuration = configuration;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("SqlServer"));
    }
}
