using MortalEngines.Core;
using MortalEngines.Core.Contracts;
using MortalEngines.Core.Models;
using MortalEngines.IO.Contracts;
using MortalEngines.IO.Models;

namespace MortalEngines
{
    public class StartUp
    {
        public static void Main()
        {
            IMachinesManager machinesManager = new MachinesManager();

            ICommandInterpreter commandInterpreter = new CommandInterpreter(machinesManager);
            IWriter writer = new ConsoleWriter();

            IEngine engine = new Engine(commandInterpreter, writer);
            engine.Run();
        }
    }
}