using UnityEngine;
using UnityStandardAssets.ImageEffects;

namespace ProceduralMaze
{
    public class CameraEffects {

        Camera camera;
        BlurOptimized blur;
        GameObject eyelid;

        public CameraEffects(Camera camera)
        {
            this.camera = camera;
        }

        public void Blur(bool state)
        {
            if (blur == null) AddBlur();

            if (blur.enabled != state) blur.enabled = state;
        }

        void AddBlur()
        {
            blur = camera.gameObject.AddComponent<BlurOptimized>().GetComponent<BlurOptimized>();
            blur.blurShader = Shader.Find("Hidden/FastBlur");
            blur.enabled = false;
        }

        public void Blink(bool state)
        {
            if (eyelid == null) AddEyelid();

            switch (state)
            {
                case false:
                    eyelid.GetComponent<MeshRenderer>().material.color = new Color(0f, 0f, 0f, 0f);
                    break;
                case true:
                    eyelid.GetComponent<MeshRenderer>().material.color = new Color(0f, 0f, 0f, 1f);
                    break;
            }
        }

        void AddEyelid()
        {
            eyelid = GameObject.CreatePrimitive(PrimitiveType.Quad);
            eyelid.transform.parent = camera.transform;
            eyelid.transform.localPosition = new Vector3(0, 0, camera.nearClipPlane + 0.01f); 
        }
    }
}