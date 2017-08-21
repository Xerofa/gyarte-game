using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangedAttack: MonoBehaviour {
    #region Variables
    [Header("Ranged Attack Variables")]
    public Camera rangedAttackCamera;

    public float range;
    public float damage;
  
    public Transform rangedAttackTrailPrefab;
    public Transform firePoint;
 

    public GameObject muzzleFlash;
    public GameObject hitParticles;

    float timer;
    public float timeBetweenShots;

    #endregion
    void Start()
    {

    }

    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetKeyDown("mouse 0") && timer >= timeBetweenShots)
        {
            Debug.Log("Ranged Attack!");
            RangedAttack();
        }
    }

   
  
     // En raycast skjuts ut som letar efter något objekt med "TargetHit"!
      void RangedAttack()
      {
        timer = 0f;
        RaycastHit hit;
        LineEffect();
        MuzzleFlash();



        if (Physics.Raycast(rangedAttackCamera.transform.position, rangedAttackCamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Debug.DrawLine(firePoint.position, hit.point);
            EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                if (hit.transform.tag == ("Enemy"))
                {
                    GameObject hitParticlesIns = Instantiate(hitParticles, hit.point, Quaternion.identity);
                    Destroy(hitParticlesIns, .5f);
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