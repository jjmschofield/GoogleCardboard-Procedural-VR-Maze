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

        public GraphNode(int x, int y)
        {
            this.x = x;
            this.y = y;
            neighbours = new List<GraphNode>();
        }

        public void AddNeighbour(GraphNode neigbour)
        {
            neighbours.Add(neigbour);
        }

    }
}

