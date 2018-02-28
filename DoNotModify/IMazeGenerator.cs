
namespace Maze
{
    /// <summary>
    /// Interface for factory classes for mazes.
    /// </summary>
    interface IMazeGenerator
    {
        /// <summary>
        /// Initializes the factory class with a function to generate random numbers.
        /// </summary>
        void Initialize(RandomNumberGenerator randomNumberGenerator);

        /// <summary>
        /// Generates a new maze of the given width and height.
        /// </summary>
        Maze Generate(int width, int height);
    }
}
