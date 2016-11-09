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

        public void AddConnectedNode(GraphNode node)
        {
            if (!connectedNodes.Contains(node))
            {
                connectedNodes.Add(node);
            }
        }

        public void RemoveConnectedNode(GraphNode node)
        {
            connectedNodes.Remove(node);
        }

        public bool IsConnectedTo(GraphNode node)
        {
            return connectedNodes.Contains(node);
        }

        public List<GraphNode> GetConnectedNodes()
        {
            return connectedNodes;
        }

    }
}

