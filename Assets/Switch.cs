using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    private CharacterManager manager;
    public bool on;
    public Sprite onSprite;
    public Sprite offSprite;
    private Renderer switchRenderer;
    private float cooldown = 1;
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterManager>();
        on = false;
        switchRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    void Update()
    {
        cooldown -= Time.deltaTime;
        if(on && GetComponentInChildren<Transform>().gameObject.activeSelf)
        {
            ((SpriteRenderer)switchRenderer).sprite = onSprite;
        }
        if (!on && GetComponentInChildren<Transform>().gameObject.activeSelf)
        {
            ((SpriteRenderer)switchRenderer).sprite = offSprite;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        if (Input.GetKey("e") && cooldown <=0)
        {
            if (!on)
                on = true; 
            else
                on = false;
            cooldown = 1;
        }
        
    }
}
