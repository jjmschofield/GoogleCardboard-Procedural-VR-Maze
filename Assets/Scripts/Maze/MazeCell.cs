using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ProceduralMaze { 
    public class MazeCell {
        public PositionalGraphNode mazeGrpahNode;
        public PositionalGraphNode[] wallGraphNodes; //0 = top left, 1 = top right, 2  = bottom right, 3 = bottom left       

        public MazeCell(PositionalGraphNode mazeGrpahNode)
        {
            this.mazeGrpahNode = mazeGrpahNode;
            wallGraphNodes = new PositionalGraphNode[4]; //We assum a square maze

        }

    }
}