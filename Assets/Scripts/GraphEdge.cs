using UnityEngine;
using System.Collections;

namespace ProceduralMaze
{
    public class GraphEdge<T> where T : GraphNode
    {
        public T start;
        public T end;

        public GraphEdge(T start, T end)
        {
            this.start = start;
            this.end = end;
        }
    }
}
