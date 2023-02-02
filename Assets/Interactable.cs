using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    // Start is called before the first frame update
    CharacterManager characterManager;
    GameObject[] gameObjects;
    void Start()
    {
        gameObjects = GameObject.FindGameObjectsWithTag("Spirit");
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject gameObject in gameObjects)
            gameObject.SetActive(true);

    }
}
