using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Services {
    public class APIContext : DbContext {
        public APIContext(DbContextOptions<APIContext> opt): base(opt){}

        public DbSet<Book> Book { get; set; }
    }
}