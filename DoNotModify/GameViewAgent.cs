using System;
using System.Collections.Generic;
using System.Linq;

namespace Maze
{
    /// <summary>
    /// Exception thrown, when a mouse hits a wall.
    /// </summary>
    class WallException : Exception
    {
    }

    /// <summary>
    /// CLass holding all necessary information of one mouse needed by the <see cref="Game"/> class.
    /// </summary>
    class GameViewAgent : IGameView
    {
        public Position Field { get; set; }

        public IMouse Agent { get; }

        public event Step MouseStep;

        public event Reach TargetReached;

        private Maze maze;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="randomNumberGenerator">function to generate random numbers</param>
        /// <param name="agent">agent controlling this mouse</param>
        /// <param name="maze">reference to the maze</param>
        public GameViewAgent(RandomNumberGenerator randomNumberGenerator, IMouse agent, Maze maze)
        {
            Field = new Position(randomNumberGenerator(0, maze.Width), randomNumberGenerator(0, maze.Height));
            Agent = agent;
            this.maze = maze;
            agent.Initialize(this, randomNumberGenerator);
        }

        /// <summary>
        /// Invokes the MouseStep event and if the result exists, use it to move the mouse.
        /// </summary>
        protected void OnMouseStep()
        {
            var dir = MouseStep?.Invoke();
            if (dir.HasValue)
            {
                GoTo(dir.Value);
            }
        }

        /// <summary>
        /// Invokes the TargetReached event.
        /// </summary>
        protected void OnTargetReached()
        {
            TargetReached?.Invoke();
        }

        /// <summary>
        /// Returns an IEnumerable of all directions, where there is no wall.
        /// </summary>
        public IEnumerable<Direction> GetFreeDirections()
        {
            return Enum.GetValues(typeof(Direction)).Cast<Direction>().Where(dir => !maze.HasFieldWall(Field.X, Field.Y, dir));
        }

        /// <summary>
        /// Helper method to move the mouse.
        /// </summary>
        protected void GoTo(Direction dir)
        {
            if (maze.HasFieldWall(Field.X, Field.Y, dir))
            {
                throw new WallException();
            }
            Field = new Position(Field.X + dir.DeltaX(), Field.Y + dir.DeltaY());
        }

        /// <summary>
        /// Moves the mouse one field/step.
        /// </summary>
        public void Step()
        {
            OnMouseStep();
        }

        /// <summary>
        /// Informs the mouse, that it reached the target.
        /// </summary>
        public void TargetIsReached()
        {
            OnTargetReached();
        }
    }
}
