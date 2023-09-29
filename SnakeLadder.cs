using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayWithTwoPlayer_UC7
{
    internal class SnakeLadder
    {
        readonly Random random = new Random();
        public int PlayGame(int playerPosition, int turn)
        {
            int checkwin;
            int position;
            while(playerPosition != WIN_POSITION)
            {
                checkwin=CheckWin(playerPosition);
                if(checkwin ==1 && turn == 1)
                {
                    Console.WriteLine($"player One wins!!");
                    break;
                }
                if(checkwin ==1 && turn == 0)
                {
                    Console.WriteLine($"player Two wins!!");
                    break;
                }
                if(checkwin==2)
                {
                    position = 0;
                }
                else
                {
                    position = RollDie();
                }

                if(position == 0)
                {
                    Console.WriteLine("its a no play");
                    playerPosition += position;
                }

                if(playerPosition==0 && position < 0)
                {
                    Console.WriteLine("its a snake bit @0");
                    playerPosition = 0;
                }
                if(playerPosition>0 && position< 0)
                {
                    Console.WriteLine("its a snake bite");
                    playerPosition += position;
                    if(playerPosition<0)
                    {
                        playerPosition = 0;
                    }
                }
                if (position > 0)
                {
                    Console.WriteLine("its a ladder");
                    playerPosition += position;
                }
                if (playerPosition > WIN_POSITION)
                {
                    playerPosition -= position;
                }
                if(turn == 1)
                {
                    Console.WriteLine($"Player One rolls die and gets position {playerPosition}");
                    break;
                }
                if(turn == 0)
                {
                    Console.WriteLine($"Player Two rolls die and get position {playerPosition}");
                    break;
                }
            }
            return playerPosition;
        }

        const int WIN_POSITION = 100;
        const int START_POSITION = 0;

        public void Start()
        {
            //implementing single player start at 0
            //variables
            int player; //record new position o both player
            int playerOne = START_POSITION, playerTwo = START_POSITION;
            Console.WriteLine($"player One position is {playerOne}");
            Console.WriteLine($"player Two position is {playerTwo}");

            //now to make turn or player one and player two creating an ininite loop
            int turn = 1;
            while (true)
            {
                if (turn == 1)
                {
                    Console.WriteLine("Player one turn");
                    player = PlayGame(playerOne, turn);
                    turn = 0;

                    if (player > playerOne)
                    {
                        turn = 1;
                    }
                    playerOne = player;
                }

                if (playerOne == WIN_POSITION)
                {
                    Console.WriteLine("==========PLAYER ONE WINS===============");
                    break;
                }
                if (turn == 0)
                {
                    //playerTwo Turn
                    Console.WriteLine("PLAYE TWO TURN");
                    player = PlayGame(playerTwo, turn); //passing player Two's position and recording back new position
                    turn = 1; //switch back to player one

                    if (player > playerTwo)
                    {
                        turn = 0;
                    }
                    playerTwo = player; //recording player Two's position
                }

                if (playerTwo == WIN_POSITION)
                {
                    Console.WriteLine("=========PLAYER TWO WINS==========");
                    break;
                }

            }
        }
        public int CheckWin(int playerOne)
        {
            if (playerOne == 100)
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

        int diceThrown = 0;
        public int RollDie()
        {
            int dice;
            int check;
            dice = random.Next(1, 7);
            diceThrown++;
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
            Console.WriteLine($"Number o Times Dice Thrown: {diceThrown}");
        }
    }
}
