using UnityEngine;
using System.Collections;

public class DoorManager_Aidan : MonoBehaviour {

    public ParticleSystem doorParticleEffect;
    
    PETER_PlayerMovement playerRef;
    UIManager_Aidan UI;
    int allyCounter = 0;
    bool allAlliesCollided = false;

    void Start()
    {
        UI = FindObjectOfType<UIManager_Aidan>();
        playerRef = FindObjectOfType<PETER_PlayerMovement>();
    }

    void Update()
    {
        allyCounter = UI.allyCurrentCount;
        if (allyCounter == 20)
        {
            allAlliesCollided = true;
        }
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "Player")
        {
            if (allAlliesCollided)
            {
                FindObjectOfType<GameManager_Aidan>().isDoorBroken = true;
                playerRef.GetComponent<NavMeshAgent>().areaMask = 10011;
                GameObject[] doorSpheres = GameObject.FindGameObjectsWithTag("door");
                if (doorParticleEffect != null)
                {
                    float randomX = Random.Range(85, 95);
                    float randomY = Random.Range(-2, 2);
                    float randomZ = Random.Range(-2, 2);

                    foreach (GameObject removable in doorSpheres)
                    {
                        Destroy(Instantiate(doorParticleEffect, removable.transform.position, Quaternion.Euler(randomX, randomY, randomZ)), 2);
                    }
                }
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerStay(Collider hit)
    {
       if (hit.tag == "Player")
       {
           if (allAlliesCollided)
           {
               FindObjectOfType<GameManager_Aidan>().isDoorBroken = true;
               playerRef.GetComponent<NavMeshAgent>().areaMask = 1001;
                
               Destroy(gameObject);
            }
        }
    }
}
