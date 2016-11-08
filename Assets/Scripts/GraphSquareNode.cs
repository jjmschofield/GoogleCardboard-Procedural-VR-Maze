using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ProceduralMaze
{
    public class GraphSquareNode : GraphNode
    {

        public readonly int x;
        public readonly int y;        

        public GraphSquareNode()
        {
            x = 0;
            y = 0;
        }

        public GraphSquareNode(Position2D position)
        {
            this.x = position.x;
            this.y = position.y;
            neighbours = new List<GraphNode>();
        }    
    }
}

