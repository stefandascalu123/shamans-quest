using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WispStatue : MonoBehaviour
{
 
    public ToggleOnOff toggle;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Wisp" && toggle.powered == false){
            Destroy(other.gameObject);
            GetComponentInChildren<Animator>().SetBool("Powered", true);
            toggle.powered = true;
        }
    }
}
