using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    // Start is called before the first frame update
    public Movement playerMovement;
    private float size;
    //private float t = 0;
    //private float cooldown = 1;
    void Start()
    {
        size = GetComponent<Camera>().orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        // Mathf.Lerp nice effect with cooldown ceva ceva
        if (Input.GetMouseButton(1))
        {
            GetComponent<Camera>().orthographicSize = 7;
            //t += Time.deltaTime;
        }
        else
        {
            GetComponent<Camera>().orthographicSize = 5;
        }
    }
}
