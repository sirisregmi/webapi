using Microsoft.EntityFrameworkCore;
using Oho.Services.Identity.Domain.Models;

using System.Collections.Generic;


namespace Oho.Services.Identity
{
    public class IdentityContext : DbContext
    {

       // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       //

       public IdentityContext(DbContextOptions<IdentityContext> options)
      :base(options)
    { }
       
  

        public DbSet<User> Users { get; set; } 
    }
}