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
        public bool drawMazeWallRelationships = false;
        public bool drawMazeWalls = false;

        Maze maze;

        void Start()
        {
            maze = gameObject.GetComponent<Maze>();
        }

        void OnDrawGizmos()
        {

            if (drawMazeNodes)
            {
                Gizmos.color = Color.cyan;

                var nodes = maze.pathGraph.GetNodes();

                foreach (PositionalGraphNode node in nodes)
                {                   
                    Gizmos.DrawSphere(node.position, 0.15f);                    
                }                
            }         

            if (drawMazeConnections)
            {
                Gizmos.color = Color.cyan;

                List<GraphConnection<PositionalGraphNode>> connections = maze.pathGraph.GetConnections();

                foreach (GraphConnection<PositionalGraphNode> connection in connections)
                {                   
                    Gizmos.DrawLine(connection.nodeA.position, connection.nodeB.position);
                }
            }

            if (drawWallNodes)
            {

                Gizmos.color = Color.red;

                var nodes = maze.wallGraph.GetNodes();


                foreach (PositionalGraphNode node in nodes)
                {
                    Gizmos.DrawSphere(node.position, 0.1f);
                }
            }

            if (drawWallConnections)
            {
                Gizmos.color = Color.red;

                List<GraphConnection<PositionalGraphNode>> connections = maze.wallGraph.GetConnections();

                foreach (GraphConnection<PositionalGraphNode> connection in connections)
                {
                    Gizmos.DrawLine(connection.nodeA.position, connection.nodeB.position);
                }
            }

            if (drawMazeWallRelationships)
            {
                Gizmos.color = Color.green;

                foreach(MazeCell cell in maze.cells)
                {
                    foreach(PositionalGraphNode wallNode in cell.wallNodes)
                    {
                        Gizmos.DrawLine(cell.mazeNode.position, wallNode.position);
                    }
                }

            }            
        }
    }
}

