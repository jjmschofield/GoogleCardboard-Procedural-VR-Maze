using UnityEngine;
using System.Collections;

namespace ProceduralMaze
{
    [RequireComponent(typeof(PlayerCamera))]
    public class PlayerWaypointMovement : MonoBehaviour
    {

        public float speed = 10;
        public LayerMask layerMask;
        public bool showDebugRays = false;
        PlayerNavigation playerNavigation;
        PlayerWaypoint currentWaypoint;

        PlayerCamera playerCameraControl;

        void Start()
        {
            playerNavigation = FindObjectOfType<PlayerNavigation>();
            if (playerNavigation == null) Debug.LogError("PlayerNavigation not found in scene");

            playerCameraControl = gameObject.GetComponent<PlayerCamera>();
        }                       
        
        void Update()
        {
            if (currentWaypoint == null && playerNavigation != null) currentWaypoint = playerNavigation.GetWaypoints()[0].GetComponent<PlayerWaypoint>();
            UpdateGazeSelect();
            CheckForInput();
            UpdatePosition();
            ApplyCameraEffects();
        }

        void UpdateGazeSelect()
        {
            PlayerWaypoint waypoint = CastForWaypoint();

            if (waypoint != null && CanMoveToWaypoint(waypoint))
            {
                waypoint.Highlight();
            }
        }

        void CheckForInput()
        {
            if (Input.GetMouseButtonDown(0)) RequestMoveToWaypoint();
        }

        void RequestMoveToWaypoint()
        {
            PlayerWaypoint waypoint = CastForWaypoint();

            if (waypoint != null && CanMoveToWaypoint(waypoint))
            {
                MoveToWaypoint(waypoint);
            }
        }

        void MoveToWaypoint(PlayerWaypoint waypoint)
        {
            waypoint.MoveTo();
            currentWaypoint.MoveFrom();
            currentWaypoint = waypoint;
        }

        void UpdatePosition()
        {          
            Vector3 newPosition = Vector3.Lerp(transform.position, currentWaypoint.transform.position, speed * Time.deltaTime);
            transform.position = newPosition;
        }

        void ApplyCameraEffects()
        {
            if ((transform.position - currentWaypoint.transform.position).sqrMagnitude > 0.05F)
            {
                playerCameraControl.EnableBlur();
            }
            else
            {
                playerCameraControl.DisableBlur();
            }
        }

        bool CanMoveToWaypoint(PlayerWaypoint waypoint)
        {
            return !waypoint.IsOccupied() && WaypointsAreConnected(currentWaypoint,waypoint);
        }

        bool WaypointsAreConnected(PlayerWaypoint waypointA, PlayerWaypoint waypointB)
        {
            return waypointA.GetNavNode().GetConnectedNodes().Contains(waypointB.GetNavNode());
        }

        PlayerWaypoint CastForWaypoint()
        {
            PlayerWaypoint waypoint = null;

            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100F, layerMask))
            {
                waypoint = hit.transform.gameObject.GetComponent<PlayerWaypoint>();

                if (waypoint != null)
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
}
