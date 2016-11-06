using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ProceduralMaze
{
    [RequireComponent(typeof(MazeRenderer))]
    public class MazeRenderer : MonoBehaviour
    {
        public bool drawMazeNodes = false;
        public bool drawEdges = false;
        Maze maze;

        void Start()
        {
            maze = gameObject.GetComponent<Maze>();
        }

        void OnDrawGizmos()
        {            
            if (drawMazeNodes)
            {
                var nodes = maze.graph.GetNodes();

                foreach (GraphSquareNode node in nodes)
                {                   
                    Gizmos.DrawSphere(new Vector3(node.x, 0, node.y), 0.15f);                    
                }                
            }

            if (drawEdges)
            {
                List<GraphEdge> edges = maze.graph.GetEdges();

                foreach (GraphEdge edge in edges)
                {

                    GraphSquareNode startNode = edge.start as GraphSquareNode;
                    GraphSquareNode endNode = edge.end as GraphSquareNode;

                    Gizmos.DrawLine(
                        new Vector3(startNode.x, 0, startNode.y),
                        new Vector3(endNode.x, 0, endNode.y)
                        );
                }
            }
        }
    }
}

