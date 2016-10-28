using UnityEngine;
using System.Collections;

public class GameManager_Aidan : MonoBehaviour {

    public GameObject bossDoor;
    public Transform bossDoorLocation;
    public Transform allyLeaveLocation1;
    public Transform allyLeaveLocation2;

    [HideInInspector]
    public bool isDoorBroken = false;



    void Awake()
    {
        Instantiate(bossDoor, bossDoorLocation.position, bossDoorLocation.rotation);
    }

    void Update()
    {
        if (isDoorBroken)
        {
            AllyAI_Aidan[] allAllies = FindObjectsOfType<AllyAI_Aidan>();

            for (int i = 0; i < allAllies.Length; i++)
            {
                if (i % 2 == 0)
                {
                    allAllies[i].SetEndDestination(allyLeaveLocation1.position);
                }
                else
                {
                    allAllies[i].SetEndDestination(allyLeaveLocation2.position);
                }
            }

            isDoorBroken = false;
        }
    }
}
