using System;
using System.Collections.Generic;
using System.Linq;
using fahlen_dev_webapi.Models;

namespace fahlen_dev_webapi.Data
{
  public class PostgresCommanderRepo : ICommanderRepo
  {
    private readonly FoodContext _context;

    public PostgresCommanderRepo(FoodContext context)
    {
        _context = context;
    }

    public void CreateAccount(Account acc)
    {
      throw new NotImplementedException();
    }

    public void CreateCommand(Command cmd)
    {
      throw new NotImplementedException();
    }

    public void DeleteCommand(Command cmd)
    {
      throw new NotImplementedException();
    }

    public Account GetAccountById(int id)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Account> GetAllAccounts()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Command> GetAllCommands()
    {
      throw new NotImplementedException();
    }

    public Command GetCommandById(int id)
    {
      throw new NotImplementedException();
    }

    // public void CreateCommand(Command cmd)
    // {
    //   if(cmd == null) {
    //       throw new ArgumentNullException(nameof(cmd));
    //   }

    //   _context.Commands.Add(cmd);
    // }

    // public void DeleteCommand(Command cmd)
    // {
    //   if(cmd == null) {
    //       throw new ArgumentNullException(nameof(cmd));
    //   }
    //   _context.Commands.Remove(cmd);

    // }

    // public IEnumerable<Command> GetAllCommands()
    // {
    //     return _context.Commands.ToList();
    // }

    // public Command GetCommandById(int id)
    // {
    //   return _context.Commands.FirstOrDefault(p => p.Id == id);
    // }

    public bool SaveChanges()
    {
      return (_context.SaveChanges() >= 0);
    }

    public void UpdateCommand(Command cmd)
    {
      //Nothing
    }
  }
}