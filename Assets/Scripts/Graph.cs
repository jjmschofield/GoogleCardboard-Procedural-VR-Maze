﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ProceduralMaze { 
    public class Graph<T> where T : GraphNode, new(){       
        protected List<T> nodes;
        protected List<GraphEdge<T>> edges;

        //Create an empty Graph
        public Graph() 
        {
            nodes = new List<T>();
            edges = new List<GraphEdge<T>>();
        }        

        public void AddNode()
        {
            nodes.Add(new T());
        }

        public List<T> GetNodes()
        {
            return nodes;
        }

        public List<GraphEdge<T>> GetEdges()
        {
            return edges;
        }

        protected void SetEdges()
        {
            edges = new List<GraphEdge<T>>();

            foreach (T node in nodes)
            {
                List<GraphNode> neighbours = node.GetNeighbours();

                foreach (T neighbor in neighbours)
                {
                    GraphEdge<T> edge = new GraphEdge<T>(node, neighbor);

                    if (!EdgeAlreadyExists(edge))
                    {
                        edges.Add(edge);
                    }
                }
            }
        }

        bool EdgeAlreadyExists(GraphEdge<T> edge)
        {

            foreach (GraphEdge<T> existingEdge in edges)
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
