using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhispScript : MonoBehaviour
{
    public GameObject[] wispPositions;
    int nextPosition = 0;

    private bool shouldLerp = false;

    public float timeStartedLerping;
    public float lerpTime;

    private Vector3 start;
    private Vector3 stop;
    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
        stop = wispPositions[nextPosition].transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(shouldLerp){
            transform.position = Lerp(start, stop, timeStartedLerping, lerpTime);

            if(Vector3.Distance(transform.position, stop) == 0){
                start = stop;
                if(nextPosition != wispPositions.Length - 1)
                    nextPosition++;
                stop = wispPositions[nextPosition].transform.position;
                gameObject.GetComponent<Collider2D>().enabled = true;
                shouldLerp = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player")){
            if(nextPosition == (wispPositions.Length - 1)){
                    Destroy(gameObject);
            }else{
                StartLerping();
            }
        }
    }

    private void StartLerping(){
        timeStartedLerping = Time.time;
        gameObject.GetComponent<Collider2D>().enabled = false;

        shouldLerp = true;
    } 

    public Vector3 Lerp(Vector3 start, Vector3 end, float timeStartedLerping, float lerpTime = 1)
    {
        float timeSinceStarted = Time.time - timeStartedLerping;

        float percentageComplete = timeSinceStarted / lerpTime;

        var result = Vector3.Lerp(start, end, percentageComplete);

        return result;
    }
}
