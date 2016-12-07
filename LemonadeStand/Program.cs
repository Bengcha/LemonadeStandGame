using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 150;
            Game RunGame = new Game();
            RunGame.StartGame();

            Console.ReadKey();
        }
    }
}
