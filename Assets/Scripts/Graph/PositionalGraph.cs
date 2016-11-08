using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace ProceduralMaze
{
    public class PositionalGraph : Graph<PositionalGraphNode>
    {               

        public PositionalGraph()
        {
            nodes = new List<PositionalGraphNode>();
            connections = new List<GraphConnection<PositionalGraphNode>>();
        } 
        
        public PositionalGraph(int width, int height)
        {
            nodes = new List<PositionalGraphNode>();
            connections = new List<GraphConnection<PositionalGraphNode>>();

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
            ConnectAdjacentNodes();
        }        

        public PositionalGraphNode AddNode(Position2D position)
        {
            PositionalGraphNode existingNode = GetNodeAtPostion(position);

            if(existingNode == null)
            {
                PositionalGraphNode node = new PositionalGraphNode(position);
                nodes.Add(node);
                return node;
            }
            else
            {
                return existingNode;
            }       
        }

        public PositionalGraphNode GetNodeAtPostion(Position2D position)
        {
            for (var i = 0; i < nodes.Count; i++)
            {
                PositionalGraphNode node = nodes[i] as PositionalGraphNode;

                if (node.x == position.x && node.y == position.y)
                {
                    return node;
                }
            }

            return null;
        }

        void SetNodeNeighbours()
        {
            foreach (PositionalGraphNode node in nodes)
            {
                TryAndSetNeighbour(node, node.x, node.y + 1);
                TryAndSetNeighbour(node, node.x, node.y - 1);
                TryAndSetNeighbour(node, node.x + 1, node.y);
                TryAndSetNeighbour(node, node.x - 1, node.y);
            }
        }

        void TryAndSetNeighbour(PositionalGraphNode node, int x, int y)
        {
            PositionalGraphNode neighbour = GetNodeAtPostion(new Position2D(x, y));

            if(neighbour != null)
            {
                node.AddNeighbour(neighbour);
            }
        }
    }
}
