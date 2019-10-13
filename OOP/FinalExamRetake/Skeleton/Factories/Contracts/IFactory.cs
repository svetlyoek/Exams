namespace SpaceStation.Factories.Contracts
{
    using SpaceStation.Models.Astronauts.Contracts;

    public interface IFactory
    {
        IAstronaut CreateAstronaut(string type, string name);
    }
}
