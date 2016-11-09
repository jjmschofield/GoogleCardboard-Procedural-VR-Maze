using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ProceduralMaze
{
    public class GraphNode
    {        
        protected List<GraphNode> connectedNodes;

        public GraphNode()
        {
            connectedNodes = new List<GraphNode>();
        }

        public void AddConnecteNoded(GraphNode node)
        {
            connectedNodes.Add(node);
        }

        public List<GraphNode> GetConnectedNodes()
        {
            return connectedNodes;
        }

    }
}

