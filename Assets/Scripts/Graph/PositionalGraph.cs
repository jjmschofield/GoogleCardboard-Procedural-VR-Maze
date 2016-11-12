using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace ProceduralMaze
{
    public class PositionalGraph : Graph<PositionalGraphNode>
    {        
        public PositionalGraph()
        {
          
        } 
        
        public PositionalGraph(int width, int height, float spacing = 1, Vector3 offset = new Vector3())
        {           
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    AddNode(new Vector3(x * spacing, 0 , y * spacing) - offset);
                }
            }
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

        public List<PositionalGraphNode> GetNodesNearPosition(Vector3 position, float distance)
        {
            List<PositionalGraphNode> nodesNearPosition = new List<PositionalGraphNode>();

            foreach(PositionalGraphNode node in nodes)
            {
                Vector3 vectorDistance = position - node.position;

                //Debug.Log(vectorDistance.sqrMagnitude);

                if(vectorDistance.magnitude <= distance)
                {
                    nodesNearPosition.Add(node);
                }
            }

            return nodesNearPosition;
        }

        public void ConnectNodesWithinDistance(float connectionDistancee) //TODO - this is inefficient 
        {
            foreach (PositionalGraphNode node in nodes)
            {
                foreach (PositionalGraphNode comparisonNode in nodes)
                {
                    Vector3 vectorDistance = node.position - comparisonNode.position;

                    if (vectorDistance.magnitude <= connectionDistancee)
                    {
                        ConnectNodes(node, comparisonNode);
                    }
                }
            }
        }
    }
}
