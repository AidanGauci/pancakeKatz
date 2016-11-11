using UnityEngine;
using System.Collections;

public class PickupSword_Aidan : MonoBehaviour
{
    [HideInInspector]
    public bool isSwordTaken;
    public float checkDistance = 1f;
    public float textBoxTime = 2f;
    public string toSay;

    PETER_PlayerAttack playerRef;
    UIManager_Aidan UI;
    bool timeSet = false;
    bool instructionDone = false;
    float currentWaitTime;

    void Start()
    {
        playerRef = FindObjectOfType<PETER_PlayerAttack>();
        UI = FindObjectOfType<UIManager_Aidan>();
    }

	void Update ()
    {
	    if (!isSwordTaken)
        {
            if (CircleCircleCheck(transform.position, 1, playerRef.transform.position, checkDistance))
            {
                UI.swordText.text = "Press E to pickup Sword";
                UI.swordText.gameObject.SetActive(true);
                UI.swordTextBackground.gameObject.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    isSwordTaken = true;
                    UI.swordText.gameObject.SetActive(false);
                    UI.swordTextBackground.gameObject.SetActive(false);

                    Transform Model = playerRef.transform.FindChild("Model");
                    Transform pickaxe = Model.FindChild("PickaxeMesh");
                    Transform sword = Model.FindChild("SwordMesh");

                    pickaxe.gameObject.SetActive(false);
                    sword.gameObject.SetActive(true);
                    playerRef.hasWeapon = true;

                    gameObject.SetActive(false);

                    Debug.Log("TUTORIAL COMPLETE");
                    playerRef.GetComponent<NavMeshAgent>().areaMask = 10001;
                }
            }
            else if (!CircleCircleCheck(transform.position, 1, playerRef.transform.position, checkDistance) && !UI.wallTriggered)
            {
                UI.swordText.gameObject.SetActive(false);
                UI.swordTextBackground.gameObject.SetActive(false);
            }
        }
        else
        {
            if (timeSet && !instructionDone)
            {
                if (currentWaitTime <= Time.time)
                {
                    UI.swordText.gameObject.SetActive(false);
                    UI.swordTextBackground.gameObject.SetActive(false);
                    instructionDone = true;
                }
            }
            else if (!timeSet && !instructionDone)
            {
                currentWaitTime = Time.time + textBoxTime;
                timeSet = true;
                UI.swordText.gameObject.SetActive(true);
                UI.swordTextBackground.gameObject.SetActive(true);
                UI.swordText.text = toSay;
            }
        }
    }

    bool CircleCircleCheck(Vector3 P1, float R1, Vector3 P2, float R2)
    {
        return ((P1 - P2).sqrMagnitude < ((R1 * R1) + (R1 * R2)));
    }
}
