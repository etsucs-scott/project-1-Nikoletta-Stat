using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    // Subclass of Item
    public class Potion : Item
    {
        public int potionHealth { get; set; }

        public Potion() : base("Potion", "You have picked up a potion! +20 HP") // Required name and pickup message string arguments.
        {
            potionHealth = 20;
        }
    }
}
