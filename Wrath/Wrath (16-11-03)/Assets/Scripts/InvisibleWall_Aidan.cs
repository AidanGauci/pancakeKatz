using UnityEngine;
using System.Collections;

public class InvisibleWall_Aidan : MonoBehaviour {

    public GameObject invisibleWall;

    Jailer_Aidan jailer;
    UIManager_Aidan UI;

    void Start()
    {
        UI = FindObjectOfType<UIManager_Aidan>();
        jailer = FindObjectOfType<Jailer_Aidan>();
    }

    void Update()
    {
        if (jailer.swordTaken)
        {
            Destroy(transform.parent.gameObject);
        }
    }

	void OnTriggerEnter(Collider hit)
    {
        print("hitting tutorial trigger");
        if (hit.tag == "Player")
        {
            jailer.wallTriggered = true;
            UI.wallTriggered = true;
        }
    }

    void OnTriggerExit(Collider hit)
    {
        print("hitting tutorial trigger");
        if (hit.tag == "Player")
        {
            jailer.wallTriggered = false;
            UI.wallTriggered = false;
        }
    }
}
