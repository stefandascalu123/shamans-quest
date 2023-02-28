using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switchable : MonoBehaviour
{
    public GameObject[] switches;
    public Sprite onSprite;
    public Sprite offSprite;
    private Renderer rend;

    public bool open = false;
    void Start()
    {
        rend = GetComponentInChildren<SpriteRenderer>();
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
            ((SpriteRenderer)rend).sprite = onSprite;
        else
            ((SpriteRenderer)rend).sprite = offSprite;
    }
}
