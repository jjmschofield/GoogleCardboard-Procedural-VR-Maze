using UnityEngine;
using UnityStandardAssets.ImageEffects;

namespace ProceduralMaze
{
    public class CameraEffects {

        Camera camera;
        BlurOptimized blur;

        public CameraEffects(Camera camera)
        {
            this.camera = camera;
        }

        public void Blur(bool state)
        {
            if(blur == null) AddBlur();
            blur.enabled = state;
        }

        void AddBlur()
        {
            blur = camera.gameObject.AddComponent<BlurOptimized>().GetComponent<BlurOptimized>();
            blur.blurShader = Shader.Find("Hidden/FastBlur");
            blur.enabled = false;
        }
    }
}