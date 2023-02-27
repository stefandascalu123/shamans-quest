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
    [SerializeField] private Camera cam;
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
            earthRenderer.gameObject.layer = 0;
            // cu functie alea alea

            spiritCollider.composite.isTrigger = false;
            spiritRenderer.enabled = true;
            spiritRenderer.gameObject.layer = 6;
        }
        if (manager.isSpirit && earthRenderer.gameObject.GetComponent<CollisionChecker>().inCollider)
            shiftEnabled = false;

        if (!manager.isSpirit && !spiritRenderer.gameObject.GetComponent<CollisionChecker>().inCollider)
        {
            spiritCollider.composite.isTrigger = true;
            spiritRenderer.enabled = false;
            spiritRenderer.gameObject.layer = 0;

            earthCollider.composite.isTrigger = false;
            earthRenderer.enabled = true;
            earthRenderer.gameObject.layer = 6;
        }
        if (!manager.isSpirit && spiritRenderer.gameObject.GetComponent<CollisionChecker>().inCollider)
            shiftEnabled = false;

        if (!earthRenderer.gameObject.GetComponent<CollisionChecker>().inCollider && !spiritRenderer.gameObject.GetComponent<CollisionChecker>().inCollider)
            shiftEnabled = true;
    }
}
