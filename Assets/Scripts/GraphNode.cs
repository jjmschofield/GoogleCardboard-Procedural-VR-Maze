using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ProceduralMaze
{
    public class GraphNode
    {        
        protected List<GraphNode> neighbours;

        public GraphNode()
        {
            neighbours = new List<GraphNode>();
        }

        public void AddNeighbour(GraphNode neigbour)
        {
            neighbours.Add(neigbour);
        }

        public List<GraphNode> GetNeighbours()
        {
            return neighbours;
        }

    }
}

