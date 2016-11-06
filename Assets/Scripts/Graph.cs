using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ProceduralMaze { 
    public class Graph {       
        protected List<GraphNode> nodes;
        protected List<GraphEdge> edges;

        //Create an empty Graph
        public Graph() 
        {
            nodes = new List<GraphNode>();
            edges = new List<GraphEdge>();
        }        

        public void AddNode()
        {
            nodes.Add(new GraphNode());
        }

        public List<GraphNode> GetNodes()
        {
            return nodes;
        }

        public List<GraphEdge> GetEdges()
        {
            return edges;
        }

        protected void SetEdges()
        {
            edges = new List<GraphEdge>();

            foreach (GraphNode node in nodes)
            {
                List<GraphNode> neighbours = node.GetNeighbours();

                foreach (GraphNode neighbor in neighbours)
                {
                    GraphEdge edge = new GraphEdge(node, neighbor);

                    if (!EdgeAlreadyExists(edge))
                    {
                        edges.Add(edge);
                    }
                }
            }
        }

        bool EdgeAlreadyExists(GraphEdge edge)
        {

            foreach (GraphEdge existingEdge in edges)
            {

                if (existingEdge.start == edge.start &&
                    existingEdge.end == edge.end)
                {
                    return true;
                }

                if (existingEdge.start == edge.end &&
                      existingEdge.end == edge.start)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
