namespace SpaceStation.Factories.Models
{
    using SpaceStation.Factories.Contracts;
    using SpaceStation.Messages;
    using SpaceStation.Models.Astronauts.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class AstronautFactory : IFactory
    {
        public IAstronaut CreateAstronaut(string type, string name)
        {
            var astronautType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(a => a.Name == type)
                .FirstOrDefault();

            if (astronautType == null)
            {
                throw new InvalidOperationException(ExceptionMessages.AstronautTypeDoNotExists);
            }

            IAstronaut astronaut = (IAstronaut)Activator.CreateInstance(astronautType, name);

            return astronaut;
        }
    }
}
