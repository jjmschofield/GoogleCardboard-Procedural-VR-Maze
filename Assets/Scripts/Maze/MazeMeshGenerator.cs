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
        Mesh mesh;

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

            mesh = new Mesh();
            meshFilter.mesh = mesh;
            float wallHeight = 2.0F;

            List<Vector3> verts = new List<Vector3>();
            List<int> tris = new List<int>();
            List<Vector3> normals = new List<Vector3>();
            List<Vector2> uv = new List<Vector2>();


            foreach (GraphConnection<PositionalGraphNode> connection in wallGraph.GetConnections())
            {

                //Get verts
                Vector3 blVert = new Vector3(); //Bottom left               
                Vector3 brVert = new Vector3(); //Bottom Left

                if (connection.nodeA.position.z == connection.nodeB.position.z)
                {
                    if(connection.nodeA.position.x < connection.nodeB.position.x)
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

                if (connection.nodeA.position.x == connection.nodeB.position.x)
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

                //Add verts front face - order IS important
                verts.Add(blVert);
                verts.Add(tlVert);
                verts.Add(trVert);
                verts.Add(brVert);

                //Create tris

                //Bottom left tri - order IS important
                tris.Add(verts.IndexOf(blVert));
                tris.Add(verts.IndexOf(tlVert));
                tris.Add(verts.IndexOf(brVert));

                tris.Add(verts.IndexOf(blVert));
                tris.Add(verts.IndexOf(brVert));
                tris.Add(verts.IndexOf(tlVert));

                //Top right tri - order IS important
                tris.Add(verts.IndexOf(tlVert));
                tris.Add(verts.IndexOf(trVert));
                tris.Add(verts.IndexOf(brVert));

                tris.Add(verts.IndexOf(tlVert));
                tris.Add(verts.IndexOf(brVert));
                tris.Add(verts.IndexOf(trVert));



                //Set normals
                normals.Add(-Vector3.forward);
                normals.Add(-Vector3.forward);
                normals.Add(-Vector3.forward);
                normals.Add(-Vector3.forward);


                //Set uvs                
                uv.Add(new Vector2(verts.IndexOf(blVert), verts.IndexOf(tlVert)));
                uv.Add(new Vector2(verts.IndexOf(tlVert), verts.IndexOf(trVert)));
                uv.Add(new Vector2(verts.IndexOf(trVert), verts.IndexOf(brVert)));
                uv.Add(new Vector2(verts.IndexOf(brVert), verts.IndexOf(blVert)));
                

            }

            mesh.vertices = verts.ToArray();
            mesh.triangles = tris.ToArray();
            mesh.uv = uv.ToArray();
        }


        
    }
}

