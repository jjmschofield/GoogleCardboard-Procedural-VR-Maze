using UnityEngine;
using System.Collections;


namespace ProceduralMaze
{
    [RequireComponent(typeof(MazeRenderer))]
    public class Maze : MonoBehaviour
    {
        public int width = 20;
        public int height = 20;
        public Graph graph;               
        
        void Start()
        {
            graph = new Graph(width, height);
        }

        void Update()
        {

        }

        void generateMaze()
        {

        }
    }
}

