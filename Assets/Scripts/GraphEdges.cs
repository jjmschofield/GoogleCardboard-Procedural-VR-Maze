using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ProceduralMaze
{
    public class GraphEdges
    {
        GraphNodes nodes;
        public List<GrpahEdge> edges;
        
        public GraphEdges(GraphNodes nodes) {
            this.nodes = nodes;
            setEdges();
        }

        void setEdges()
        {
            edges = new List<GrpahEdge>();
            
            foreach(GraphNode node in nodes.nodes)
            {
                foreach(GraphNode neighbor in node.neighbours)
                {                  
    
                    GrpahEdge edge = new GrpahEdge(node, neighbor);

                    if (!edgeAlreadyExists(edge))
                    {
                        edges.Add(edge);
                    }                    
                }
            }            
        }
        
        bool edgeAlreadyExists(GrpahEdge edge) //TODO - this works but it's horrible. Maybe there is approach problem?
        {

            foreach(GrpahEdge existingEdge in edges)
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

