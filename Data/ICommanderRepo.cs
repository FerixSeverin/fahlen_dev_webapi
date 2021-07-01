using System.Collections.Generic;
using fahlen_dev_webapi.Models;

namespace fahlen_dev_webapi.Data {
  public interface ICommanderRepo {
      IEnumerable<Command> GetAllCommands();
      Command GetCommandById(int id);
  }
}