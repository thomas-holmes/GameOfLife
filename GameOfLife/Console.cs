using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Console
    {
        [STAThread]
        static void Main(string[] args)
        {
            System.Console.WriteLine("Starting the game of life...");
            var game = new GameOfLife(20, 20, null);
            game.DrawBoard();
            System.Console.ReadLine();
            
            Observable.Interval(TimeSpan.FromMilliseconds(200)).Subscribe(l => { game.AdvanceGeneration(); game.DrawBoard(); });

            System.Console.ReadLine();
        }
    }
}
