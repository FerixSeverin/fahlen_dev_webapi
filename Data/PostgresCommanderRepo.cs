using System.Collections.Generic;
using System.Linq;
using fahlen_dev_webapi.Models;

namespace fahlen_dev_webapi.Data
{
  public class PostgresCommanderRepo : ICommanderRepo
  {
    private readonly CommanderContext _context;

    public PostgresCommanderRepo(CommanderContext context)
    {
        _context = context;
    }
    public IEnumerable<Command> GetAllCommands()
    {
        return _context.Commands.ToList();
    }

    public Command GetCommandById(int id)
    {
      return _context.Commands.FirstOrDefault(p => p.Id == id);
    }
  }
}