using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProceduralMaze
{
    public class MazeNodes
    {
        public readonly int width;
        public readonly int height;
        public MazeNode[,] nodes { get; private set; }

        public MazeNodes(int width, int height)
        {
            this.width = width;
            this.height = height;
            generateNodes();
            setNeighbours();
        }

        void generateNodes()
        {            
            nodes = new MazeNode[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    nodes[x, y] = new MazeNode(x, y);
                }
            }            
        }

        void setNeighbours()
        {           
                 
            foreach (MazeNode node in nodes)
            {                
                tryAndSetNeighbour(node, node.x, node.y + 1);
                tryAndSetNeighbour(node, node.x, node.y - 1);
                tryAndSetNeighbour(node, node.x + 1, node.y);
                tryAndSetNeighbour(node, node.x - 1, node.y);                
            }
        }

        void tryAndSetNeighbour(MazeNode node, int x, int y)
        {
            if (isPositionWithinBounds(x, y)){
                node.AddNeighbour(nodes[x, y]);
            }        
        }
        
        public bool isPositionWithinBounds(int x, int y)
        {
            if(x < 0 || x >= width || y < 0 || y >= height)
            {
                return false;
            }
            else
            {
                return true;
            }
        }     
    }
}



    

