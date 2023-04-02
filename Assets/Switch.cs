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
    public ToggleOnOff toggle;

    [SerializeField] private AudioSource flickEffect;

    private float cooldown = 0.25f;
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterManager>();
        switchRenderer = GetComponentInChildren<SpriteRenderer>();
        on = false;
    }
    void Update()
    {
        toggle.powered = on;
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
        if(collision.gameObject.tag == "Player" && Input.GetKey("e") && cooldown <=0)
        {
            flickEffect.Play();
            if (!on)
                on = true; 
            else
                on = false;
            cooldown = 0.25f;
        }
        
        if (collision.gameObject.tag == "Wisp")
            if (!on)
            {
                on = true;
            }
    }
}
