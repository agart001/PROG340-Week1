using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG340_Week1
{
    public class Player
    {
        public int Level { get; set; }
        public int Lives { get; set; }
        public Player() 
        {
            Level = 0;
            Lives = 3;
        }

        public void DecrementLives() => Lives--;

        public void IncrementLevel() => Level++;
    }
}
