using UnityEngine;
using UnityStandardAssets.ImageEffects;

namespace ProceduralMaze
{
    public class PlayerCamera : MonoBehaviour {
        
        Camera activeCamera;
        CameraEffects effects;    

        void Update()
        {         
            if (activeCamera == null)
            {
                activeCamera = GetPlayerCamera();
                effects = new CameraEffects(activeCamera);
            }      
        }

        Camera GetPlayerCamera()
        {
            GvrPostRender postRenderInstance = FindObjectOfType<GvrPostRender>();

            if (postRenderInstance == null)
            {
                return Camera.main;
            }
            else
            {
                return postRenderInstance.gameObject.GetComponent<Camera>() as Camera;
            }
        }

        public void Blur(bool state)
        {
            if (effects != null) effects.Blur(state);
        }
    }
}