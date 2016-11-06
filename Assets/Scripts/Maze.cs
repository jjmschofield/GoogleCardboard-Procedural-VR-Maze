using UnityEngine;
using System.Collections;


namespace ProceduralMaze
{
    [RequireComponent(typeof(MazeRenderer))]
    public class Maze : MonoBehaviour
    {
        public int width = 20;
        public int height = 20;
        public GraphSquare graph;               
        
        void Start()
        {
            graph = new GraphSquare(width, height);
        }

        void Update()
        {

        }

        void generateMaze()
        {

        }
    }
}

