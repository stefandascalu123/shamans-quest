using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    // Start is called before the first frame update
    public Movement playerMovement;
    private float size;

    private bool shouldZoomIn = false;
    private bool shouldZoomOut = false;
    private bool pause = false;

    private int frameCount;
    //private float t = 0;
    //private float cooldown = 1;
    void Start()
    {
        size = GetComponent<Camera>().orthographicSize;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(shouldZoomIn){
            if(GetComponent<Camera>().orthographicSize >= 7){
                shouldZoomIn = false;
                pause = true;
                frameCount = 50;

            }else{

                GetComponent<Camera>().orthographicSize += 0.08f;
            }
        }

        if(pause){
            if(frameCount == 0){
                pause = false;
                shouldZoomOut = true;
            }else{
                frameCount --;
            }
        }

        if(shouldZoomOut){
            if(GetComponent<Camera>().orthographicSize <= 5){
                shouldZoomOut = false;
            }else{
            GetComponent<Camera>().orthographicSize -= 0.08f;
            }
        }

        // Mathf.Lerp nice effect with cooldown ceva ceva
        if (Input.GetMouseButton(1) && playerMovement._moveInput.x == 0)
        {
            if(!shouldZoomIn && !shouldZoomOut){
                ZoomIn();
            }
        }
    }

    void ZoomIn(){
        shouldZoomIn = true;
    }
}
