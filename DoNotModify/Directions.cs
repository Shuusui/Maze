
namespace Maze
{
    /// <summary>
    /// Enumeration of directions used to make computations easier (<see cref="Directions"/>)
    /// </summary>
    enum Direction
    {
        LEFT = 0,
        UP = 1,
        RIGHT = 2,
        DOWN = 3
    }

    /// <summary>
    /// Static class with methods and extension method for <see cref="Direction"/>.
    /// </summary>
    static class Directions
    {
        /// <summary>
        /// Uses a <see cref="RandomNumberGenerator"/> to randomly choose a direction.
        /// </summary>
        public static Direction Random(RandomNumberGenerator randomNumberGenerator)
        {
            return (Direction)randomNumberGenerator(0, 4);
        }

        /// <summary>
        /// Rotates a direction 90° to left.
        /// </summary>
        public static Direction ToLeft(this Direction dir)
        {
            return (Direction)((((int)dir) + 3) & 3);
        }

        /// <summary>
        /// Rotates a direction 90° to right.
        /// </summary>
        public static Direction ToRight(this Direction dir)
        {
            return (Direction)((((int)dir) + 1) & 3);
        }

        /// <summary>
        /// Computes the movement in x when doing one step in the direction.
        /// LEFT -> -1, UP -> 0, RIGHT -> 1, DOWN -> 0
        /// </summary>
        public static int DeltaX(this Direction dir)
        {
            int d = (int)dir;
            return ((d & 1) - 1) & ((d & 2) - 1);
        }

        /// <summary>
        /// Computes the movement in y when doing one step in the direction.
        /// LEFT -> 0, UP -> -1, RIGHT -> 0, DOWN -> 1
        /// </summary>
        public static int DeltaY(this Direction dir)
        {
            int d = (int)dir;
            return (-(d & 1)) & ((d & 2) - 1);
        }
    }
}
