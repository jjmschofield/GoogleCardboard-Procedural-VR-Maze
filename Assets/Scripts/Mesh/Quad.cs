using UnityEngine;


namespace ProceduralMaze
{
    public class Quad
    {
        public Vector3[] verts;
        public int[] tris;
        public Vector3[] normals;
        public Vector2[] uv;


        public Quad(Vector3 position, float width, float height, WINDING winding, Vector3 normal)
        {
            SetVerts(position,width,height);
            SetTris(winding);
            SetNormals(normal);
            SetUVs();
        }

        void SetVerts(Vector3 position, float width, float height)
        {
            verts = new Vector3[]
            {
                new  Vector3(-width * .5f, 0, -height * .5f) + position,
                new  Vector3(-width * .5f, 0, height * .5f) + position,
                new  Vector3(width * .5f, 0, height * .5f) + position,
                new  Vector3(width * .5f, 0, -height * .5f) + position
            }; 
        }

        void SetTris(WINDING winding)
        {
            tris = new int[6];

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

        void SetNormals(Vector3 normal)
        {
            normals = new Vector3[] { normal, normal, normal, normal };
        }

        void SetUVs()
        {
            uv = new Vector2[]
            {
                new Vector2(0, 0),
                new Vector2(0, 1),
                new Vector2(1, 1),
                new Vector2(1, 0)
            };
        }
    }
}