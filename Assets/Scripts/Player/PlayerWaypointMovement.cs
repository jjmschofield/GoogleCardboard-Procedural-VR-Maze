using UnityEngine;
using System.Collections;

public class PlayerWaypointMovement : MonoBehaviour {

    public bool showDebugRays = false;
    public LayerMask layerMask;
	
	// Update is called once per frame
	void Update () {
        UpdateGazeSelect();
	}

    void UpdateGazeSelect()
    {
        PlayerWaypoint waypoint = CastForWaypoint();

        if(waypoint != null && waypoint.CanBeMovedToo())
        {
            waypoint.Highlight();
        }

    }

    PlayerWaypoint CastForWaypoint()
    {
        PlayerWaypoint waypoint = null;

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;             

        if (Physics.Raycast(ray, out hit, 100F, layerMask))
        {
            waypoint = hit.transform.gameObject.GetComponent<PlayerWaypoint>();

            if(waypoint != null)
            {
                if (showDebugRays) Debug.DrawLine(ray.origin, hit.point, Color.green);
            }
            else
            {
                if (showDebugRays) Debug.DrawLine(ray.origin, hit.point, Color.red);
            }           
            
        }       
     
        return waypoint;
    }




}
