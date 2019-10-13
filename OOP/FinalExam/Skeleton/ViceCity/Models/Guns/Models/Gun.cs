namespace ViceCity.Models.Guns.Models
{
    using ViceCity.Core;
    using ViceCity.Messages;
    using ViceCity.Models.Guns.Contracts;

    public abstract class Gun : IGun
    {
        private string name;
        private int bulletsPerBarrel;
        private int totalBullets;


        protected Gun(string name, int bulletsPerBarrel, int totalBullets)
        {
            this.Name = name;
            this.BulletsPerBarrel = bulletsPerBarrel;
            this.TotalBullets = totalBullets;

        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                Validator.ValidateStringValueCanNotBeNullOrEmpty(value, ExceptionMessages.GunNameCanNotBeNullOrEmpty);

                this.name = value;
            }
        }

        public int BulletsPerBarrel
        {
            get
            {
                return this.bulletsPerBarrel;
            }
            protected set
            {
                Validator.ValidateIntValueCanNotBeNegative(value, ExceptionMessages.GunBulletsPerBarrelCanNotBeNegative);

                this.bulletsPerBarrel = value;
            }
        }

        public int TotalBullets
        {
            get
            {
                return this.totalBullets;
            }
            protected set
            {
                Validator.ValidateIntValueCanNotBeNegative(value, ExceptionMessages.GunTotalBulletsCanNotBeNegative);

                this.totalBullets = value;
            }
        }

        public bool CanFire
            => this.totalBullets > 0;

        public abstract int Fire();

    }
}
