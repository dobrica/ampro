using MessagesService.Model;
using Microsoft.EntityFrameworkCore;

namespace MessagesService.DAL;

public class DataContext : DbContext
{
    public DbSet<Message> Messages { get; set; }
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    { }
}