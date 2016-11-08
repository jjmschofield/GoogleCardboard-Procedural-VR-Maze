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
        public PositionalGraph mazeNodeGraph;
        public PositionalGraph mazeWallGraph;
        public List<MazeCell> mazeCells;               
        
        void Start()
        {
            mazeNodeGraph = new PositionalGraph(width, height);
                        
            mazeWallGraph = new PositionalGraph(width + 1 , height + 1);
            mazeWallGraph.ConnectNeighbourNodes();

            List<PositionalGraphNode> mazeNodes = mazeNodeGraph.GetNodes();
            List<PositionalGraphNode> wallNodes = mazeWallGraph.GetNodes();


            for (int y = 0; y < width; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    MazeCell mazeCell = new MazeCell(mazeNodes[x + y]);

                    Debug.Log("Cell " + (x + (y * width)));

                    Debug.Log("TL " + (x + (y * width) + y));
                    Debug.Log("TR " + (x + (y * width) + y + 1));
                    Debug.Log("BL " + (x + (y * width) + width + y + 1));
                    Debug.Log("BR " + (x + (y * width) + width + y + 2));

                }
            }


        }

        void Update()
        {

        }

        void generateMaze()
        {

        }
    }
}

