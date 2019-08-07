namespace MXGP
{
    using MXGP.Core.Contracts;
    using MXGP.Core.Models;
    using MXGP.IO;
    using MXGP.IO.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IChampionshipController controller = new ChampionshipController();
            IWriter writer = new ConsoleWriter();
            IReader reader = new ConsoleReader();

            var engine = new Engine(controller, reader, writer);
            engine.Run();

        }
    }
}
