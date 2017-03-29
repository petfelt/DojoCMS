using Microsoft.EntityFrameworkCore;
using DojoCMS.Models;

public class CmsContext : DbContext
{
    // Other code

    public CmsContext(DbContextOptions<CmsContext> options) : base(options) { }   
    // This DbSet contains "Person" objects and is called "Users"
    
    public DbSet<User> Users { get; set; }
   
}