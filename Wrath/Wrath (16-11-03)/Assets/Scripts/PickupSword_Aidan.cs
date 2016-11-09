using UnityEngine;
using System.Collections;

public class PickupSword_Aidan : MonoBehaviour {

    [HideInInspector]
    public bool isSwordTaken;
    public float checkDistance = 1f;

    PETER_PlayerMovement playerRef;
    UIManager_Aidan UI;

    void Start()
    {
        playerRef = FindObjectOfType<PETER_PlayerMovement>();
        UI = FindObjectOfType<UIManager_Aidan>();
    }

	void Update ()
    {
	    if (!isSwordTaken)
        {
            if (CircleCircleCheck(transform.position, 1, playerRef.transform.position, checkDistance))
            {
                UI.swordText.text = "Press 'E' to pick up sword";
                UI.swordText.gameObject.SetActive(true);
                UI.swordTextBackground.gameObject.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    isSwordTaken = true;
                    UI.swordText.gameObject.SetActive(false);
                    UI.swordTextBackground.gameObject.SetActive(false);
                }
            }
            else if (CircleCircleCheck(transform.position, 1, playerRef.transform.position, checkDistance))
            {
                UI.swordText.text = "";
                UI.swordText.gameObject.SetActive(false);
                UI.swordTextBackground.gameObject.SetActive(false);
            }
        }
        else if (isSwordTaken)
        {
            Transform camX = playerRef.transform.FindChild("CamX");
            Transform pickaxe = camX.FindChild("Pickaxe");
            Transform sword = camX.FindChild("Sword");

            playerRef.TutorialDone();

            pickaxe.gameObject.SetActive(false);
            sword.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    bool CircleCircleCheck(Vector3 P1, float R1, Vector3 P2, float R2)
    {
        return ((P1 - P2).sqrMagnitude < ((R1 * R1) + (R1 * R2)));
    }
}
