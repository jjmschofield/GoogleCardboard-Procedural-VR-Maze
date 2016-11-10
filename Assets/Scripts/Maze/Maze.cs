using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace ProceduralMaze
{
    [RequireComponent(typeof(MazeRenderer))]
    public class Maze : MonoBehaviour
    {
        public int width = 20;
        public int height = 20;
        public float spacing = 1;
        public PositionalGraph pathGraph;
        public PositionalGraph wallGraph;
        public List<MazeCell> cells;

        void Start()
        {
            CreateMaze();
        }

        void CreateMaze()
        {
            ProceduralMazeGenerator mazeGenerator = new ProceduralMazeGenerator();
            mazeGenerator.Generate(width, height, spacing, System.DateTime.Now.Millisecond);
            cells = mazeGenerator.cells;
            pathGraph = mazeGenerator.pathGraph;
            wallGraph = mazeGenerator.wallGraph;
        }



    }
      
}

