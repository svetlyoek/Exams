using ViceCity.Core.Contracts;
using System;
using ViceCity.IO.Contracts;
using ViceCity.IO;

namespace ViceCity.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private Controller controller;

        public Engine()
        {
            this.reader = new Reader();
            this.writer = new Writer();
            this.controller = new Controller();
        }

        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine().Split();
                string message = string.Empty;

                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }

                string command = input[0];

                try
                {
                    message = CommandCheck(input, message, command);
                }

                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                }

                this.writer.WriteLine(message);
            }
        }

        private string CommandCheck(string[] input, string message, string command)
        {
            if (command == "AddPlayer")
            {
                string playerName = input[1];
                message = this.controller.AddPlayer(playerName);
            }

            else if (command == "AddGun")
            {
                string gunType = input[1];
                string gunName = input[2];

                message = this.controller.AddGun(gunType, gunName);
            }

            else if (command == "AddGunToPlayer")
            {
                string playerName = input[1];
                message = this.controller.AddGunToPlayer(playerName);
            }

            else if (command == "Fight")
            {
                message = this.controller.Fight();
            }

            return message;
        }
    }
}
