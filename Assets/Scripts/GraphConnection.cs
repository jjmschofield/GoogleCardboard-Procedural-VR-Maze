using UnityEngine;
using System.Collections;

namespace ProceduralMaze
{
    public class GraphConnection<T> where T : GraphNode
    {
        public T start;
        public T end;

        public GraphConnection(T start, T end)
        {
            this.start = start;
            this.end = end;
        }
    }
}
