using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    public class MazeTile
    {
        public bool isWall {  get; set; }
        public bool isExit { get; set; }
        public Item? item { get; set; }
        public Monster? monster { get; set; }
        public bool isEmpty => isWall == false && isExit == false && item == null && monster == null;

    }
}
