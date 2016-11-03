using UnityEngine;
using System.Collections;

public class InvisibleWall_Aidan : MonoBehaviour {

    public GameObject invisibleWall;

    Jailer_Aidan jailer;
    bool activated = false;

    void Start()
    {
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
        jailer.wallTriggered = true;
    }

    void OnTriggerExit(Collider hit)
    {
        jailer.wallTriggered = false;
    }
}
