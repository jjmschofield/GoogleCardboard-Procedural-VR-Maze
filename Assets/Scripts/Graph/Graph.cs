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

            if (FindConnection(connection) == null)
            {
                nodeA.AddConnecteNoded(nodeA);
                nodeA.AddConnecteNoded(nodeB);
                connections.Add(connection);
            }
        }

        public void DisconnectNodes(GraphConnection<T> connection)
        {
            connections.Remove(FindConnection(connection));
            connection.start.RemoveConnectedNode(connection.end);
            connection.end.RemoveConnectedNode(connection.start);
        }

        public void DisconnectNodes(T nodeA, T nodeB)
        {
            GraphConnection<T> connection = new GraphConnection<T>(nodeA, nodeB);
            DisconnectNodes(connection);
        }

        public GraphConnection<T> FindConnection(GraphConnection<T> connection)
        {
            foreach (GraphConnection<T> existingConnection in connections) //TODO - this would be better served by a custom equality operator?
            {
                if (existingConnection.start == connection.start &&
                    existingConnection.end == connection.end)
                {
                    return existingConnection;
                }

                if (existingConnection.start == connection.end &&
                      existingConnection.end == connection.start)
                {
                    return existingConnection;
                }
            }

            return null;
        }

        public GraphConnection<T> FindConnection(T nodeA, T nodeB)
        {
            GraphConnection<T> connection = new GraphConnection<T>(nodeA, nodeB);
            return FindConnection(connection);
        }



        }
}
