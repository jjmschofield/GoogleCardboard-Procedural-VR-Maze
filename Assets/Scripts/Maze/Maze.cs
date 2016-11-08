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
            mazeNodeGraph.ConnectNeighbourNodes();            
            mazeWallGraph = new PositionalGraph();         
        }

        void Update()
        {

        }

        void generateMaze()
        {

        }
    }
}

