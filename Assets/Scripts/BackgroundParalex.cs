using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParalex : MonoBehaviour
{
    private float length, startPosition;
    private GameObject cam;
    [SerializeField] private float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("MainCamera");
        startPosition = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startPosition + dist, transform.position.y, transform.position.z);
        //ce e comentat nu merge for some reason
        //codul de mai jos ar fi trebuit sa fie pentru infinite loop axa x, dar nu-i place
        //motiv: nu stiu de ce se face mirror la imagine cand caracterul ia stanga dreapta (nu trebuia sa faca asa)
        //solutie: cine vede asta si rezolva pana imi dau eu seama il pup la interzis uwu


        if(temp> startPosition + length)startPosition += length;
        else if (temp < startPosition - length)startPosition -= length;
    }
}
