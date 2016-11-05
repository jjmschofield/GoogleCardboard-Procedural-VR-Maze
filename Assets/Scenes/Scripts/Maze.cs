using UnityEngine;
using System.Collections;


namespace ProceduralMaze
{
    [RequireComponent(typeof(MazeRenderer))]
    public class Maze : MonoBehaviour
    {
        public int width = 20;
        public int height = 20;
        public MazeNodes mazeNodes;
        public MazeEdges mazeEdges;

        MazeRenderer mazeRenderer;
        
        void Start()
        {
            mazeNodes = new MazeNodes(width, height);
            mazeEdges = new MazeEdges(mazeNodes);      
            mazeRenderer = gameObject.GetComponent<MazeRenderer>();
            generateMaze();


        }

        void Update()
        {

        }

        void generateMaze()
        {

        }
    }
}

