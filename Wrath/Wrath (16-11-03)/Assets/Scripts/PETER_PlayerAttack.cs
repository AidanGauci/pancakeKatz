using UnityEngine;
using System.Collections;

public class PETER_PlayerAttack : MonoBehaviour
{

    public Transform Weapon;
    public Transform WeaponPointer;
    public Transform AnglePointer;
    public bool hasWeapon;
    public float swingSpeed;
    public float attackTime;


    // ENUM FOR ATTACK STATE
    public enum attackState
    {
        notAttacking,
        beginSwing,
        midSwing,
        endSwing
    }
    public attackState currState;


    private float timer;


	// Use this for initialization
	void Start ()
    {
        hasWeapon = true;
        currState = attackState.notAttacking;
        timer = 0.0f;

        Weapon.position = WeaponPointer.position;
        ///Weapon.rotation = WeaponPointer.rotation;
    }


    // Update is called once per frame
    void Update()
    {

        Debug.Log(currState);


        // NOT ATTACKING STATE
        if (currState == attackState.notAttacking)
        {
            if (Input.GetMouseButtonDown(0))
            {
                currState = attackState.beginSwing;
                timer = 0.0f;
            }
        }
        
        // BEGIN SWING STATE
        else if (currState == attackState.beginSwing)
        {
            timer += Time.deltaTime * swingSpeed;
            Weapon.position = Vector3.Lerp(WeaponPointer.position, AnglePointer.position, timer);
            ///Weapon.rotation = Quaternion.Lerp(WeaponPointer.rotation, AnglePointer.rotation, timer);
            if (timer >= 1)
            {
                Weapon.position = AnglePointer.position;
                ///Weapon.rotation = AnglePointer.rotation;
                currState = attackState.midSwing;
                timer = 0.0f;
            }
        }
        
        // MID SWING STATE
        else if (currState == attackState.midSwing)
        {
            timer += Time.deltaTime * attackTime;
            if (timer >= 1)
            {
                currState = attackState.endSwing;
                timer = 0.0f;
            }
        }
        
        // END SWING STATE
        else if (currState == attackState.endSwing)
        {
            timer += Time.deltaTime * swingSpeed;
            Weapon.position = Vector3.Lerp(AnglePointer.position, WeaponPointer.position, timer);
            ///Weapon.rotation = Quaternion.Lerp(AnglePointer.rotation, WeaponPointer.rotation, timer);
            if (timer >= 1)
            {
                Weapon.position = WeaponPointer.position;
                ///Weapon.rotation = WeaponPointer.rotation;
                currState = attackState.notAttacking;
                timer = 0.0f;
            }
        }


    }

}
