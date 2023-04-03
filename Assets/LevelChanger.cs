using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
public class LevelChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject endText;
    public int level;
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
        {
            if(level == 0)
                SceneManager.LoadScene("Level 1");

            if(level == 1)
                endText.SetActive(true);
        }
    }

}
