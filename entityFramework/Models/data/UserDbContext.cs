using Microsoft.EntityFrameworkCore;

using entityFramework.Models;

namespace entityFramework.Data{

    public class UserDbContext : DbContext{
        public UserDbContext(DbContextOptions<UserDbContext> options):base(options){}
        public DbSet<User> User{get;set;}
    }

}