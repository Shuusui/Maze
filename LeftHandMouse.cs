using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    class LeftHandMouse : IMouse
    {
       
        private Direction ChooseDirection()
        {

            IEnumerable<Direction> dirs = gameView.GetFreeDirections();
           
            switch (currentDir)
            {
                case Direction.LEFT:
                    if (dirs.Contains<Direction>(Direction.DOWN))
                    {
                        currentDir = Direction.DOWN;
                        return Direction.DOWN;
                    }
                    else if (dirs.Contains<Direction>(Direction.LEFT))
                    {
                        currentDir = Direction.LEFT;
                        return Direction.LEFT;
                    }
                    else if (dirs.Contains<Direction>(Direction.UP))
                    {
                        currentDir = Direction.UP;
                        return Direction.UP;
                    }
                    else if (dirs.Contains<Direction>(Direction.RIGHT))
                    {
                        currentDir = Direction.RIGHT;
                        return Direction.RIGHT;
                    }
                    break;
                case Direction.DOWN:
                    if (dirs.Contains<Direction>(Direction.RIGHT))
                    {
                        currentDir = Direction.RIGHT;
                        return Direction.RIGHT;
                    }
                    else if (dirs.Contains<Direction>(Direction.DOWN))
                    {                        
                        currentDir = Direction.DOWN;
                        return Direction.DOWN;
                    }
                    else if (dirs.Contains<Direction>(Direction.LEFT))
                    {
                        currentDir = Direction.LEFT;
                        return Direction.LEFT;
                    }
                    else if (dirs.Contains<Direction>(Direction.UP))
                    {
                        currentDir = Direction.UP;
                        return Direction.UP;
                    }
                    break;
                case Direction.RIGHT:
                    if (dirs.Contains<Direction>(Direction.UP))
                    {
                        currentDir = Direction.UP;
                        return Direction.UP;
                    }
                    else if (dirs.Contains<Direction>(Direction.RIGHT))
                    {
                        currentDir = Direction.RIGHT;
                        return Direction.RIGHT;
                    }
                    else if (dirs.Contains<Direction>(Direction.DOWN))
                    {
                        currentDir = Direction.DOWN;
                        return Direction.DOWN;
                    }
                    else if (dirs.Contains<Direction>(Direction.LEFT))
                    {
                        currentDir = Direction.LEFT;
                        return Direction.LEFT;
                    }
                    break;
                case Direction.UP:
                    if (dirs.Contains<Direction>(Direction.LEFT))
                    {
                        currentDir = Direction.LEFT;
                        return Direction.LEFT;
                    }
                    else if (dirs.Contains<Direction>(Direction.UP))
                    {
                        currentDir = Direction.UP;
                        return Direction.UP;
                    }
                    else if (dirs.Contains<Direction>(Direction.RIGHT))
                    {
                        currentDir = Direction.RIGHT;
                        return Direction.RIGHT;
                    }
                    else if (dirs.Contains<Direction>(Direction.DOWN))
                    {
                        currentDir = Direction.DOWN;
                        return Direction.DOWN;
                    }
                    break;
            }
            return Direction.LEFT;
        }

        private void OnTargetReached()
        {
            gameView.MouseStep -= ChooseDirection;
        }


        private Direction currentDir;

        private IGameView gameView;


        public void Initialize(IGameView game, RandomNumberGenerator randomNumberGenerator)
        {
            gameView = game;

            gameView.MouseStep += ChooseDirection;
            gameView.TargetReached += OnTargetReached;
        }
    }
}
