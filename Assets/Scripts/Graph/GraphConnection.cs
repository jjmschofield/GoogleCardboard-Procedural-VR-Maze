using UnityEngine;
using System.Collections;

namespace ProceduralMaze
{
    public class GraphConnection<T> where T : GraphNode
    {
        public T nodeA;
        public T nodeB;

        public GraphConnection(T nodeA, T nodeB)
        {
            this.nodeA = nodeA;
            this.nodeB = nodeB;
        }
    }
}
