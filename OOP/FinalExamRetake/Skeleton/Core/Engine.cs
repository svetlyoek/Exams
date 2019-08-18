using SpaceStation.Core.Contracts;
using SpaceStation.IO;
using SpaceStation.IO.Contracts;
using System;
using System.Linq;

namespace SpaceStation.Core
{
    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
        private IController controller;

        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
            this.controller = new Controller();
        }
        public void Run()
        {
            while (true)
            {
                string message = string.Empty;

                var input = reader.ReadLine().Split();

                string command = input[0];

                if (command == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    if (command == "AddAstronaut")
                    {
                        string astroType = input[1];
                        string astroName = input[2];
                        message = this.controller.AddAstronaut(astroType, astroName);
                        writer.WriteLine(message);
                    }
                    else if (command == "AddPlanet")
                    {
                        string planetName = input[1];

                        string[] items = input.Skip(2).ToArray();

                        message = this.controller.AddPlanet(planetName, items);
                        writer.WriteLine(message);


                    }
                    else if (command == "RetireAstronaut")
                    {
                        string astroName = input[1];

                        message = this.controller.RetireAstronaut(astroName);
                        writer.WriteLine(message);
                    }
                    else if (command == "ExplorePlanet")
                    {
                        string planetName = input[1];

                        message = this.controller.ExplorePlanet(planetName);
                        writer.WriteLine(message);
                    }
                    else if (command == "Report")
                    {
                        message = this.controller.Report();
                        writer.WriteLine(message);
                    }
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }


            }
        }
    }
}
