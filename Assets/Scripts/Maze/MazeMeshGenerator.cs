using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ProceduralMaze
{
    [RequireComponent(typeof(MeshFilter))]
    public class MazeMeshGenerator : MonoBehaviour
    {
        List<MazeCell> cells;
        PositionalGraph floorGraph;
        PositionalGraph wallGraph;
        MeshFilter meshFilter;

        enum DIRECTION { horizontal, vertical };

        void Start()
        {
            meshFilter = gameObject.GetComponent<MeshFilter>();
        }



        public void UpdateMesh(List<MazeCell> cells, PositionalGraph floorGraph, PositionalGraph wallGraph)
        {       
            this.cells = cells;
            this.floorGraph = floorGraph;
            this.wallGraph = wallGraph;

            //Generate walls
            UpdateWalls();
            //Generate floor

            //Generate ceiling

        }
        

        public void UpdateWalls()
        {
            List<Quad> faces = GetWallFaces();
            meshFilter.mesh = new StitchedQuadMesh(faces).mesh;
        }

        List<Quad> GetWallFaces()
        {
            float wallHeight = 2.0F;

            List<Quad> faces = new List<Quad>();

            foreach (GraphConnection<PositionalGraphNode> connection in wallGraph.GetConnections())
            {
                //Determine if horizontal
                DIRECTION wallDirection = GetWallDirection(connection);

                //Get verts
                Vector3 bottomLeft = new Vector3(); //Bottom left               
                Vector3 bottomRight = new Vector3(); //Bottom Left

                Vector3 normal = new Vector3();

                if (wallDirection == DIRECTION.horizontal)
                {

                    normal = Vector3.forward;

                    if (connection.nodeA.position.x < connection.nodeB.position.x)
                    {
                        bottomLeft = connection.nodeA.position;
                        bottomRight = connection.nodeB.position;
                    }

                    if (connection.nodeA.position.x > connection.nodeB.position.x)
                    {
                        bottomLeft = connection.nodeB.position;
                        bottomRight = connection.nodeA.position;
                    }
                }

                if (wallDirection == DIRECTION.vertical)
                {

                    normal = Vector3.right;

                    if (connection.nodeA.position.z < connection.nodeB.position.z)
                    {
                        bottomLeft = connection.nodeA.position;
                        bottomRight = connection.nodeB.position;
                    }

                    if (connection.nodeA.position.z > connection.nodeB.position.z)
                    {
                        bottomLeft = connection.nodeB.position;
                        bottomRight = connection.nodeA.position;
                    }
                }

                Vector3 topLeft = new Vector3(bottomLeft.x, wallHeight, bottomLeft.z);
                Vector3 topRight = new Vector3(bottomRight.x, wallHeight, bottomRight.z);

//                Vector3 offset = new Vector3(0, 0, 0.4F);

                Quad frontFace = new Quad(bottomLeft, topLeft, topRight, bottomRight, WINDING.clockwise, normal);
                Quad backFace = new Quad(bottomRight, topRight, topLeft, bottomLeft, WINDING.clockwise, -normal);

                faces.Add(frontFace);
                //faces.Add(backFace);

            }

            return faces;
        }

        DIRECTION GetWallDirection(GraphConnection<PositionalGraphNode> connection)
        {
            if (connection.nodeA.position.z == connection.nodeB.position.z)
            {
                return DIRECTION.horizontal;
            }
            else
            {
                return DIRECTION.vertical;
            }
        }
    }
}

