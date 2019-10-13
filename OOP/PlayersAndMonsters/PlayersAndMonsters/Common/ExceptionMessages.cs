using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Common
{
    public static class ExceptionMessages
    {
        public const string CardHealthCanNotBeLessThanZero = "Card's HP cannot be less than zero.";

        public const string CardDamagePointsCanNotBeNegative = "Card's damage points cannot be less than zero.";

        public const string CardNameCanNotBeNullOrEmpty = "Card's name cannot be null or an empty string.";

        public const string PlayerNameCanNotBeNullOrEmpty = "Player's username cannot be null or an empty string.";

        public const string PlayerHealthCanNotBeNegative = "Player's health bonus cannot be less than zero.";

        public const string PlayerDamagePointsCanNotBeNegative = "Damage points cannot be less than zero.";

        public const string PlayerCanNotBeNull = "Player is dead!";

        public const string CardCanNotBeNull = "Card cannot be null";

        public const string CardAlreadyExists = "Card {0} already exists!";

        public const string PlayerCannotBeNull = "Player cannot be null";

        public const string PlayerAlreadyExist = "Player {0} already exists!";
    }
}
