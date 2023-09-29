using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepeatTillWin_UC4
{
    public class SnakeLadder
    {
        readonly Random random = new Random();

        public void Start()
        {
            int position = 0;
            int playerOne = 3;

            while (playerOne <= 100) //loop until playerOne reachess 100
            {
                position = RollDie();
                //No play condition
                if (position == 0)
                {
                    Console.WriteLine("its a no play");
                    playerOne += position; //player get no play then remain at same place
                }

                //snake condition
                if (playerOne == 0 && position < 0) //when player is at start
                {
                    Console.WriteLine("its a snake bite @0");
                    playerOne = 0; //it player gets snake bite player remian at same place
                }

                if (playerOne > 0 && position < 0)
                {
                    Console.WriteLine("its a snake bite");
                    playerOne += position; //if player is at position less than 6 and gets snake bite
                    if (playerOne < 0)
                    {
                        //i player position is below 0
                        playerOne = 0;
                    }
                }

                //ladder condition
                if (position > 0)
                {
                    Console.WriteLine("its a ladder");
                    playerOne += position;
                }
                Console.WriteLine($"player one roos die and get position {playerOne}");
            }
        }

        public int RollDie()
        {
            int dice;
            int check;
            dice = random.Next(1, 7);
            Console.WriteLine($"Dice={dice}");
            check = CheckPlay();
            //roll die to produce random number between 1-6

            if (check == 1)
            {
                return -dice; //snake bite
            }

            if (check == 2)
            {
                return dice; //ladder
            }
            else
            {
                return 0; //no play
            }
            return dice;
        }

        public int CheckPlay()
        {
            int check = random.Next(1, 4);
            return check;
        }

        public void Board()
        {
            Start();
        }
    }
}
