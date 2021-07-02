using System.Collections.Generic;
using fahlen_dev_webapi.Models;

namespace fahlen_dev_webapi.Data {
  public interface ICommanderRepo {
      bool SaveChanges();
      // IEnumerable<Command> GetAllCommands();
      // Command GetCommandById(int id);

      IEnumerable<Account> GetAllAccounts();
      Account GetAccountById(int id);
      void CreateAccount(Account acc);

      // void CreateCommand(Command cmd);
      // void UpdateCommand(Command cmd);
      // void DeleteCommand(Command cmd);
  }
}