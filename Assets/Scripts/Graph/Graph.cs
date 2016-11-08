using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ProceduralMaze { 
    public class Graph<T> where T : GraphNode, new(){       
        protected List<T> nodes;
        protected List<GraphConnection<T>> connections;

        //Create an empty Graph
        public Graph() 
        {
            nodes = new List<T>();
            connections = new List<GraphConnection<T>>();
        }        

        public T AddNode()
        {
            T node = new T();
            nodes.Add(node);
            return node;
        }

        public List<T> GetNodes()
        {
            return nodes;
        }

        public List<GraphConnection<T>> GetConnections()
        {
            return connections;
        }

        public void ConnectNeighbourNodes()
        {
            connections = new List<GraphConnection<T>>();

            foreach (T node in nodes)
            {
                List<GraphNode> neighbours = node.GetNeighbours();

                foreach (T neighbor in neighbours)
                {
                    GraphConnection<T> edge = new GraphConnection<T>(node, neighbor);

                    if (!ConnectionExists(edge))
                    {
                        connections.Add(edge);
                    }
                }
            }
        }

        bool ConnectionExists(GraphConnection<T> edge)
        {

            foreach (GraphConnection<T> existingEdge in connections)
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
