namespace Game_Start_UC1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------Snake and Ladder game-------");
            SnakeLadder game=new SnakeLadder();
            game.Board();
        }
    }
}