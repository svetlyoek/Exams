namespace PlayersAndMonsters.Core
{
    using PlayersAndMonsters.Core.Contracts;
    using PlayersAndMonsters.IO.Contracts;
    using System;
    using System.Linq;

    public class Engine : IEngine
    {
        private readonly IManagerController controller;
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(IManagerController controller, IReader reader, IWriter writer)
        {
            this.controller = controller;
            this.reader = reader;
            this.writer = writer;
        }
        public void Run()
        {
            string message = string.Empty;

            while (true)
            {
                string line = this.reader.ReadLine();

                if (line == "Exit")
                {
                    break;
                }

                string[] lines = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                try
                {
                    if (lines[0] == "AddPlayer")
                    {
                        string playerType = lines[1];
                        string playerName = lines[2];

                        message = this.controller.AddPlayer(playerType, playerName);

                    }

                    if (lines[0] == "AddCard")
                    {
                        string cardType = lines[1];
                        string cardName = lines[2];

                        message = this.controller.AddCard(cardType, cardName);

                    }
                    if (lines[0] == "AddPlayerCard")
                    {
                        string playerName = lines[1];
                        string cardName = lines[2];

                        message = this.controller.AddPlayerCard(playerName, cardName);

                    }

                    if (lines[0] == "Fight")
                    {
                        string attackName = lines[1];
                        string enemyName = lines[2];

                        message = this.controller.Fight(attackName, enemyName);

                    }

                    if (lines[0] == "Report")
                    {
                        message = this.controller.Report();


                    }

                }
                catch (ArgumentException ex)
                {

                    message = ex.Message;
                }

                this.writer.WriteLine(message);
            }

        }
    }
}
