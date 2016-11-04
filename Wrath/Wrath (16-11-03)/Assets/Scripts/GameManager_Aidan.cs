using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager_Aidan : MonoBehaviour {

    [HideInInspector]
    public bool isDoorBroken = false;
    [HideInInspector]
    public bool loadedAnotherScene = false;

    EndRoomAllyLocations_Aidan endRoomLocations;
    AllyAI_Aidan[] allAllies;

    void Start()
    {
        endRoomLocations = FindObjectOfType<EndRoomAllyLocations_Aidan>();
        allAllies = FindObjectsOfType<AllyAI_Aidan>();
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (isDoorBroken)
        {
            for (int i = 0; i < allAllies.Length; i++)
            {
                 int modNum = i % endRoomLocations.allEndAllyLocations.Length;
                 SetEndDestination(i, modNum);
            }

            isDoorBroken = false;
        }
    }

    void SetEndDestination(int i, int modNum)
    {
        allAllies[i].SetEndDestination(endRoomLocations.allEndAllyLocations[modNum].position);
    }

    public void HasHitEndBox()
    {
        loadedAnotherScene = true;
        SceneManager.LoadScene("EndGameScene");
    }
}
