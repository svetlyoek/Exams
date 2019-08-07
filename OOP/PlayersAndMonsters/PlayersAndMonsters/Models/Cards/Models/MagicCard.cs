namespace PlayersAndMonsters.Models.Cards.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class MagicCard : Card
    {
        private const int DamagePoints = 5;
        private const int HealthPoints = 80;

        public MagicCard(string name)
            : base(name, DamagePoints, HealthPoints)
        {
        }
    }
}
