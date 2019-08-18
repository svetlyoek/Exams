namespace SpaceStation.Messages
{
    public static class ExceptionMessages
    {
        public const string AstronautNameCanNotBeNullOrEmpty = "Astronaut name cannot be null or empty.";

        public const string AstronautOxygenCanNotBeNegative = "Cannot create Astronaut with negative oxygen!";

        public const string PlanetNameCanNotBeNullOrWhiteSpace = "Invalid name!";

        public const string AstronautTypeDoNotExists = "Astronaut type doesn't exists!";

        public const string AstronautToExploreMustBeAtLeastOne = "You need at least one astronaut to explore the planet";

        public const string AstronautDoesNotExists = "Astronaut {0} doesn't exists!";

    }
}
