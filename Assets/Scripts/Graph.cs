using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ProceduralMaze { 
    public class Graph<T> where T : GraphNode, new(){       
        protected List<T> nodes;
        protected List<GraphConnection<T>> edges;

        //Create an empty Graph
        public Graph() 
        {
            nodes = new List<T>();
            edges = new List<GraphConnection<T>>();
        }        

        public void AddNode()
        {
            nodes.Add(new T());
        }

        public List<T> GetNodes()
        {
            return nodes;
        }

        public List<GraphConnection<T>> GetEdges()
        {
            return edges;
        }

        protected void SetEdges()
        {
            edges = new List<GraphConnection<T>>();

            foreach (T node in nodes)
            {
                List<GraphNode> neighbours = node.GetNeighbours();

                foreach (T neighbor in neighbours)
                {
                    GraphConnection<T> edge = new GraphConnection<T>(node, neighbor);

                    if (!EdgeAlreadyExists(edge))
                    {
                        edges.Add(edge);
                    }
                }
            }
        }

        bool EdgeAlreadyExists(GraphConnection<T> edge)
        {

            foreach (GraphConnection<T> existingEdge in edges)
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
