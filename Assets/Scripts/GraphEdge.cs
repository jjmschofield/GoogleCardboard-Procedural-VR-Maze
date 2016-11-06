using UnityEngine;
using System.Collections;

namespace ProceduralMaze
{
    public class GraphEdge 
    {
        public GraphNode start;
        public GraphNode end;

        public GraphEdge(GraphNode start, GraphNode end)
        {
            this.start = start;
            this.end = end;
        }
    }
}
