using System;
using System.Collections.Generic;
using System.Linq;
using Commander.Models;

namespace Commander.Data
{
  public class SqlCommanderRepo : ICommanderRepo
  {
    private readonly CommanderContext _context;

    public SqlCommanderRepo(CommanderContext context)
    {
        _context = context;
    }
    public IEnumerable<Command> GetAllCommands()
    {
      return _context.Commands.ToList();
    }

    public Command GetCommandById(int id)
    {
      return _context.Commands.FirstOrDefault(p=>p.Id == id);
    }

    void ICommanderRepo.CreateCommand(Command cmd)
    {
      if(cmd == null){
        throw new ArgumentNullException(nameof(cmd));
      }
      _context.Commands.Add(cmd);
    }

    void ICommanderRepo.DeleteCommand(Command cmd)
    {
     if(cmd == null){
        throw new ArgumentNullException(nameof(cmd));
      }
      _context.Commands.Remove(cmd);
    }

    bool ICommanderRepo.SaveChanges()
    {
      return (_context.SaveChanges() >= 0);
    }

    void ICommanderRepo.UpdateCommand(Command cmd)
    {
     if(cmd == null){
        throw new ArgumentNullException(nameof(cmd));
      }
      _context.Commands.Update(cmd);
    }
  }
}