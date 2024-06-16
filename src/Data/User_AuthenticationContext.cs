using Microsoft.EntityFrameworkCore;
using User_Authentication.Models;

namespace User_Authentication.Data
{
    public class User_AuthenticationContext : DbContext
    {
        public User_AuthenticationContext(DbContextOptions<User_AuthenticationContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}