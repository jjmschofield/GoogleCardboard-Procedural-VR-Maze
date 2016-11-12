using UnityEngine;


namespace ProceduralMaze
{
    public class Quad
    {
        public Vector3[] verts;
        public int[] tris;
        public Vector3[] normals;
        public Vector2[] uv;


        public Quad(Vector3 bottomLeft, Vector3 topLeft, Vector3 topRight, Vector3 bottomRight, WINDING winding = WINDING.clockwise)
        {
            verts = new Vector3[4];
            tris = new int[6];
            normals = new Vector3[4];
            uv = new Vector2[4];

            SetVerts(bottomLeft, topLeft, topRight, bottomRight);
            SetTris(winding);
            SetNormals();
            SetUVs();
        }

        void SetVerts(Vector3 bottomLeft, Vector3 topLeft, Vector3 topRight, Vector3 bottomRight)
        {
            verts[0] = bottomLeft;
            verts[1] = topLeft;
            verts[2] = topRight;
            verts[3] = bottomRight;
        }

        void SetTris(WINDING winding)
        {
            switch (winding)
            {
                case WINDING.clockwise:
                    //Bottom Left Tri
                    tris[0] = 0;
                    tris[1] = 1;
                    tris[2] = 3;

                    //Top Right Tri
                    tris[3] = 1;
                    tris[4] = 2;
                    tris[5] = 3;
                    break;

                case WINDING.anti_clockwise:
                    //Bottom Left Tri
                    tris[0] = 0;
                    tris[1] = 3;
                    tris[2] = 1;

                    //Top Right Tri
                    tris[3] = 1;
                    tris[4] = 3;
                    tris[5] = 2;
                    break;
            }
        }

        void SetNormals()
        {
            Vector3 normal = Vector3.Cross(verts[1] - verts[0], verts[3] - verts[0]).normalized;

            normals[0] = normal;
            normals[1] = normal;
            normals[2] = normal;
            normals[3] = normal;
        }

        void SetUVs()
        {
            uv[0] = new Vector2(0, 0);
            uv[1] = new Vector2(0, 1);
            uv[2] = new Vector2(1, 1);
            uv[3] = new Vector2(1, 0);
        }
    }
}