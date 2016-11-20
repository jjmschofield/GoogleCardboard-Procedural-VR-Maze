using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace ProceduralMaze
{
    [RequireComponent(typeof(MazeDebugRenderer))]
    [RequireComponent(typeof(MazeMeshGenerator))]
    [RequireComponent(typeof(PlayerNavigation))]
    public class Maze : MonoBehaviour
    {
        public int width = 20;
        public int height = 20;
        public float spacing = 1;
        public PositionalGraph pathGraph;
        public PositionalGraph wallGraph;
        public PlayerNavigationGraph playerNavGraph;
        public List<MazeCell> cells;

        MazeMeshGenerator meshGenerator;

        void Start()
        {
            CreateMaze();
            meshGenerator = gameObject.GetComponent<MazeMeshGenerator>();
            meshGenerator.UpdateMesh(cells, pathGraph, wallGraph);
            CreatePlayerNavigation();
        }

        void CreateMaze()
        {
            ProceduralMazeGenerator mazeGenerator = new ProceduralMazeGenerator();
            mazeGenerator.Generate(width, height, spacing, System.DateTime.Now.Millisecond);
            cells = mazeGenerator.cells;
            pathGraph = mazeGenerator.pathGraph;
            wallGraph = mazeGenerator.wallGraph;
        }

        void CreatePlayerNavigation()
        {
            playerNavGraph = new PlayerNavigationGraph(pathGraph);
            PlayerNavigation playerNavigation = gameObject.GetComponent<PlayerNavigation>();
            playerNavigation.UpdateWaypoints(playerNavGraph.graph);
        }



    }
      
}

