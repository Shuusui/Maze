using System.Collections.Generic;

namespace Maze
{
    /// <summary>
    /// Generates a simple maze, where the left half consists of horicontal walls
    /// and the right half consists of vertical walls. Each wall has one random gap,
    /// so that all fields are somehow connected.
    /// </summary>
    class DummyMazeGenerator : IMazeGenerator
    {
        private RandomNumberGenerator randomNumberGenerator;

        public void Initialize(RandomNumberGenerator randomNumberGenerator)
        {
            this.randomNumberGenerator = randomNumberGenerator;
        }

        public Maze Generate(int width, int height)
        {
            IList<Wall> walls = new List<Wall>();
            int half = width / 2;
            for (int y = 0; y < height - 1; ++y)
            {
                int gap = randomNumberGenerator(0, half);
                for (int x = 0; x < half; ++x)
                {
                    if (x != gap)
                    {
                        walls.Add(new Wall(x, y, Direction.DOWN));
                    }
                }
            }
            for (int x = half; x < width; ++x)
            {
                int gap = randomNumberGenerator(0, height);
                for (int y = 0; y < height; ++y)
                {
                    if (y != gap)
                    {
                        walls.Add(new Wall(x, y, Direction.LEFT));
                    }
                }
            }
            return new Maze(width, height, walls);
        }
    }
}
