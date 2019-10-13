namespace ViceCity.Models.Guns.Models
{
    using ViceCity.Models.Guns.Contracts;

    public class Pistol : Gun, IGun
    {
        private const int InitialBulletsPerBarrel = 10;
        private const int InitialTotalBullets = 100;
        private const int BulletsToShoot = 1;

        public Pistol(string name)
            : base(name, InitialBulletsPerBarrel, InitialTotalBullets)
        {
        }

        public override int Fire()
        {
            int pistolFiredBullets = 0;

            if (this.BulletsPerBarrel == 0)
            {
                this.BulletsPerBarrel += InitialBulletsPerBarrel;
                this.TotalBullets -= InitialBulletsPerBarrel;
            }

            this.BulletsPerBarrel -= BulletsToShoot;

            pistolFiredBullets++;

            return pistolFiredBullets;
        }
    }
}
