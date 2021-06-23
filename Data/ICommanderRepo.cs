using System.Collections.Generic;
using fahlen_dev_webapi.Models;

namespace fahlen_dev_webapi.Data {
  public interface ICommanderRepo {
      IEnumerable<Command> GetAppCommands();
      Command GetCommandById(int id);
  }
}