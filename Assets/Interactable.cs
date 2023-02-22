using UnityEngine;

public class Interactable : MonoBehaviour
{
    // this script is used for every object in the scene which is an interactable or which is influenced by an interactable

    CharacterManager manager;
    // transform of the child (the actual object)
    Transform interactable;

    Collider2D coll;
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterManager>();
        interactable = transform.GetChild(0);
        if (gameObject.tag == "Spirit")
            interactable.gameObject.SetActive(false);

        if (GetComponent<Collider2D>() != null)
            coll = GetComponent<Collider2D>();
    }
    void Update()   
    {
        if (manager.isSpirit)
        {
            if (gameObject.tag == "Spirit")
            { 
                interactable.gameObject.SetActive(true);
                coll.enabled = true;
            }
            else if (gameObject.tag == "Earth")
            {
                interactable.gameObject.SetActive(false);
                coll.enabled = false;
            }
        }
        else
        {
            if (gameObject.tag == "Spirit")
            {
                interactable.gameObject.SetActive(false);
                coll.enabled = false;
            }
            else if (gameObject.tag == "Earth")
            {
                interactable.gameObject.SetActive(true);
                coll.enabled = true;
            }
        }
    }
}
