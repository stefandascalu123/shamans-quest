using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LevelChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text endText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (transform.parent.GetComponent<Switchable>().open && collider.gameObject.tag == "Player")
            endText.enabled = true;
    }

}
