namespace ViceCity.Core.Contracts
{
    using ViceCity.Models.Guns.Contracts;

    public interface IGunFactory
    {
        IGun CreateGun(string type, string name);
    }
}
