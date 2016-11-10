using UnityEngine;
using System.Collections;

public class PETER_CursorManager : MonoBehaviour
{

	void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = !Cursor.visible;
        }

        if (Cursor.visible)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

}
