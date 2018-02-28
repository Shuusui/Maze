
using System.Collections.Generic;

namespace Maze
{
    /// <summary>
    /// Function signature to the MouseStep event.
    /// </summary>
    /// <returns>The direction in which the mouse should move in the current step.</returns>
    delegate Direction Step();

    /// <summary>
    /// Function signature to the TargetReached event.
    /// </summary>
    delegate void Reach();

    /// <summary>
    /// View of the mouse agents (<see cref="IMouse"/>) on their environment.
    /// </summary>
    interface IGameView
    {
        /// <summary>
        /// Event, where the mouse agent can register itself to perform steps.
        /// </summary>
        event Step MouseStep;

        /// <summary>
        /// Event, when the mouse reaches the target
        /// </summary>
        event Reach TargetReached;

        /// <summary>
        /// Returns an IEnumerable of all directions, where there is no wall.
        /// </summary>
        IEnumerable<Direction> GetFreeDirections();
    }
}
