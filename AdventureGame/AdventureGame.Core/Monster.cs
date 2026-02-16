using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    public class Monster : ICharacter
    {
        public int baseHealth = 50;
        public int Health { get; set; }

        public int BaseDamage { get; set; } 

        public Monster()
        {
            Health = baseHealth;
            BaseDamage = 10;
        }

        public void Attack (ICharacter target)
        {
            target.TakeDamage();
        }

        public void TakeDamage()
        {
            Health -= BaseDamage;
        }


    }
}
