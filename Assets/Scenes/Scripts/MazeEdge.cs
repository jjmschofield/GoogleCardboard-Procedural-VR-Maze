using UnityEngine;
using System.Collections;

namespace ProceduralMaze
{
    public class MazeEdge 
    {
        public Position2D start;
        public Position2D end;

        public MazeEdge(Position2D start, Position2D end)
        {
            this.start = start;
            this.end = end;
        }
    }
}
