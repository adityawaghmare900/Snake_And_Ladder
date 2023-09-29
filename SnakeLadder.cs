using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerGetExactWinningPostion_UC5
{
    public class SnakeLadder
    {
        readonly Random random = new Random();

        public void Start()
        {
            int position = 0;
            int playerOne = 3;
            int checkwin;
            Console.WriteLine($"player One position is {playerOne}");

            while (playerOne < 101) //loop until playerOne reachess 100
            {
                //check for win condition
                checkwin = CheckWin(playerOne);
                if(checkwin==1 )  //player has reached exact 100th position
                {
                    Console.WriteLine($"playerOOne wins!!"); //display win message
                    break; //end the game
                }

               if(checkwin==2)
                {
                    position = 0;
                }

               else
                {
                    position = RollDie();
                }

             
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

        public int CheckWin(int playerOne)
        {
            if(playerOne == 100)
            {
                return 1;
            }
            if (playerOne > 100)
            {
                return 2;
            }
            else
                return 0;
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
