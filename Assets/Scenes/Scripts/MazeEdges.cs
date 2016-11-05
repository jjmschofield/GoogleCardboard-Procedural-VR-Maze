using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ProceduralMaze
{
    public class MazeEdges
    {
        MazeNodes nodes;
        public List<MazeEdge> edges;
        
        public MazeEdges(MazeNodes nodes) {
            this.nodes = nodes;
            setEdges();
        }

        void setEdges()
        {
            edges = new List<MazeEdge>();
            
            foreach(MazeNode node in nodes.nodes)
            {
                foreach(MazeNode neighbor in node.neighbours)
                {                    
                    Position2D startPos = new Position2D(node.x, node.y);
                    Position2D endPos = new Position2D(neighbor.x, neighbor.y);
                    MazeEdge edge = new MazeEdge(startPos, endPos);

                    if (!edgeAlreadyExists(edge))
                    {
                        edges.Add(edge);
                    }                    
                }
            }            
        }
        
        bool edgeAlreadyExists(MazeEdge edge) //TODO - this works but it's horrible. Maybe there is approach problem?
        {

            foreach(MazeEdge existingEdge in edges)
            {                

                if(existingEdge.start.x == edge.start.x && 
                    existingEdge.end.x == edge.end.x &&
                    existingEdge.start.y == edge.start.y &&
                    existingEdge.end.y == edge.end.y)
                {
                    return true;
                }

                if (existingEdge.start.x == edge.end.x &&
                   existingEdge.end.x == edge.start.x &&
                   existingEdge.start.y == edge.end.y &&
                   existingEdge.end.y == edge.start.y)
                {
                    return true;
                }
            }

            return false;
        }
            

        
        

    }
}

