using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace ProceduralMaze
{
    public class GraphSquare : Graph<GraphSquareNode>
    {               

        public GraphSquare()
        {
            nodes = new List<GraphSquareNode>();
            edges = new List<GraphConnection<GraphSquareNode>>();
        } 
        
        public GraphSquare(int width, int height)
        {
            nodes = new List<GraphSquareNode>();
            edges = new List<GraphConnection<GraphSquareNode>>();

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

        public GraphSquareNode AddNode(Position2D position)
        {
            GraphSquareNode existingNode = GetNodeAtPostion(position);

            if(existingNode == null)
            {
                GraphSquareNode node = new GraphSquareNode(position);
                nodes.Add(node);
                return node;
            }
            else
            {
                return existingNode;
            }       
        }

        public GraphSquareNode GetNodeAtPostion(Position2D position)
        {
            for (var i = 0; i < nodes.Count; i++)
            {
                GraphSquareNode node = nodes[i] as GraphSquareNode;

                if (node.x == position.x && node.y == position.y)
                {
                    return node;
                }
            }

            return null;
        }

        void SetNodeNeighbours()
        {
            foreach (GraphSquareNode node in nodes)
            {
                TryAndSetNeighbour(node, node.x, node.y + 1);
                TryAndSetNeighbour(node, node.x, node.y - 1);
                TryAndSetNeighbour(node, node.x + 1, node.y);
                TryAndSetNeighbour(node, node.x - 1, node.y);
            }
        }

        void TryAndSetNeighbour(GraphSquareNode node, int x, int y)
        {
            GraphSquareNode neighbour = GetNodeAtPostion(new Position2D(x, y));

            if(neighbour != null)
            {
                node.AddNeighbour(neighbour);
            }
        }
    }
}
