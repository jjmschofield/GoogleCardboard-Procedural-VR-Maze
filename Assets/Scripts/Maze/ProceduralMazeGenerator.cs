using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ProceduralMaze
{
    public class ProceduralMazeGenerator 
    {

        float spacing;
        int seed;
        int width;
        int height;

        public PositionalGraph pathGraph { get; private set; }
        public PositionalGraph wallGraph { get; private set; }
        public List<MazeCell> cells { get; private set; }

        public ProceduralMazeGenerator()
        {
      
        }       

        public void Generate(int width, int height, float spacing, int seed)
        {
            this.width = width;
            this.height = height;
            this.spacing = spacing;
            this.seed = seed;

            CreatePathGraph();
            CreateWallGraph();
            CreateMazeCells();
            GenerateMaze(seed);            
        }

        void CreatePathGraph()
        {
            pathGraph = new PositionalGraph(width, height, spacing);
        }

        void CreateWallGraph()
        {
            Vector3 wallOffset = new Vector3(spacing / 2, 0, spacing / 2);
            wallGraph = new PositionalGraph(width + 1, height + 1, spacing, wallOffset);
            wallGraph.ConnectNodesWithinDistance(spacing);
        }

        void CreateMazeCells()
        {
            List<PositionalGraphNode> mazeNodes = pathGraph.GetNodes();
            List<PositionalGraphNode> wallNodes = wallGraph.GetNodes();

            cells = new List<MazeCell>();

            foreach (PositionalGraphNode node in mazeNodes)
            {
                MazeCell mazeCell = new MazeCell(node);
                mazeCell.wallNodes = wallGraph.GetNodesNearPosition(node.position, spacing);
                cells.Add(mazeCell);
            }
        }


        void GenerateMaze(int seed) //Basic implementation of a randomized variant of Primm's algorithim to perform a backtraced depth first search
        {
            List<MazeCell> unvisitedMazeCells = CloneMazeCellList();
            Stack pastCellStack = new Stack();

            MazeCell currentCell = unvisitedMazeCells[0];
            unvisitedMazeCells.Remove(currentCell);

            while (unvisitedMazeCells.Count > 0)
            {
                List<PositionalGraphNode> neighbours = pathGraph.GetNodesNearPosition(currentCell.mazeNode.position, spacing);
                List<MazeCell> unvisitedNeighbours = GetCellsInMazeNodes(unvisitedMazeCells, neighbours);


                if (unvisitedNeighbours.Count > 0)
                {
                    pastCellStack.Push(currentCell); // Add current node to stack                                                      
                    MazeCell chosenCell = unvisitedNeighbours[Random.Range(0, unvisitedNeighbours.Count)]; // Pick a random neighbor node as chosen node                
                    CreateMazePassage(currentCell, chosenCell);
                    unvisitedMazeCells.Remove(chosenCell); // Mark chosen node as visited                    
                    currentCell = chosenCell; // Make chosen node current node
                }
                else
                {
                    currentCell = pastCellStack.Pop() as MazeCell;
                }
            }
        }

        List<MazeCell> CloneMazeCellList()
        {
            List<MazeCell> clonedList = new List<MazeCell>();

            foreach (MazeCell cell in cells)
            {
                clonedList.Add(cell);
            }

            return clonedList;
        }

        List<MazeCell> GetCellsInMazeNodes(List<MazeCell> mazeCells, List<PositionalGraphNode> nodes)
        {
            List<MazeCell> matchedCells = new List<MazeCell>();

            foreach (PositionalGraphNode node in nodes)
            {
                foreach (MazeCell cell in mazeCells)
                {
                    if (cell.mazeNode == node)
                    {
                        matchedCells.Add(cell);
                    }
                }
            }

            return matchedCells;

        }

        void CreateMazePassage(MazeCell cellA, MazeCell cellB)
        {
            RemoveWallBetweenCells(cellA, cellB);
            pathGraph.ConnectNodes(cellA.mazeNode, cellB.mazeNode);
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

            wallGraph.DisconnectNodes(sharedNodes[0], sharedNodes[1]); //TODO - will presently only work for cells that share only two wall peices - create overload for DisconnectNodes(List<T> nodes)

        }
    }

}