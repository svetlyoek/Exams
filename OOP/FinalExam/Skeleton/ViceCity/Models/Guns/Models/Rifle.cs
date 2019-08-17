namespace ViceCity.Models.Guns.Models
{

    public class Rifle : Gun
    {
        private const int InitialBulletsPerBarrel = 50;
        private const int InitialTotalBullets = 500;
        private const int BulletsToShoot = 5;

        public Rifle(string name)
            : base(name, InitialBulletsPerBarrel, InitialTotalBullets)
        {
        }

        public override int Fire()
        {
            int rifleFiredBullets = 0;

            if (this.BulletsPerBarrel == 0)
            {
                this.BulletsPerBarrel += InitialBulletsPerBarrel;
                this.TotalBullets -= InitialBulletsPerBarrel;
            }

            this.BulletsPerBarrel -= BulletsToShoot;

            rifleFiredBullets += BulletsToShoot;

            return rifleFiredBullets;
        }
    }
}
