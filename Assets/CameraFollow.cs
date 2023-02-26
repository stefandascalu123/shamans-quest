using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform followTransform;
    //public Rect bounds;
    //private float cameraHalfSize;
    // Update is called once per frame
    private void Start()
    {
        //cameraHalfSize = GetComponent<Camera>().orthographicSize / 2;
    }
    void Update()
    {
        transform.position = new Vector3(followTransform.position.x, followTransform.position.y, followTransform.position.z - 10);
    }
    void OnDrawGizmosSelected()
    {
        // draw a wireframe rectangle to show the camera bounds
        //Gizmos.color = Color.red;
        //Gizmos.DrawWireCube(bounds.center, new Vector3(bounds.width, bounds.height, 0));
    }
}
