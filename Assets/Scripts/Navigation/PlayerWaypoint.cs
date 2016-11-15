using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class PlayerWaypoint : MonoBehaviour {

    public Material defaultMaterial;
    public Material highlightedMaterial;
    public Material visitedMaterial;

    bool isOccupied = false;
    bool hasBeenVisitied = false;
    bool isHighlighted = false;

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

    
    public bool CanBeMovedToo()
    {
        return !isOccupied;
    }

    public bool HasBeenVisitied()
    {
        return hasBeenVisitied;
    }

    public void MoveTo()
    {
        isOccupied = true;
        hasBeenVisitied = true;
    }

    public void Highlight()
    {        
        isHighlighted = true;
    }
}
