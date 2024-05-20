using Microsoft.EntityFrameworkCore;

public class AppDbContext:DbContext{

    public AppDbContext(DbContextOptions<AppDbContex> options):base(options){

    }

    public DbSet<Student>? Student { get;}

}