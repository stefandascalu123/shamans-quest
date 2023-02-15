using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterManager manager;
    public Collider2D coll;
    private Renderer rend;
    void Start()
    {
        //coll = GetComponent<Collider2D>();
        rend = GetComponent<Renderer>();
        coll.enabled = false;
        rend.enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (manager.isSpirit)
        {
            coll.enabled = true;
            rend.enabled = true;
        }
        else
        {
            coll.enabled = false;
            rend.enabled = false;
        }
    }
}
