using UnityEngine;
using UnityEngine.AI;

public class EnemyAI: MonoBehaviour {
    #region Variables
    [Header ("Navigation Variables")]
    public Transform[] waypoints;
    private int wayPointIndex = 0;
    public NavMeshAgent agent;

    [Header("Chase Variables")]
    public Transform player;
    public float chaseSpeed;
    public float lookRadius;
    float checkForPlayer = 0;
    public GameObject exclamMark;

    [Header("Attack Variables")]
    public float damage;
    public float range;
    public Camera enemyCamera;
    public float timeBetweenEnemyAttack;
    float timer;
    [Header("Misc")]
    public AudioManager aM;
    #endregion

    void Start () 
   {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        aM = GetComponent<AudioManager>();
        aM = FindObjectOfType<AudioManager>();
    }
	
   void FixedUpdate () 
   {
        timer += Time.deltaTime;

        if (!agent.pathPending && agent.remainingDistance < 2f)
        {
            GoToNextPoint();
        }

        if (player == null)
        {
            FindPlayer();
            return;
        }

        float dist = Vector3.Distance(transform.position, player.position);
        if (dist <= lookRadius) 
        {
            Chase();
            FaceTarget();
            if (dist <= agent.stoppingDistance && timer >= timeBetweenEnemyAttack)
            {
                Attack();
                aM.Play("EnemyAttack");
                FaceTarget();
            }
        }
        else
        {
            exclamMark.SetActive(false);
        }
    }

    public void GoToNextPoint()
    {
        if (waypoints.Length == 0)
            return;
        agent.destination = waypoints[wayPointIndex].position;
        wayPointIndex = Random.Range(0, waypoints.Length);
    }

    void Chase()
    {
        agent.destination = player.position;
        //Debug.Log("Start chase!");
        exclamMark.SetActive(true);
    }

    void Attack()
    {
        agent.destination = player.position;
        timer = 0f;
        RaycastHit hit;
        //Debug.Log("Attack Player!");
        if (Physics.Raycast(enemyCamera.transform.position, enemyCamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Debug.DrawLine(enemyCamera.transform.position, hit.point);
            PlayerHealth Player = hit.transform.GetComponent<PlayerHealth>();
            if (Player != null)
            {
                Player.TakeDamage(damage);
            }
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 5);
    }

    void FindPlayer()
    {
        if (checkForPlayer <= Time.time)
        {
            GameObject searchResult = GameObject.FindGameObjectWithTag("Player");
            if (searchResult != null)
                player = searchResult.transform;
            checkForPlayer = Time.time + 0.5f;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}