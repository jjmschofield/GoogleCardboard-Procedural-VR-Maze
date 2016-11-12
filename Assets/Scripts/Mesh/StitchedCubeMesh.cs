using UnityEngine;
using System.Collections.Generic;

namespace ProceduralMaze
{
    public class StitchedCubeMesh
    {

        public Mesh mesh;

        public StitchedCubeMesh(List<Cube> cubes)
        {
            mesh = new Mesh();

            List<Vector3> verts = new List<Vector3>();
            List<int> tris = new List<int>();
            List<Vector3> normals = new List<Vector3>();
            List<Vector2> uv = new List<Vector2>();

            int quadCount = 0;

            foreach (Cube cube in cubes)
            {
                foreach (Vector3 vert in cube.verts)
                {
                    verts.Add(vert);
                }

                foreach (int triPos in cube.tris)
                {
                    tris.Add(triPos + quadCount * 24); //bump each realtionship up for each quad already added
                }

                quadCount++;

                foreach (Vector3 normal in cube.normals)
                {
                    normals.Add(normal);
                }

                foreach (Vector2 uvPos in cube.uv)
                {
                    uv.Add(uvPos);
                }

            }

            mesh.vertices = verts.ToArray();
            mesh.triangles = tris.ToArray();
            mesh.uv = uv.ToArray();
            mesh.Optimize();
            mesh.RecalculateBounds();
            mesh.RecalculateNormals();
        }
    }
}