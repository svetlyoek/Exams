namespace PlayersAndMonsters.Models.BattleFields.Models
{
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Models.Players.Models;
    using System;
    using System.Linq;
    public class BattleField : IBattleField
    {
        private const int DefaultDamagePointsForBeginner = 30;
        private const int DefaultHealthPointsForBeginner = 40;

        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException(ExceptionMessages.PlayerCanNotBeNull);
            }

            CheckBeginnerType(attackPlayer, enemyPlayer);

            attackPlayer.Health += attackPlayer.CardRepository.Cards.Sum(x => x.HealthPoints);
            enemyPlayer.Health += enemyPlayer.CardRepository.Cards.Sum(x => x.HealthPoints);

            int attackerDamagePoints = attackPlayer.CardRepository.Cards.Sum(x => x.DamagePoints);
            int enemyDamagePoints = enemyPlayer.CardRepository.Cards.Sum(x => x.DamagePoints);

            while (true)
            {
                enemyPlayer.TakeDamage(attackerDamagePoints);

                if (enemyPlayer.Health == 0)
                {
                    break;
                }

                attackPlayer.TakeDamage(enemyDamagePoints);

                if (attackPlayer.Health == 0)
                {
                    break;
                }

            }

        }

        private static void CheckBeginnerType(IPlayer attackPlayer, IPlayer enemyPlayer)
        {

            if (enemyPlayer.GetType() == typeof(Beginner))
            {
                enemyPlayer.Health += DefaultHealthPointsForBeginner;

                foreach (var card in enemyPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += DefaultDamagePointsForBeginner;
                }
            }

            if (attackPlayer.GetType() == typeof(Beginner))
            {
                attackPlayer.Health += DefaultHealthPointsForBeginner;

                foreach (var card in attackPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += DefaultDamagePointsForBeginner;
                }
            }
        }
    }
}
