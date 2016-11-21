using UnityEngine;
using System.Collections;
namespace ProceduralMaze
{
    [RequireComponent(typeof(Collider))]
    public class PlayerWaypoint : MonoBehaviour
    {

        public Material defaultMaterial;
        public Material highlightedMaterial;
        public Material visitedMaterial;

        bool isOccupied = false;
        bool hasBeenVisitied = false;
        bool isHighlighted = false;
        PositionalGraphNode navNode;

        MeshRenderer meshRenderer;

        void Start()
        {
            meshRenderer = gameObject.GetComponent<MeshRenderer>();
        }

        void Update()
        {
            if (!hasBeenVisitied)
            {
                meshRenderer.material = defaultMaterial;
            }

            if (hasBeenVisitied)
            {
                meshRenderer.material = visitedMaterial;
            }


            if (isHighlighted)
            {
                meshRenderer.material = highlightedMaterial;
            }

            isHighlighted = false;
        }        

        public bool IsOccupied()
        {
            return isOccupied;
        }

        public PositionalGraphNode GetNavNode()
        {
            return navNode;
        }

        public bool HasBeenVisitied()
        {
            return hasBeenVisitied;
        }       

        public void Highlight()
        {
            isHighlighted = true;
        }

        public void SetNavNode(PositionalGraphNode node)
        {
            navNode = node;
        }

        public void MoveTo()
        {
            isOccupied = true;
            hasBeenVisitied = true;
        }

        public void MoveFrom()
        {
            isOccupied = false;
        }
    }
}
