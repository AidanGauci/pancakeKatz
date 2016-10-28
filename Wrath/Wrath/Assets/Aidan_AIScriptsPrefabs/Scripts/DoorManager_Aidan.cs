using UnityEngine;
using System.Collections;

public class DoorManager_Aidan : MonoBehaviour {

    [HideInInspector]
    public DoorPlatform_Aidan[] allDoorPlatforms;
    public ParticleSystem doorParticleEffect;

    PETER_PlayerMovement playerRef;
    int boolCounter = 0;

    void Start()
    {
        allDoorPlatforms = FindObjectsOfType<DoorPlatform_Aidan>();
        playerRef = FindObjectOfType<PETER_PlayerMovement>();
    }

    void OnTriggerEnter(Collider hit)
    {
        print("has collided");
        if (hit.tag == "Player")
        {
            boolCounter = 0;
            for (int i = 0; i < allDoorPlatforms.Length; i++)
            {
                if (allDoorPlatforms[i].isStoodOn)
                {
                    print("isStoodOn");
                    boolCounter++;
                }
            }

            if (boolCounter == allDoorPlatforms.Length)
            {
                FindObjectOfType<GameManager_Aidan>().isDoorBroken = true;
                //Destroy(Instantiate(doorParticleEffect, transform.position, Quaternion.identity), 2);
                Destroy(gameObject);
            }
        }
    }

    public void SetAllyDestination(Vector3 position)
    {
        AllyAI_Aidan[] allAllies = FindObjectsOfType<AllyAI_Aidan>();
        for (int i = 0; i < allAllies.Length; i++)
        {
            allAllies[i].SetEndDestination(position);
        }
    }
}
