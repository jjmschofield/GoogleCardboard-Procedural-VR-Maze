using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ProceduralMaze { 
    public class Graph {
        public int x { get; private set; }
        public int y { get; private set; }
        public Dictionary<Position2D,GraphNode> nodes { get; private set; }
        public List<GrpahEdge> edges { get; private set; }

        //Create an empty Graph
        public Graph() 
        {
            nodes = new Dictionary<Position2D, GraphNode>();
            edges = new List<GrpahEdge>();
        }

        //Create a graph with fixed dimensions and immediately process adjacency and edges
        public Graph(int width, int height)
        {
            nodes = new Dictionary<Position2D, GraphNode>();
            edges = new List<GrpahEdge>();

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    AddNode(new Position2D(x, y));
                }
            }

            Update();
        }

        public void Update()
        {
            SetNodeNeighbours();
            SetEdges();
        }

        public void AddNode(Position2D position)
        {
            nodes[position] = new GraphNode(position.x, position.y);
        }

        public GraphNode GetNode(Position2D position)
        {
            return nodes[position];
        }        

        void SetNodeNeighbours()
        {         
            foreach (var nodeEntry in nodes)
            {
                GraphNode node = nodeEntry.Value;
                TryAndSetNeighbour(node, node.x, node.y + 1);
                TryAndSetNeighbour(node, node.x, node.y - 1);
                TryAndSetNeighbour(node, node.x + 1, node.y);
                TryAndSetNeighbour(node, node.x - 1, node.y);
            }
        }

        void TryAndSetNeighbour(GraphNode node, int x, int y)
        {
            try
            {
                node.AddNeighbour(nodes[new Position2D(x, y)]);
            }
            catch { }               
        }

        void SetEdges()
        {
            edges = new List<GrpahEdge>();

            foreach (var nodeEntry in nodes)
            {
                GraphNode node = nodeEntry.Value;

                foreach (GraphNode neighbor in node.neighbours)
                {
                    GrpahEdge edge = new GrpahEdge(node, neighbor);

                    if (!EdgeAlreadyExists(edge))
                    {
                        edges.Add(edge);
                    }
                }
            }
        }

        bool EdgeAlreadyExists(GrpahEdge edge) //TODO - this works but it's horrible. Maybe there is approach problem?
        {

            foreach (GrpahEdge existingEdge in edges)
            {

                if (existingEdge.start.x == edge.start.x &&
                    existingEdge.end.x == edge.end.x &&
                    existingEdge.start.y == edge.start.y &&
                    existingEdge.end.y == edge.end.y)
                {
                    return true;
                }

                if (existingEdge.start.x == edge.end.x &&
                   existingEdge.end.x == edge.start.x &&
                   existingEdge.start.y == edge.end.y &&
                   existingEdge.end.y == edge.start.y)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
