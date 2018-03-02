using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    struct Rectangle
    {
        public int WidthNull { get; set; }
        public int WidthMax { get; set; }
        public int HeightNull { get; set;  }
        public int HeightMax { get; set; }



        public Rectangle(int WidthNull, int WidthMax, int HeightNull, int HeightMax)
        {
            this.WidthNull = WidthNull;
            this.WidthMax = WidthMax;
            this.HeightNull = HeightNull;
            this.HeightMax = HeightMax; 
        }
    }
}
