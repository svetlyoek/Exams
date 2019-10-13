namespace ViceCity.Models.Players.Models
{
    using ViceCity.Core;
    using ViceCity.Messages;
    using ViceCity.Models.Guns.Contracts;
    using ViceCity.Models.Players.Contracts;
    using ViceCity.Repositories;
    using ViceCity.Repositories.Contracts;

    public abstract class Player : IPlayer
    {
        private string name;
        private int lifePoints;

        protected Player(string name, int lifePoints)
        {
            this.Name = name;
            this.LifePoints = lifePoints;
            this.GunRepository = new GunRepository();

        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                Validator.ValidateStringValueCanNotBeNullOrEmpty(value, ExceptionMessages.PlayerNameCanNotBeNullOrWhitespace);

                this.name = value;
            }
        }

        public bool IsAlive
            => this.LifePoints > 0;


        public IRepository<IGun> GunRepository { get; private set; }


        public int LifePoints
        {
            get
            {
                return this.lifePoints;
            }
            private set
            {
                Validator.ValidateIntValueCanNotBeNegative(value, ExceptionMessages.PlayerLifePointsCanNotBeNegative);

                this.lifePoints = value;
            }
        }

        public void TakeLifePoints(int points)
        {
            if (this.LifePoints - points <= 0)
            {
                this.LifePoints = 0;
            }

            else
            {
                this.LifePoints -= points;
            }

        }
    }
}
