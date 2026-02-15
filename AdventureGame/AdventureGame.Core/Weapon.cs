using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    public class Weapon : Item
    {
        public int modifier {  get; set; }
        public string name { get; }
        public string pickupMessage { get; set; }
    }
}
