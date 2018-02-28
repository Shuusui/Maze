using System;

namespace Maze
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            var game = new Game(20, 16, 3, (min, max) => random.Next(min, max), new DummyMazeGenerator(), () => new LeftHandMouse());
            game.Run();
        }
    }
}
