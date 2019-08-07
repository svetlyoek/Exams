namespace PlayersAndMonsters.Models.Cards.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class TrapCard : Card
    {
        private const int DamagePoints = 120;
        private const int HealthPoints = 5;

        public TrapCard(string name)
            : base(name, DamagePoints, HealthPoints)
        {
        }
    }
}
