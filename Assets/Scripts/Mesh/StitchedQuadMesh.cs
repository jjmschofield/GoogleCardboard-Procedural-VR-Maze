using UnityEngine;
using System.Collections.Generic;

namespace ProceduralMaze
{
    public class StitchedQuadMesh
    {

        public Mesh mesh;

        public StitchedQuadMesh(List<Quad> quads)
        {
            mesh = new Mesh();

            List<Vector3> verts = new List<Vector3>();
            List<int> tris = new List<int>();
            List<Vector3> normals = new List<Vector3>();
            List<Vector2> uv = new List<Vector2>();

            int quadCount = 0;

            foreach (Quad face in quads)
            {
                foreach (Vector3 vert in face.verts)
                {
                    verts.Add(vert);
                }

                foreach (int triPos in face.tris)
                {
                    tris.Add(triPos + quadCount * 4); //bump each realtionship up for each quad already added
                }

                quadCount++;

                foreach (Vector3 normal in face.normals)
                {
                    normals.Add(normal);
                }

                foreach (Vector2 uvPos in face.uv)
                {
                    uv.Add(uvPos);
                }

            }

            mesh.vertices = verts.ToArray();
            mesh.triangles = tris.ToArray();
            mesh.uv = uv.ToArray();
        }
    }
}