using UnityEngine;
using System.Collections;

public class Jailer_Aidan : MonoBehaviour {

    [HideInInspector]
    public bool swordTaken = false;
    [HideInInspector]
    public bool wallTriggered = false;

    public string onFirstSight;
    public string afterSword;
    public float checkDistance = 1f;
    public float textWaitTime = 1f;

    PETER_PlayerMovement playerRef;
    Transform mainCamera;
    float turnOffText;
    bool isAngryTextOn = false;

    void Start()
    {
        playerRef = FindObjectOfType<PETER_PlayerMovement>();
        mainCamera = Camera.main.transform;
    }

    void Update()
    {
        if (!swordTaken)
        {
            if (wallTriggered)
            {
                //myText.text = onfirstsight;
                transform.LookAt(mainCamera);
                transform.Rotate(Vector3.up, 180);
            }
            else if (!wallTriggered)
            {
                //myText.text = "";
            }
        }
        else if (swordTaken && !isAngryTextOn)
        {
            playerRef.TutorialDone();
            //
            transform.LookAt(mainCamera);
            transform.Rotate(Vector3.up, 180);
            isAngryTextOn = true;
            turnOffText = Time.time + textWaitTime;
        }

        else if (isAngryTextOn && turnOffText > Time.time)
        {
            transform.LookAt(mainCamera);
            transform.Rotate(Vector3.up, 180);
        }

        else if (turnOffText < Time.time)
        {
            //myText.text = "";
        }
    }
}
