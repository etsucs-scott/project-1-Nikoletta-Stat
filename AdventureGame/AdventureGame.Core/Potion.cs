using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    public class Potion : Item
    {
        public int potionHealth { get; set; }

        public Potion() : base("Potion", "You have picked up a potion! +20 HP")
        {
            potionHealth = 20;
        }
    }
}
