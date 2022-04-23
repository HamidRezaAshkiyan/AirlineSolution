using AirlineAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AirlineAPI.Data;

public class AirlineContext : DbContext
{
    public AirlineContext(DbContextOptions<AirlineContext> opt) : base(opt)
    {
    }

    public DbSet<Person> People { get; set; }
}