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
        
        public PositionalGraph(int width, int height, float spacing = 1)
        {
            nodes = new List<PositionalGraphNode>();
            connections = new List<GraphConnection<PositionalGraphNode>>();

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    AddNode(new Vector3(x * spacing, 0 , y * spacing));
                }
            }

            Update();
        }

        public void Update()
        {
            SetNodeNeighbours();            
        }        

        public PositionalGraphNode AddNode(Vector3 position)
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

        public PositionalGraphNode GetNodeAtPostion(Vector3 position)
        {
            for (var i = 0; i < nodes.Count; i++)
            {
                PositionalGraphNode node = nodes[i] as PositionalGraphNode;

                if (node.position == position)
                {
                    return node;
                }
            }

            return null;
        }

        void SetNodeNeighbours() //TODO - this needs to a sweep to find all nodes within a given sqrMagnitude
        {
            foreach (PositionalGraphNode node in nodes)
            {
                TryAndSetNeighbour(node, node.position.x, node.position.z + 1);
                TryAndSetNeighbour(node, node.position.x, node.position.z - 1);
                TryAndSetNeighbour(node, node.position.x + 1, node.position.z);
                TryAndSetNeighbour(node, node.position.x - 1, node.position.z);
            }
        }

        void TryAndSetNeighbour(PositionalGraphNode node, float x, float y)
        {
            PositionalGraphNode neighbour = GetNodeAtPostion(new Vector3(x, 0, y));

            if(neighbour != null)
            {
                node.AddNeighbour(neighbour);
            }
        }
    }
}
