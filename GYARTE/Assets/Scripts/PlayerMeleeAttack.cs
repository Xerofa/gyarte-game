using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    #region Variables
    [Header("Melee Attack Variables")]
    public Camera meleeAttackCamera;
    int layerMask = 1 << 8;
    public GameObject hitParticles;
    public float meleeRange;
    public float meleeDamage;
    public int ammoWhenHitEnemy;
    [Header("Misc")]
    public AudioManager aM;

    #endregion

    void Start()
    {
        layerMask = ~layerMask;
        aM = GetComponent<AudioManager>();
        aM = FindObjectOfType<AudioManager>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown("mouse 1"))
        {
            MeleeAttack();
            aM.Play("PlayerMeleeAttack");
        }
    }


    void MeleeAttack()
    {
        RaycastHit hit;
        if (Physics.Raycast(meleeAttackCamera.transform.position, meleeAttackCamera.transform.forward, out hit, meleeRange, layerMask))
        {
            Debug.Log(hit.transform.name);
            EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(meleeDamage);
                if (hit.transform.tag == ("Enemy"))
                {
                    GameObject hitParticlesIns = Instantiate(hitParticles, hit.point, Quaternion.identity);
                    Destroy(hitParticlesIns, .5f);
                    //Få ammo!
                    PlayerRangedAttack.currentAmmo = 5;
                    Debug.Log("You received " + PlayerRangedAttack.currentAmmo + " shots from MeleeAttack");
                }
            }
        }
    }
}
