using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    // Subclass of Item
    public class Weapon : Item
    {
        public int modifier { get; set; }

        public Weapon(int modifier) : base("Weapon", "You have picked up a weapon! +" + modifier + " damage.") // Required arguements for Item classes.
        {
            this.modifier = modifier;
        }
    }
}
