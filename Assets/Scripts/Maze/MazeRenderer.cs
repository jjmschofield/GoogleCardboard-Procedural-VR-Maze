using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ProceduralMaze
{
    [RequireComponent(typeof(MazeRenderer))]
    public class MazeRenderer : MonoBehaviour
    {
        public bool drawMazeNodes = false;
        public bool drawWallNodes = false;
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
                var nodes = maze.mazeNodeGraph.GetNodes();

                foreach (PositionalGraphNode node in nodes)
                {                   
                    Gizmos.DrawSphere(node.position, 0.15f);                    
                }                
            }

            if (drawWallNodes)
            {
                var nodes = maze.mazeWallGraph.GetNodes();                    
            }

            if (drawEdges)
            {
                List<GraphConnection<PositionalGraphNode>> edges = maze.mazeNodeGraph.GetConnections();

                foreach (GraphConnection<PositionalGraphNode> edge in edges)
                {                   
                    Gizmos.DrawLine(edge.start.position, edge.end.position);
                }
            }
        }
    }
}

