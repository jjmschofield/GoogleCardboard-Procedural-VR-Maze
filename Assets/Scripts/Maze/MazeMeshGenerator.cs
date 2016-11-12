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
                Vector3 blVert = new Vector3(); //Bottom left               
                Vector3 brVert = new Vector3(); //Bottom Left

                if (wallDirection == DIRECTION.horizontal)
                {
                    if (connection.nodeA.position.x < connection.nodeB.position.x)
                    {
                        blVert = connection.nodeA.position;
                        brVert = connection.nodeB.position;
                    }

                    if (connection.nodeA.position.x > connection.nodeB.position.x)
                    {
                        blVert = connection.nodeB.position;
                        brVert = connection.nodeA.position;
                    }
                }

                if (wallDirection == DIRECTION.vertical)
                {
                    if (connection.nodeA.position.z < connection.nodeB.position.z)
                    {
                        blVert = connection.nodeA.position;
                        brVert = connection.nodeB.position;
                    }

                    if (connection.nodeA.position.z > connection.nodeB.position.z)
                    {
                        blVert = connection.nodeB.position;
                        brVert = connection.nodeA.position;
                    }
                }

                Vector3 tlVert = new Vector3(blVert.x, wallHeight, blVert.z);
                Vector3 trVert = new Vector3(brVert.x, wallHeight, brVert.z);

                Quad frontFace = new Quad(blVert, tlVert, trVert, brVert, WINDING.clockwise);
                Quad backFace = new Quad(brVert, trVert, tlVert, blVert, WINDING.clockwise);

                faces.Add(frontFace);
                faces.Add(backFace);

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

