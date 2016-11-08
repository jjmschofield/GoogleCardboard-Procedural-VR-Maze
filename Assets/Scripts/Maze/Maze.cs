using UnityEngine;
using System.Collections;


namespace ProceduralMaze
{
    [RequireComponent(typeof(MazeRenderer))]
    public class Maze : MonoBehaviour
    {
        public int width = 20;
        public int height = 20;
        public PositionalGraph mazeNodeGraph;
        public PositionalGraph mazeWallGraph;               
        
        void Start()
        {
            mazeNodeGraph = new PositionalGraph(width, height);
                        
            mazeWallGraph = new PositionalGraph(width + 1 , height + 1);
            mazeWallGraph.ConnectNeighbourNodes();
        }

        void Update()
        {

        }

        void generateMaze()
        {

        }
    }
}

