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

            Vector3 wallOffset = new Vector3(0.5F, 0, 0.5F);

            if (drawMazeNodes)
            {
                Gizmos.color = Color.cyan;

                var nodes = maze.mazeNodeGraph.GetNodes();

                foreach (PositionalGraphNode node in nodes)
                {                   
                    Gizmos.DrawSphere(node.position, 0.15f);                    
                }                
            }         

            if (drawMazeConnections)
            {
                Gizmos.color = Color.cyan;

                List<GraphConnection<PositionalGraphNode>> connections = maze.mazeNodeGraph.GetConnections();

                foreach (GraphConnection<PositionalGraphNode> connection in connections)
                {                   
                    Gizmos.DrawLine(connection.start.position, connection.end.position);
                }
            }

            if (drawWallNodes)
            {

                Gizmos.color = Color.red;

                var nodes = maze.mazeWallGraph.GetNodes();


                foreach (PositionalGraphNode node in nodes)
                {
                    Gizmos.DrawSphere(node.position - wallOffset, 0.1f);
                }
            }

            if (drawWallConnections)
            {
                Gizmos.color = Color.red;

                List<GraphConnection<PositionalGraphNode>> connections = maze.mazeWallGraph.GetConnections();

                foreach (GraphConnection<PositionalGraphNode> connection in connections)
                {
                    Gizmos.DrawLine(connection.start.position - wallOffset, connection.end.position - wallOffset);
                }
            }
        }
    }
}

