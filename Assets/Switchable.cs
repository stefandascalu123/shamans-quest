using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switchable : MonoBehaviour
{
    public GameObject[] switches;
    bool open = false;
    void Start()
    {
        
    }
    void Update()
    {
        foreach(GameObject switchObj in switches)
        {
            Switch @switch = switchObj.GetComponent<Switch>();
            if (@switch.on == false)
            {
                open = false;
                break;
            }
            open = true;
        }
        if (open)
            // fancy animation instead of disabling sper
            transform.GetChild(0).gameObject.SetActive(false);
        else
            transform.GetChild(0).gameObject.SetActive(true);
    }
}
