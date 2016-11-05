using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ProceduralMaze
{
    public class GraphNode
    {

        public readonly int x;
        public readonly int y;
        public readonly List<GraphNode> neighbours;

        public GraphNode(int _x, int _y)
        {
            x = _x;
            y = _y;
            neighbours = new List<GraphNode>();
        }

        public void AddNeighbour(GraphNode neigbour)
        {
            neighbours.Add(neigbour);
        }

    }
}

