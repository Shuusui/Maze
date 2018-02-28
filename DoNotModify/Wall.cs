using System;

namespace Maze
{
    /// <summary>
    /// Value type holding the position of a wall by storing the position of both adjacent field positions.
    /// </summary>
    class Wall : IEquatable<Wall>
    {
        public Position Field1 { get; }

        public Position Field2 { get; }

        public Wall(int x, int y, Direction dir)
        {
            Field1 = new Position(x, y);
            Field2 = new Position(x + dir.DeltaX(), y + dir.DeltaY());
        }

        public override int GetHashCode()
        {
            int hash1 = Field1.GetHashCode();
            int hash2 = Field2.GetHashCode();
            // https://en.wikipedia.org/wiki/Pairing_function
            return ((hash1 + hash2) * (hash1 + hash2 + 1) / 2) + Math.Min(hash1, hash2);
        }

        public override bool Equals(object obj)
        {
            return (obj is Wall) && Equals((Wall) obj);
        }

        public bool Equals(Wall other)
        {
            return ((Field1 == other.Field1) && (Field2 == other.Field2)) || ((Field1 == other.Field2) && (Field2 == other.Field1));
        }

        public static bool operator ==(Wall left, Wall right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Wall left, Wall right)
        {
            return !(left == right);
        }
    }
}
