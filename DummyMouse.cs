using System.Linq;

namespace Maze
{
    /// <summary>
    /// Implements the <see cref="IMouse"/> interface by doing nothing.
    /// </summary>
    class DummyMouse : IMouse
    {
        public void Initialize(IGameView game, RandomNumberGenerator randomNumberGenerator)
        {
        }
    }
}
