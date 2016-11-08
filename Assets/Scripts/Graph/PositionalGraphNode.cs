using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ProceduralMaze
{
    public class PositionalGraphNode : GraphNode
    {
        public readonly Vector3 position;        

        public PositionalGraphNode()
        {
            position = new Vector3(0, 0, 0);
        }

        public PositionalGraphNode(Vector3 position)
        {
            this.position = position;
            neighbours = new List<GraphNode>();
        }    
    }
}

