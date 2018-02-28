using System;

namespace Maze
{
    /// <summary>
    /// Value type holding a field position consisting of two coordinates
    /// </summary>
    struct Position : IEquatable<Position>
    {
        public int X { get; }

        public int Y { get; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override int GetHashCode()
        {
            // https://en.wikipedia.org/wiki/Pairing_function
            return Y + ((X + Y) * (X + Y + 1) / 2);
        }

        public override bool Equals(object obj)
        {
            return (obj is Position) && Equals((Position)obj);
        }

        public bool Equals(Position other)
        {
            return (X == other.X) && (Y == other.Y);
        }

        public static bool operator ==(Position left, Position right)
        {
            return (left.X == right.X) && (left.Y == right.Y);
        }

        public static bool operator !=(Position left, Position right)
        {
            return !(left == right);
        }
    }
}
