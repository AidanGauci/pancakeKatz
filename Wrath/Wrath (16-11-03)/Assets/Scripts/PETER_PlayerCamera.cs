using UnityEngine;
using System.Collections;

public class PETER_PlayerCamera : MonoBehaviour
{

    public Transform CamX;
    public Transform CamY;

    public float mouseSens;     // how much the camera moves from mouse movement
    public float camMoveLimit;  // maximum amount the camera can move in a frame
    public float camVertLimit;  // angle from the top and bottom past which the camera cannot move

	// Use this for initialization
	void Start ()
    {
        // Clamps all public variables to reasonable limits
        mouseSens = Mathf.Clamp(mouseSens, 0, 1000);
        camVertLimit = Mathf.Clamp(camVertLimit, 0, 89);
        camMoveLimit = Mathf.Clamp(camMoveLimit, 0, 150);
    }
	
	// Update is called once per frame
	void Update ()
    {

        // Calculates x and y rotation amount based on mouse movement
        float xRot = Mathf.Clamp(Input.GetAxis("Mouse X") * Time.deltaTime * mouseSens, -camMoveLimit, camMoveLimit);
        float yRot = Mathf.Clamp(-Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSens, -camMoveLimit, camMoveLimit);


        // Apply the x rotation to the camera
        CamX.transform.Rotate(0, xRot, 0);


        if (yRot > 0)
        {
            if (CamY.transform.eulerAngles.x + yRot <= 90 - camVertLimit
                || CamY.transform.eulerAngles.x + yRot >= 90 - camVertLimit + camMoveLimit + 1)
            {
                CamY.transform.Rotate(yRot, 0, 0);
            }
            else if (CamY.transform.eulerAngles.x <= 90 - camVertLimit)
            {
                CamY.transform.Rotate(90 - camVertLimit - GameObject.Find("CamY").transform.eulerAngles.x, 0, 0);
            }
        }

        else if (yRot < 0)
        {
            if (CamY.transform.eulerAngles.x + yRot >= 270 + camVertLimit
                || CamY.transform.eulerAngles.x + yRot <= 270 + camVertLimit - camMoveLimit - 1)
            {
                CamY.transform.Rotate(yRot, 0, 0);
            }
            else if (CamY.transform.eulerAngles.x >= 270 + camVertLimit)
            {
                CamY.transform.Rotate(270 + camVertLimit - GameObject.Find("CamY").transform.eulerAngles.x, 0, 0);
            }
        }
    }

}
