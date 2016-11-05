using UnityEngine;
using System.Collections;

namespace ProceduralMaze
{
    public class GrpahEdge 
    {
        public GraphNode start;
        public GraphNode end;

        public GrpahEdge(GraphNode start, GraphNode end)
        {
            this.start = start;
            this.end = end;
        }
    }
}
