using System;

namespace MXGP
{
    using Models.Motorcycles;
    using MXGP.Core.Contracts;
    using MXGP.Core.Models;
    using MXGP.IO;
    using MXGP.Models.Motorcycles.Models;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var engine = new Engine();
            engine.Run();

        }
    }
}
