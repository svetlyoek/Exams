using System.Collections.Generic;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players.Contracts;
using System.Linq;
using ViceCity.Models.Guns.Contracts;

namespace ViceCity.Models.Neghbourhoods
{
    public class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            while (true)
            {
                IGun mainPlayerGun = mainPlayer.GunRepository.Models.FirstOrDefault(g => g.CanFire == true);

                if (mainPlayerGun == null)
                {
                    break;
                }

                IPlayer civilPlayer = civilPlayers.FirstOrDefault(p => p.IsAlive == true);

                if (civilPlayer == null)
                {
                    break;
                }

                int pointsToTake = 0;

                pointsToTake = mainPlayerGun.Fire();

                civilPlayer.TakeLifePoints(pointsToTake);
            }

            while (true)
            {
                IPlayer civilPlayer = civilPlayers.FirstOrDefault(p => p.IsAlive == true);

                if (civilPlayer == null)
                {
                    break;
                }

                IGun civilPlayerGun = civilPlayer.GunRepository.Models.FirstOrDefault(g => g.CanFire == true);

                if (civilPlayerGun == null)
                {
                    break;
                }

                int pointsToTake = 0;

                pointsToTake = civilPlayerGun.Fire();

                mainPlayer.TakeLifePoints(pointsToTake);

                if (mainPlayer.IsAlive == false)
                {
                    break;
                }
            }

        }
    }
}
