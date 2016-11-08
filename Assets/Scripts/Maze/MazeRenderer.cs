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
        public bool drawMazeConnections = false;
        public bool drawWallConnections = false;
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
                Vector3 offset = new Vector3(0.5F, 0, 0.5F);

                foreach (PositionalGraphNode node in nodes)
                {
                    Gizmos.DrawSphere(node.position - offset, 0.1f);
                }
            }

            if (drawMazeConnections)
            {
                List<GraphConnection<PositionalGraphNode>> connections = maze.mazeNodeGraph.GetConnections();

                foreach (GraphConnection<PositionalGraphNode> connection in connections)
                {                   
                    Gizmos.DrawLine(connection.start.position, connection.end.position);
                }
            }


            if (drawWallConnections)
            {
                List<GraphConnection<PositionalGraphNode>> connections = maze.mazeWallGraph.GetConnections();

                foreach (GraphConnection<PositionalGraphNode> connection in connections)
                {
                    Gizmos.DrawLine(connection.start.position, connection.end.position);
                }
            }
        }
    }
}

