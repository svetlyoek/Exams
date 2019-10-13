namespace PlayersAndMonsters.Models.Players
{
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Core;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;
    using PlayersAndMonsters.Repositories.Models;

    public abstract class Player : IPlayer
    {
        private string username;
        private int health;

        protected Player(ICardRepository cardRepository, string username, int health)
        {
            this.CardRepository = new CardRepository();
            this.Username = username;
            this.Health = health;

        }
        public ICardRepository CardRepository { get; }


        public string Username
        {
            get
            {
                return this.username;
            }
            private set
            {
                Validator.ValidateStringValueCannotBeNullOrEmpty(
                    value, ExceptionMessages
                    .PlayerNameCanNotBeNullOrEmpty);

                this.username = value;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }

            set
            {
                Validator.ValidateIntValueCannotBeNegative(
                    value, ExceptionMessages
                    .PlayerHealthCanNotBeNegative);

                this.health = value;
            }
        }

        public bool IsDead
            => this.Health <= 0;

        public void TakeDamage(int damagePoints)
        {
            Validator.ValidateIntValueCannotBeNegative(
                damagePoints, ExceptionMessages
                .PlayerDamagePointsCanNotBeNegative);

            if (this.Health - damagePoints >= 0)
            {
                this.Health -= damagePoints;
            }

            else
            {
                this.Health = 0;
            }

        }
    }
}
