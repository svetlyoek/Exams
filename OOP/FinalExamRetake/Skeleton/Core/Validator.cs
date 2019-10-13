using System;

namespace SpaceStation.Core
{
    public static class Validator
    {
        public static void ValidateStringValueNotNullOrWhiteSpace(string value, string message)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(message);
            }
        }

        public static void ValidateDoubleNotNegativeNumber(double value, string message)
        {
            if (value < 0)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
