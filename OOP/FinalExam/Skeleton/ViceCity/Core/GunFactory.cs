namespace ViceCity.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using ViceCity.Core.Contracts;
    using ViceCity.Messages;
    using ViceCity.Models.Guns.Contracts;

    public class GunFactory : IGunFactory
    {
        public IGun CreateGun(string type, string name)
        {
            var gunType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(g => g.Name == type && !g.IsAbstract)
                .FirstOrDefault();

            if (gunType == null)
            {
                throw new ArgumentException(OutputMessages.InvalidGunType);

            }

            IGun gun = (IGun)Activator.CreateInstance(gunType, name);

            return gun;
        }
    }
}
