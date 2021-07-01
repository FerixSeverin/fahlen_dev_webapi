using fahlen_dev_webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace fahlen_dev_webapi.Data
{
    public class CommanderContext : DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> opt) : base(opt) {
                
        }

        public DbSet<Command> Commands { get; set; }


    }
}