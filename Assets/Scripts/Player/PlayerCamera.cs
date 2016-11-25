using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class PlayerCamera : MonoBehaviour {
        
    Camera cam;
    BlurOptimized camBlur;    

    void Update()
    {         
        if (cam == null)
        {
            cam = FindObjectOfType<GvrPostRender>().gameObject.GetComponent<Camera>();
            if(cam != null)
            {
                camBlur = cam.gameObject.AddComponent<BlurOptimized>().GetComponent<BlurOptimized>();
                camBlur.blurShader = Shader.Find("Hidden/FastBlur");
                camBlur.enabled = false;
            }            
        }      
    }
    
    public void EnableBlur()
    {
        camBlur.enabled = true;
    }	

    public void DisableBlur()
    {        
        camBlur.enabled = false;
    }

}
