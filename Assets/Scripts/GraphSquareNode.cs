using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ProceduralMaze
{
    public class GraphSquareNode : GraphNode
    {

        public readonly int x;
        public readonly int y;        

        public GraphSquareNode(int x, int y)
        {
            this.x = x;
            this.y = y;
            neighbours = new List<GraphNode>();
        }    
    }
}

