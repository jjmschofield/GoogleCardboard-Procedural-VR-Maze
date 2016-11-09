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
        public PositionalGraph mazeNodeGraph;
        public PositionalGraph mazeWallGraph;
        public List<MazeCell> mazeCells;               
        


        void Start()
        {
            mazeNodeGraph = new PositionalGraph(width, height, spacing);
            mazeNodeGraph.ConnectNodesWithinDistance(spacing);

            Vector3 wallOffset = new Vector3(spacing / 2, 0, spacing / 2);
            mazeWallGraph = new PositionalGraph(width + 1 , height + 1, spacing, wallOffset);
            mazeWallGraph.ConnectNodesWithinDistance(spacing);

            List<PositionalGraphNode> mazeNodes = mazeNodeGraph.GetNodes();
            List<PositionalGraphNode> wallNodes = mazeWallGraph.GetNodes();

            mazeCells = new List<MazeCell>();

            foreach (PositionalGraphNode node in mazeNodes)
            {
                MazeCell mazeCell = new MazeCell(node);
                mazeCell.wallNodes = mazeWallGraph.GetNodesNearPosition(node.position, spacing);                
                mazeCells.Add(mazeCell);                
            }


            RemoveWallBetweenCells(mazeCells[0], mazeCells[1]);

        }

        void RemoveWallBetweenCells(MazeCell cellA, MazeCell cellB)
        {
            List<PositionalGraphNode> sharedNodes = new List<PositionalGraphNode>();

            foreach (PositionalGraphNode node in cellA.wallNodes)
            {
                if (cellB.wallNodes.Contains(node))
                {
                    sharedNodes.Add(node);
                } 
            }

            mazeWallGraph.DisconnectNodes(sharedNodes[0], sharedNodes[1]); //TODO - will presently only work for cells that share only two wall peices - create overload for DisconnectNodes(List<T> nodes)

        }

        void Update()
        {

        }

        void generateMaze()
        {

        }
    }
}

