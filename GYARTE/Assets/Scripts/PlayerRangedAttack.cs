using UnityEngine;
using UnityEngine.UI;

public class PlayerRangedAttack: MonoBehaviour {
    #region Variables
    [Header("Ranged Attack Variables")]
    public Camera rangedAttackCamera;
    int layerMask = 1 << 8;
    public float range;
    public float damage; 
    public Transform rangedAttackTrailPrefab;
    public Transform firePoint;
    public GameObject muzzleFlash;
    public GameObject hitParticles;
    float timer;
    public float timeBetweenShots;
    public int maxAmmo;
    public static int currentAmmo;
    [Header("UI STUFF")]
    public Text ammoText;
    #endregion

    void Start()
    {
        layerMask = ~layerMask;
        currentAmmo = maxAmmo;
        ammoText = GameObject.Find("AmmoText").GetComponent<Text>();
        ammoText.text = "Ammo: " + currentAmmo.ToString();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (currentAmmo <= 0)
            return;
        if (Input.GetKeyDown("mouse 0") && timer >= timeBetweenShots)
        {
            RangedAttack();
        }
        ammoText.text = "Ammo: " + currentAmmo.ToString();
    }
  
      void RangedAttack()
      {
        timer = 0f;
        currentAmmo--;
        Debug.Log(currentAmmo);
        RaycastHit hit;
        LineEffect();
        MuzzleFlash();
        if (Physics.Raycast(rangedAttackCamera.transform.position, rangedAttackCamera.transform.forward, out hit, range, layerMask))
        {
            Debug.Log(hit.transform.name);
            Debug.DrawLine(firePoint.position, hit.point, Color.red);
            EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                if (hit.transform.tag == ("Enemy"))
                {
                    GameObject hitParticlesIns = Instantiate(hitParticles, hit.point, Quaternion.identity);
                    Destroy(hitParticlesIns, .5f);
                    currentAmmo = maxAmmo;
                    //Debug.Log(currentAmmo);
                    //Debug.Log("You received " + currentAmmo + " shots from RangedAttack");
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