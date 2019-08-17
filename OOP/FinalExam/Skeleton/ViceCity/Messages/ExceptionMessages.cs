namespace ViceCity.Messages
{
    using System;
    using System.Collections.Generic;
    using System.Text;
   public static  class ExceptionMessages
    {
        public const string GunBulletsPerBarrelCanNotBeNegative = "Bullets cannot be below zero!";

        public const string GunNameCanNotBeNullOrEmpty = "Name cannot be null or a white space!";

        public const string GunTotalBulletsCanNotBeNegative = "Total bullets cannot be below zero!";

        public const string PlayerNameCanNotBeNullOrWhitespace = "Player's name cannot be null or a whitespace!";

        public const string PlayerLifePointsCanNotBeNegative = "Player life points cannot be below zero!";
    }
}
