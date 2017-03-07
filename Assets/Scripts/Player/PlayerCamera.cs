using UnityEngine;
using UnityStandardAssets.ImageEffects;

namespace ProceduralMaze
{
    public class PlayerCamera : MonoBehaviour {
       
        Camera mainCamera;
        CameraEffects mainEffects;
        Camera postCamera;
        CameraEffects postEffects;    

        void Start()
        {
            mainCamera = GetMainCamera();
            mainEffects = new CameraEffects(mainCamera);
        }

        void Update()
        {         
            if (postCamera == null)
            {
                postCamera = GetPostCamera();
                postEffects = new CameraEffects(postCamera);
            }      
        }


        Camera GetMainCamera()
        {
            return Camera.main;
        }

        Camera GetPostCamera()
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
            if (postEffects != null) postEffects.Blur(state);
        }

        public void Blink(bool state)
        {
            mainEffects.Blink(state);
        }
    }
}