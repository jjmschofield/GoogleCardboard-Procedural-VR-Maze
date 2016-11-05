using UnityEngine;
using System.Collections;


namespace ProceduralMaze
{
    [RequireComponent(typeof(MazeRenderer))]
    public class Maze : MonoBehaviour
    {
        public int width = 20;
        public int height = 20;
        public GraphNodes mazeNodes;
        public GraphEdges mazeEdges;

        MazeRenderer mazeRenderer;
        
        void Start()
        {
            mazeNodes = new GraphNodes(width, height);
            mazeEdges = new GraphEdges(mazeNodes);      
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

