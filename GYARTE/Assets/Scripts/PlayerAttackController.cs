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

    public Transform rangedAttackTrailPrefab;
    public Transform firePoint;

    public GameObject muzzleFlash;
    public ParticleSystem hitParticles;
    #endregion
	
	void Update () 
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
            EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();
            if(enemy != null)
            {
                enemy.TakeDamage(meleeDamage);
            }
        }
    }

    // En raycast skjuts ut som letar efter något objekt med "TargetHit"!
    void RangedAttack()
    {
        RaycastHit hit;
        LineEffect();
        MuzzleFlash();
        if (Physics.Raycast(rangedAttackCamera.transform.position, rangedAttackCamera.transform.forward, out hit, rangedRange))
        {
            Debug.Log(hit.transform.name);
            EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();
            if(enemy != null)
            {
                enemy.TakeDamage(rangedDamage);
                if (hit.transform.tag == ("Enemy"))
                {
                    Instantiate(hitParticles, hit.point, Quaternion.identity);
                }
            }
        }
    }

    void LineEffect()
    {
        Instantiate(rangedAttackTrailPrefab, firePoint.position, firePoint.rotation);
    }

    void MuzzleFlash()
    {
        GameObject muzzleFlashIns = Instantiate(muzzleFlash, firePoint.position, muzzleFlash.transform.rotation);
        Destroy(muzzleFlashIns , .5f);
    }
}
