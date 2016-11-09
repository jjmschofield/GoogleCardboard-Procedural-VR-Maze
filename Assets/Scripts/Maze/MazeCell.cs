using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ProceduralMaze {
    public class MazeCell {
        public PositionalGraphNode mazeNode;
        public List<PositionalGraphNode> wallNodes;

        public MazeCell(PositionalGraphNode mazeNode)
        {
            this.mazeNode = mazeNode;
            wallNodes = new List<PositionalGraphNode>();
        }

    }
}