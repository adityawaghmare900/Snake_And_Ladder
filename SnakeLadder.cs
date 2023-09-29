using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player_rolls_UC2
{
    internal class SnakeLadder
    {
        public void Start()
        {
            int position = 0;
            int playerOne;

            playerOne = position;
            Console.WriteLine($"player One position is {playerOne}");
            playerOne = RollDie();
            Console.WriteLine($"player One roller die and get position {playerOne}");
        }

        public int RollDie()
        {
            Random random = new Random();
            int dice = random.Next(1, 7);
            return dice;
        }

        public void Board()
        {
            Start();
        }
    }
}
