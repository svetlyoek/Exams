﻿namespace MXGP.Core.Models
{
    using MXGP.Core.Contracts;
    using MXGP.IO;
    using MXGP.IO.Contracts;
    using System;

    public class Engine : IEngine
    {
        private readonly IChampionshipController championshipController;
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(IChampionshipController championshipController,IReader reader,IWriter writer)
        {
            this.championshipController = new ChampionshipController();
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();
        }

        public void Run()
        {
            string line = reader.ReadLine();

            while (line != "End")
            {
                string[] commandItems = line.Split();
                string result = string.Empty;

                try
                {
                    switch (commandItems[0])
                    {
                        case "CreateRider":
                            result += this.championshipController.CreateRider(commandItems[1]);
                            break;

                        case "CreateMotorcycle":
                            result += this.championshipController.CreateMotorcycle(commandItems[1],
                                commandItems[2],
                                int.Parse(commandItems[3]));
                            break;

                        case "AddMotorcycleToRider":
                            result += this.championshipController.AddMotorcycleToRider(commandItems[1],
                                commandItems[2]);
                            break;

                        case "AddRiderToRace":
                            result += this.championshipController.AddRiderToRace(commandItems[1],
                                commandItems[2]);
                            break;

                        case "CreateRace":
                            result += this.championshipController.CreateRace(commandItems[1],
                                int.Parse(commandItems[2]));
                            break;

                        case "StartRace":
                            result += this.championshipController.StartRace(commandItems[1]);
                            break;

                        default:
                            break;
                    }

                    writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                line = Console.ReadLine();
            }
        }
    }
}
