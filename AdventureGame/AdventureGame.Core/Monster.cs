using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    // Monster implements ICharacter interface.
    public class Monster : ICharacter
    {
        public int baseHealth = 50;
        public int Health { get; set; }

        public int BaseDamage { get; set; } 

        public int damage { get; set; }

        public Monster()
        {
            Health = baseHealth;
            BaseDamage = 10;
            damage = BaseDamage;
        }

        // Attack() is called from the Game.Battle() method.
        public void Attack (ICharacter target)
        {
            target.TakeDamage(damage);
        }
        public void TakeDamage(int damage)
        {
            Health -= damage;
        }


    }
}
