using UnityEngine;
using System.Collections;

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

        void OnDrawGizmosSelected()
        {            
            if (drawMazeNodes)
            {
                foreach (GraphNode node in maze.mazeNodes.nodes)
                {                    
                    Gizmos.DrawSphere(new Vector3(node.x, 0, node.y), 0.15f);                    
                }                
            }

            if (drawEdges)
            {               
                foreach (GrpahEdge edge in maze.mazeEdges.edges)
                {
                    Gizmos.DrawLine(
                        new Vector3(edge.start.x, 0, edge.start.y),
                        new Vector3(edge.end.x, 0, edge.end.y)
                        );
                }
            }
        }
    }
}

