using UnityEngine;
using System.Collections.Generic;

namespace ProceduralMaze
{
    public class PlayerNavigation : MonoBehaviour
    {

        public GameObject waypointPrefab;
        List<GameObject> waypoints;
        GameObject waypointContainer;

        void Start()
        {
            waypoints = new List<GameObject>();
            waypointContainer = new GameObject();
        }

        public void UpdateWaypoints(PositionalGraph navGraph)
        {
            DestroyWaypoints();
            waypoints = new List<GameObject>();

            foreach(PositionalGraphNode node in navGraph.GetNodes())
            {
                GameObject waypoint = Instantiate(waypointPrefab, node.position, transform.rotation) as GameObject;
                waypoint.transform.parent = waypointContainer.transform;
                waypoints.Add(waypoint);
            }
        }

        void DestroyWaypoints()
        {
            foreach(GameObject waypoint in waypoints)
            {
                Destroy(waypoint);
            }
        }

    }
}

