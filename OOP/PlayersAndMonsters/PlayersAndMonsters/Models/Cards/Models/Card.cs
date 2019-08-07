namespace PlayersAndMonsters.Models.Cards.Models
{
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Core;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public abstract class Card : ICard
    {
        private string name;
        private int damagePoints;
        private int healthPoints;

        protected Card(string name, int damagePoints, int healthPoints)
        {
            this.Name = name;
            this.DamagePoints = damagePoints;
            this.HealthPoints = healthPoints;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                Validator.ValidateStringValueCannotBeNullOrEmpty(
                    value, ExceptionMessages
                    .CardNameCanNotBeNullOrEmpty);

                this.name = value;
            }
        }

        public int DamagePoints
        {
            get
            {
                return this.damagePoints;
            }
            set
            {
                Validator.ValidateIntValueCannotBeNegative(
                    value, ExceptionMessages
                    .CardDamagePointsCanNotBeNegative);

                this.damagePoints = value;
            }
        }

        public int HealthPoints
        {
            get
            {
                return this.healthPoints;
            }

            private set
            {

                Validator.ValidateIntValueCannotBeNegative
                    (value, ExceptionMessages
                    .CardHealthCanNotBeLessThanZero);

                this.healthPoints = value;
            }
        }
    }
}
