using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    #region Variables
    [Header("Melee Attack Variables")]
    public Camera meleeAttackCamera;
    int layerMask = 1 << 8;

    public float meleeRange;
    public float meleeDamage;
    #endregion

    void Start()
    {
        layerMask = ~layerMask;
    }
    
    void Update()
    {
        if (Input.GetKeyDown("mouse 1"))
        {
            Debug.Log("Melee Attack!");
            MeleeAttack();
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
            }
        }
    }
}
