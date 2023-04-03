using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switchable : MonoBehaviour
{
    public GameObject[] switches;
    public Sprite onSprite;
    public Sprite offSprite;
    private Renderer rend;
    public int type;
    [SerializeField] private GameObject col;

    public bool open = false;
    void Start()
    {
        rend = GetComponentInChildren<SpriteRenderer>();
    }
    void Update()
    {
        foreach(GameObject switchObj in switches)
        {
            if(type == 0)
            if (switchObj.GetComponent<SwitchTwo>().on == false)
            {
                open = false;
                break;
            }
            if(type == 1)
            if (switchObj.GetComponent<ToggleOnOff>().powered == false)
            {
                open = false;
                break;
            }
            
            open = true;
        }
        if (open){
            // fancy animation instead of disabling sper
           col.SetActive(false);
            ((SpriteRenderer)rend).sprite = onSprite;
        }else{
            col.SetActive(true);
            ((SpriteRenderer)rend).sprite = offSprite;
        }
    }
}
