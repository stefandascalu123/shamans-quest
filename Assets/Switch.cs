using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    private CharacterManager manager;
    public bool on;
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterManager>();
        on = false;
    }
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown("e"))
        {
            if (!on)
                on = true; 
            else
                on = false; 
        }
    }
}
