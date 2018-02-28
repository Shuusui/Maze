
namespace Maze
{
    /// <summary>
    /// Interface for mouse agents. They have only a limited view on the maze, which is 
    /// relative to its position.
    /// </summary>
    interface IMouse
    {
        /// <summary>
        /// Initializing method.
        /// </summary>
        /// <param name="game">View on the maze for this mouse. The mouse agent should nomrally register to the MouseStep event.</param>
        /// <param name="randomNumberGenerator">Function to generate random numbers</param>
        void Initialize(IGameView game, RandomNumberGenerator randomNumberGenerator);
    }
}
