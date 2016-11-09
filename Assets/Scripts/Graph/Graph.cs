using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ProceduralMaze { 
    public class Graph<T> where T : GraphNode, new(){       
        protected List<T> nodes;
        protected List<GraphConnection<T>> connections;

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

        public void ConnectNodes(T nodeA, T nodeB)
        {
            GraphConnection<T> connection = new GraphConnection<T>(nodeA, nodeB);

            if (!ConnectionExists(connection))
            {
                nodeA.AddConnecteNoded(nodeA);
                nodeA.AddConnecteNoded(nodeB);
                connections.Add(connection);
            }
        }

        bool ConnectionExists(GraphConnection<T> connection)
        {

            foreach (GraphConnection<T> existingConnection in connections)
            {

                if (existingConnection.start == connection.start &&
                    existingConnection.end == connection.end)
                {
                    return true;
                }

                if (existingConnection.start == connection.end &&
                      existingConnection.end == connection.start)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
