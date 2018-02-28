using System;
using System.Collections.Generic;
using System.Text;

namespace Maze
{
    /// <summary>
    /// Immutable class containing the maze data.
    /// </summary>
    class Maze
    {
        public int Width { get; }

        public int Height { get; }

        private ISet<Wall> walls;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="width">width of the maze</param>
        /// <param name="height">height of the maze</param>
        /// <param name="walls">IEnumerable of all walls inside the maze. The border will be added implicitely in this class.</param>
        public Maze(int width, int height, IEnumerable<Wall> walls)
        {
            Width = width;
            Height = height;
            this.walls = new HashSet<Wall>(walls);
        }

        /// <summary>
        /// Predicate which checks if in the given direction from the given field position, there is a wall (or a border).
        /// </summary>
        public bool HasFieldWall(int x, int y, Direction dir)
        {
            int dx = x + dir.DeltaX();
            int dy = y + dir.DeltaY();
            return (dx < 0) || (dx >= Width) || (dy < 0) || (dy >= Height) || walls.Contains(new Wall(x, y, dir));
        }

        /// <summary>
        /// Method to output the maze as string.
        /// The dictionary should contain a single character string for each position.
        /// These objects will be put into the center of the field.
        /// 
        /// Example of one field:
        /// +---+
        /// | x |
        /// +---+
        /// </summary>
        /// <param name="objects"></param>
        /// <returns></returns>
        public string ToString(IDictionary<Position, String> objects)
        {
            StringBuilder sb = new StringBuilder();
            for (int y = 0; y < Height; ++y)
            {
                for (int x = 0; x < Width; ++x)
                {
                    sb.Append(HasFieldWall(x, y, Direction.UP) ? "+---" : "+   ");
                }
                sb.AppendLine("+");
                for (int x = 0; x < Width; ++x)
                {
                    sb.Append(HasFieldWall(x, y, Direction.LEFT) ? "| " : "  ");
                    String value;
                    sb.Append(objects.TryGetValue(new Position(x, y), out value) ? value : " ").Append(" ");
                }
                sb.AppendLine("|");
            }
            for (int x = 0; x < Width; ++x)
            {
                sb.Append("+---");
            }
            sb.Append("+");
            return sb.ToString();
        }

        public override string ToString()
        {
            return ToString(new Dictionary<Position, String>());
        }
    }
}
