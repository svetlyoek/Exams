namespace ViceCity.Core
{
    using System;

    public static class Validator
    {
        public static void ValidateIntValueCanNotBeNegative(int value, string message)
        {
            if (value < 0)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ValidateStringValueCanNotBeNullOrEmpty(string value, string message)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(message);
            }
        }
    }
}
