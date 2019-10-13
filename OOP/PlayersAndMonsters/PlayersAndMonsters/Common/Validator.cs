namespace PlayersAndMonsters.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public static class Validator
    {
        public static void ValidateIntValueCannotBeNegative(int value, string message)
        {
            if (value < 0)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ValidateStringValueCannotBeNullOrEmpty(string value, string message)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(message);
            }
        }

    }
}
