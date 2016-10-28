using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(NavMeshAgent))]
public class AllyAI_Aidan : MonoBehaviour {

    //public variables
    [Header("Assign Speech to Here")]
    public List<string> allySaveTextChoices = new List<string>();
    public Transform doorPos;
    public PETER_PlayerMovement playerT;
    //public ParticleSystem disappearEffect;

    [Header("Public Variables")]
    public float waitTime;
    public float fadeTime = 1f;
    public float checkDistance = 3f;
    public float doorCheckDistanceMin = 2f;
    public float doorCheckDistanceMax = 3f;
    public Color textFadeTo;

    //private variables
    Transform childT;
    TextMesh saveTextMesh;
    NavMeshAgent navigator;
    float endWaitTime;
    bool canPress = true;
    bool talkedToAlly = false;
    bool hasBeenTalkedTo = false;
    bool headingToEnd = false;

    void Start()
    {
        childT = transform.FindChild("GameObject");
        //saveTextMesh = childT.GetComponent<TextMesh>();
        navigator = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canPress && !hasBeenTalkedTo && (Vector3.Distance(transform.position, playerT.transform.position) <= checkDistance))
        {
            OnTalkTo();
            canPress = false;
        }

        if (talkedToAlly && endWaitTime <= Time.time)
        {
            OnFinishTalking();
        }

        if (hasBeenTalkedTo)
        {
            print("distance  = " + Vector3.Distance(navigator.destination, transform.position));
            if (Vector3.Distance(navigator.destination, transform.position) <= Random.Range(doorCheckDistanceMin, doorCheckDistanceMax))
            {
                navigator.Stop();
            }
        }

        //if (headingToEnd)
        //{
        //    if ((navigator.destination.x == transform.position.x) && (navigator.destination.z == transform.position.z))
        //    {
        //        //Destroy(Instantiate(disappearEffect, transform.position, transform.rotation), 2);
        //        Destroy(gameObject);
        //    }
        //}
    }

    public void OnTalkTo()
    {
        StartCoroutine(TextFadeIn());
        endWaitTime = Time.time + fadeTime + waitTime;
        talkedToAlly = true;
        transform.LookAt(playerT.transform);
    }

    void OnFinishTalking()
    {
        //saveTextMesh.text = "";
        navigator.SetDestination(doorPos.position);
        canPress = true;
        talkedToAlly = false;
        hasBeenTalkedTo = true;
    }

    public void SetEndDestination(Vector3 position)
    {
        navigator.SetDestination(position);
        headingToEnd = true;
    }

    IEnumerator TextFadeIn()
    {
        float percent = 0;
        //saveTextMesh.text = allySaveTextChoices[(Random.Range(0, allySaveTextChoices.Count))];

        while (percent < 1)
        {
            percent += Time.deltaTime / fadeTime;
            //saveTextMesh.color = Color.Lerp(Color.clear, textFadeTo, percent);
            yield return null;
        }
    }
}
