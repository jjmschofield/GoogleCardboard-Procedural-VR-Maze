using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ProceduralMaze
{
    public class PlayerNavigationGraph
    {

        public PositionalGraph graph;

        public PlayerNavigationGraph(PositionalGraph mazeFloorGraph)
        {
            graph = new PositionalGraph();
            CreateNodes(mazeFloorGraph);
            ConnectNodes(mazeFloorGraph);
        }

        void ConnectNodes(PositionalGraph mazeFloorGraph)
        {
            
            foreach (PositionalGraphNode node in graph.GetNodes())
            {
                PositionalGraphNode floorNode = mazeFloorGraph.GetNodeAtPostion(node.position);

                foreach (PositionalGraphNode neighbour in floorNode.GetConnectedNodes())
                {
                    bool connectedToWaypoint = false;
                    List<PositionalGraphNode> visitedNodes = new List<PositionalGraphNode>();
                    visitedNodes.Add(node);

                    PositionalGraphNode nextStep = neighbour;

                    while (!connectedToWaypoint)
                    {
                        visitedNodes.Add(nextStep);

                        PositionalGraphNode existingNavNode = graph.GetNodeAtPostion(nextStep.position);

                        if (existingNavNode != null)
                        {
                            graph.ConnectNodes(node, existingNavNode);
                            connectedToWaypoint = true;
                        }

                        nextStep = nextStep.GetConnectedNodes()[0] as PositionalGraphNode;

                        if (visitedNodes.Contains(nextStep)){
                            nextStep = nextStep.GetConnectedNodes()[1] as PositionalGraphNode;
                        } 

                    }                    
                }

            }
        }

        void CreateNodes(PositionalGraph mazeFloorGraph)
        {
            List<PositionalGraphNode> unvisitedNodes = new List<PositionalGraphNode>();
            Stack openNodes = new Stack();

            foreach (PositionalGraphNode node in mazeFloorGraph.GetNodes())
            {
                unvisitedNodes.Add(node);
            }

            PositionalGraphNode currentNode = unvisitedNodes[0];
            openNodes.Push(currentNode);
            unvisitedNodes.Remove(currentNode);

            while (openNodes.Count > 0)
            {
                foreach (PositionalGraphNode node in currentNode.GetConnectedNodes())
                {
                    if (unvisitedNodes.Contains(node))
                    {
                        openNodes.Push(node);
                        unvisitedNodes.Remove(node);
                    }
                }

                if (ShouldBeWaypoint(currentNode))
                {
                    graph.AddNode(currentNode.position);
                }
                currentNode = openNodes.Pop() as PositionalGraphNode;
            }
        }


        bool ShouldBeWaypoint(PositionalGraphNode node)
        {

            List<GraphNode> connectedNodes = node.GetConnectedNodes();

            if (connectedNodes.Count == 1) //dead ends
            {               
                return true;
            }

            if (connectedNodes.Count > 2) //junctions
            {
                return true;
            }

            if (connectedNodes.Count == 2 && IsCorner(connectedNodes[0] as PositionalGraphNode, connectedNodes[1] as PositionalGraphNode)) //corners
            {
               return true;
            }

            return false;
        }

        bool IsCorner(PositionalGraphNode nodeA, PositionalGraphNode nodeB)
        {
            if ((nodeA.position.x != nodeB.position.x) && (nodeA.position.z != nodeB.position.z))
            {                
                return true;
            }

            return false;
        }

    }
}
