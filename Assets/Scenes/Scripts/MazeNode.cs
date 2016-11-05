using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ProceduralMaze
{
    public class MazeNode
    {

        public readonly int x;
        public readonly int y;
        public readonly List<MazeNode> neighbours;

        public MazeNode(int _x, int _y)
        {
            x = _x;
            y = _y;
            neighbours = new List<MazeNode>();
        }

        public void AddNeighbour(MazeNode neigbour)
        {
            neighbours.Add(neigbour);
        }

    }
}

