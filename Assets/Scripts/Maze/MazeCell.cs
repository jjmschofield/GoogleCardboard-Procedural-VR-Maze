using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ProceduralMaze { 
    public class MazeCell {
        public PositionalGraphNode mazeGrpahNode;
        public List<PositionalGraphNode> wallGraphNodes;

        public MazeCell(PositionalGraphNode mazeGrpahNode)
        {
            this.mazeGrpahNode = mazeGrpahNode;
            wallGraphNodes = new List<PositionalGraphNode>();

        }

    }
}