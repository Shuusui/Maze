using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Maze
{

    /// <summary>
    /// Factory for implementations of <see cref="IMouse"/>.
    /// </summary>
    delegate IMouse MouseGenerator();

    /// <summary>
    /// Function used to generate random numbers in a given interval.
    /// </summary>
    /// <param name="inclusiveMin">Inclusive minimum value for random number</param>
    /// <param name="exclusiveMax">Exclusive maximum value for random number</param>
    delegate int RandomNumberGenerator(int inclusiveMin, int exclusiveMax);

    /// <summary>
    /// Manager class for the whole maze and its contents.
    /// </summary>
    class Game
    {
        private Maze maze;

        private List<GameViewAgent> mice = new List<GameViewAgent>();

        private Position targetField;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="width">width of the maze to create</param>
        /// <param name="height">height of the maze to create</param>
        /// <param name="mice">number of mice to create</param>
        /// <param name="randomNumberGenerator">function for generating random numbers</param>
        /// <param name="mazeGenerator">instance to generate the maze</param>
        /// <param name="mouseGenerator">factory for the mice</param>
        public Game(int width, int height, int mice, RandomNumberGenerator randomNumberGenerator, IMazeGenerator mazeGenerator, MouseGenerator mouseGenerator)
        {
            mazeGenerator.Initialize(randomNumberGenerator);
            maze = mazeGenerator.Generate(width, height);
            targetField = new Position(randomNumberGenerator(0, width), randomNumberGenerator(0, height));
            for (int i = 0; i < mice; ++i)
            {
                this.mice.Add(new GameViewAgent(randomNumberGenerator, mouseGenerator(), maze));
            }
        }

        /// <summary>
        /// Clears the console and draws the current state of the maze including all mice and the target position.
        /// </summary>
        private void RenderToConsole()
        {
            Console.Clear();
            var objects = new Dictionary<Position, String>();
            foreach (var mouse in mice)
            {
                objects[mouse.Field] = "o";
            }
            objects[targetField] = "x";
            Console.WriteLine(maze.ToString(objects));
        }

        /// <summary>
        /// Runs the mouse agents until all mice reach the target.
        /// </summary>
        public void Run()
        {
            RenderToConsole();
            while (mice.Any(mouse => mouse.Field != targetField))
            {
                Thread.Sleep(250);
                foreach (var mouse in mice)
                {
                    mouse.Step();
                    if (mouse.Field == targetField)
                    {
                        mouse.TargetIsReached();
                    }
                }
                RenderToConsole();
            }
        }
    }
}
