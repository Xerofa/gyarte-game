using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour {
    #region Variables
    [Header("Melee Attack Variables")]
    public Camera meleeAttackCamera;

    public float meleeRange;
    public float meleeDamage;

    [Header("Ranged Attack Variables")]
    public Camera rangedAttackCamera;

    public float rangedRange;
    public float rangedDamage;


#endregion


    void Start () 
	{

	}
	
	void FixedUpdate () 
	{

        if (Input.GetKeyDown("mouse 1"))
        {  
            Debug.Log("Melee Attack!");
            MeleeAttack();
        }

        if(Input.GetKeyDown("mouse 0"))
        {
            Debug.Log("Ranged Attack!");
            RangedAttack();
        }
	}

    void MeleeAttack()
    {
        RaycastHit hit;
        if(Physics.Raycast(meleeAttackCamera.transform.position, meleeAttackCamera.transform.forward, out hit, meleeRange))
        {
            Debug.Log(hit.transform.name);

            TargetHit target = hit.transform.GetComponent<TargetHit>();
            if(target != null)
            {
                target.TakeDamage(meleeDamage);
            }
        }
    }

    void RangedAttack()
    {
        RaycastHit hit;
        if (Physics.Raycast(rangedAttackCamera.transform.position, rangedAttackCamera.transform.forward, out hit, rangedRange))
        {
            Debug.Log(hit.transform.name);

            TargetHit target = hit.transform.GetComponent<TargetHit>();
            if(target != null)
            {
                target.TakeDamage(rangedDamage);
            }
        }

    }
}
