using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spirit : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject normalForm;

    void Start()
    {
        transform.position = normalForm.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
