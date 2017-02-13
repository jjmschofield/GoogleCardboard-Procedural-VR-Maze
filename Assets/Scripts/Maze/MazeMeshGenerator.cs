using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ProceduralMaze
{    
    public class MazeMeshGenerator : MonoBehaviour
    {
        public Material wallMaterial;
        public Material floorMaterial;
        public Material ceilingMaterial;
        public int layer;

        public float wallHeight = 2.0F;
        public float wallWidth = 0.5F;

        GameObject wallObject;
        GameObject floorObject;
        GameObject ceilingObject;

        List<MazeCell> cells;
        PositionalGraph floorGraph;
        PositionalGraph wallGraph;        
        
        enum DIRECTION { horizontal, vertical };

        public void UpdateMesh(List<MazeCell> cells, PositionalGraph floorGraph, PositionalGraph wallGraph)
        {           
            CreateMeshObjects();

            this.cells = cells;
            this.floorGraph = floorGraph;
            this.wallGraph = wallGraph;

            AssignMesh(floorObject, GenerateFloorMesh());
            AssignMesh(wallObject, GenerateWallMesh());
            AssignMesh(ceilingObject, GenerateCeilingMesh());                    
        }        

        void DestroyExistingMeshObjects()
        {
            GameObject[] meshObjects = new GameObject[] { wallObject, floorObject, ceilingObject };

            foreach (GameObject meshObject in meshObjects)
            {
                if (meshObject != null) GameObject.Destroy(meshObject);
            }
        }

        void CreateMeshObjects()
        {
            DestroyExistingMeshObjects();
            floorObject = CreateMeshObject("floor",floorMaterial);
            wallObject = CreateMeshObject("wall", wallMaterial);
            ceilingObject = CreateMeshObject("ceiling", ceilingMaterial);

        }

        GameObject CreateMeshObject(string name, Material material)
        {
            GameObject meshObject = new GameObject(name);
            meshObject.transform.position = transform.position;
            meshObject.transform.parent = transform;
            meshObject.AddComponent<MeshFilter>();
            meshObject.AddComponent<MeshRenderer>();
            meshObject.AddComponent<MeshCollider>();
            meshObject.GetComponent<MeshRenderer>().material = material;
            meshObject.layer = layer;
            return meshObject;
        }

        void AssignMesh(GameObject meshObject, Mesh mesh)
        {
            meshObject.GetComponent<MeshFilter>().mesh = mesh;
            meshObject.GetComponent<MeshCollider>().sharedMesh = mesh;
        }

         Mesh GenerateWallMesh()
        {
            List<Cube> cubes = GeenerateWallCubes();
            return new StitchedCubeMesh(cubes).mesh;
        }

        List<Cube> GeenerateWallCubes()
        {
            List<Cube> cubes = new List<Cube>();
           
            foreach (GraphConnection<PositionalGraphNode> connection in wallGraph.GetConnections())
            {
                cubes.Add(GenerateWallCube(connection));
            }
            return cubes;
        }

        Cube GenerateWallCube(GraphConnection<PositionalGraphNode> connection)
        {
            DIRECTION wallDirection = GetWallDirection(connection);

            Vector3 position = (connection.nodeA.position + connection.nodeB.position) / 2;
            position.y += wallHeight / 2;
            Vector3 vectorDistance = connection.nodeA.position - connection.nodeB.position;
            float distance = vectorDistance.magnitude;

            if (wallDirection == DIRECTION.horizontal)
            {
                return new Cube(position, distance, wallWidth, wallHeight);             
            }
            else
            {
                return new Cube(position, wallWidth, distance, wallHeight);               
            }            
        }

        Mesh GenerateFloorMesh()
        {
            List<Quad> quads = GeneratePlane();
            return new StitchedQuadMesh(quads).mesh;
        }

        Mesh GenerateCeilingMesh()
        {
            List<Quad> quads = GeneratePlane(new Vector3(0,wallHeight,0), WINDING.anti_clockwise);
            return new StitchedQuadMesh(quads).mesh;
        }


        List<Quad> GeneratePlane(Vector3 positionOffset = new Vector3(), WINDING winding = WINDING.clockwise)
        {
            List<Quad> quads = new List<Quad>();

            foreach(PositionalGraphNode node in floorGraph.GetNodes())
            {
                Quad quad = new Quad(node.position + positionOffset, 2, 2, winding, Vector3.up);
                quads.Add(quad);
            }

            return quads;
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

