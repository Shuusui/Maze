using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    class RecursiveMazeGenerator : IMazeGenerator
    {
        RandomNumberGenerator randomNumberGenerator;

        public Maze Generate(int width, int height)
        {
            IList<Wall> walls = RecursiveFunction(new Rectangle(0, width, 0, height));

            return new Maze(width, height, walls);
        }

        private List<Wall> RecursiveFunction(Rectangle rect)
        {
            List<Wall> walls = new List<Wall>();
            if (rect.WidthMax - rect.WidthNull > 1 && rect.HeightMax - rect.HeightNull > 1)
            {
                int randomDirection = randomNumberGenerator(0, 2);
                int randomGap;
                int randomPos;


                if (randomDirection == 0) // Vertical
                {
                    randomGap = randomNumberGenerator(rect.HeightNull, rect.HeightMax);
                    randomPos = randomNumberGenerator(rect.WidthNull+1, rect.WidthMax);
                    for (int y = rect.HeightNull; y < rect.HeightMax; y++)
                    {
                        if (y != randomGap)
                            walls.Add(new Wall(randomPos, y, Direction.LEFT));
                    }
                    walls.AddRange(RecursiveFunction(new Rectangle(rect.WidthNull, randomPos, rect.HeightNull, rect.HeightMax)));
                    walls.AddRange(RecursiveFunction(new Rectangle(randomPos, rect.WidthMax, rect.HeightNull, rect.HeightMax)));

                }
                else // Horizontal
                {
                    randomGap = randomNumberGenerator(rect.WidthNull, rect.WidthMax);
                    randomPos = randomNumberGenerator(rect.HeightNull+1, rect.HeightMax);
                    for (int x = rect.WidthNull; x < rect.WidthMax; x++)
                    {
                        if (x != randomGap)
                            walls.Add(new Wall(x, randomPos, Direction.UP));
                    }
                    walls.AddRange(RecursiveFunction(new Rectangle(rect.WidthNull, rect.WidthMax, rect.HeightNull, randomPos)));
                    walls.AddRange(RecursiveFunction(new Rectangle(rect.WidthNull, rect.WidthMax, randomPos, rect.HeightMax)));

                }
            }
            return walls;
        }

        public void Initialize(RandomNumberGenerator randomNumberGenerator)
        {
            this.randomNumberGenerator = randomNumberGenerator;
        }
    }
}
