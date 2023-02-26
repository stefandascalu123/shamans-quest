using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterManager manager;
    public Renderer spiritRenderer;
    public Renderer earthRenderer;
    public Collider2D spiritCollider;
    public Collider2D earthCollider;
    public bool shiftEnabled = true;
    private bool inWalls;
    void Start()
    {
       
    }


    // Update is called once per frame
    void Update()
    {
        if (manager.isSpirit && !earthRenderer.gameObject.GetComponent<CollisionChecker>().inCollider)
        {
            earthCollider.composite.isTrigger = true;
            earthRenderer.enabled = false;

            spiritCollider.composite.isTrigger = false;
            spiritRenderer.enabled = true;
        }
        else if (manager.isSpirit && earthRenderer.gameObject.GetComponent<CollisionChecker>().inCollider)
            shiftEnabled = false;

        else if (!manager.isSpirit && !spiritRenderer.gameObject.GetComponent<CollisionChecker>().inCollider)
        {
            spiritCollider.composite.isTrigger = true;
            spiritRenderer.enabled = false;

            earthCollider.composite.isTrigger = false;
            earthRenderer.enabled = true;
        }
        else if (!manager.isSpirit && spiritRenderer.gameObject.GetComponent<CollisionChecker>().inCollider)
            shiftEnabled = false;
        else
            shiftEnabled = true;
    }
}
