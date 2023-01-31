using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacter : MonoBehaviour
{
    public GameObject normalForm;
    public GameObject spiritForm;
    public GameObject sprite;
    [SerializeField] private GameObject leftBehind;
    public bool IsSpirit;
    [SerializeField] private float shiftCooldown = 5f;

    private Vector3 leftBehindPosition;
    private float shiftTimer = 0f;
    void Start()
    {
        normalForm.SetActive(true);
        spiritForm.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        shiftTimer -= Time.deltaTime;
        if(Input.GetKey("f") && shiftTimer < 0)
        {
            if(normalForm.activeInHierarchy == true )
            {
                Vector3 position = normalForm.transform.position;
                //leftBehind = Instantiate(sprite, position, Quaternion.identity);
                //leftBehindPosition = position;
                normalForm.SetActive(false);
                spiritForm.SetActive(true);
                spiritForm.transform.position = position;
                shiftTimer = shiftCooldown;
            }
            else //if(CheckPosition())
            {
                Vector3 position = spiritForm.transform.position;
                //Destroy(leftBehind);
                normalForm.SetActive(true);
                spiritForm.SetActive(false);
                normalForm.transform.position = position;
                shiftTimer = shiftCooldown;
            }
            
        }
        
    }
    bool CheckPosition() 
    {
        if (Mathf.Abs(leftBehindPosition.x - spiritForm.transform.position.x) < 2f &&
            Mathf.Abs(leftBehindPosition.y - spiritForm.transform.position.y) < 2f)
            return true;
        else
            return false;
    }
}
