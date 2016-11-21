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
            waypointContainer = new GameObject("waypoints");
            waypointContainer.transform.parent = transform;
        }

        public void UpdateWaypoints(PositionalGraph navGraph)
        {
            DestroyWaypoints();
            waypoints = new List<GameObject>();

            foreach(PositionalGraphNode node in navGraph.GetNodes())
            {
                CreateWaypoint(node);
            }
        }

        public List<GameObject> GetWaypoints()
        {
            return waypoints;
        }

        void CreateWaypoint(PositionalGraphNode node)
        {
            GameObject waypoint = Instantiate(waypointPrefab, node.position, transform.rotation) as GameObject;
            waypoint.transform.parent = waypointContainer.transform;
            waypoint.GetComponent<PlayerWaypoint>().SetNavNode(node);
            waypoints.Add(waypoint);
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

