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
    public float attackDist;
    public float chaseDist;
    public float stopChaseDist;

    [Header("Attack Variables")]
    public float damage;
    public float range;
    public Camera enemyCamera;
    public float timeBetweenEnemyAttack;
    float timer;
    #endregion

    void Start () 
   {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
   }
	
   void Update () 
   {
        timer += Time.deltaTime;

        if(!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GoToNextPoint();
        }

        if (player.position == null)
            return;

        if (Vector3.Distance(transform.position, player.position) >= chaseDist && Vector3.Distance(transform.position, player.position) < stopChaseDist)
        {
            Chase();
        }

        if (Vector3.Distance(transform.position,player.position) <= attackDist && timer >= timeBetweenEnemyAttack)
        {
            Attack();
        }
   }

    public void GoToNextPoint()
    {
        if (waypoints.Length == 0)
            return;
        agent.destination = waypoints[wayPointIndex].position;
        wayPointIndex = (wayPointIndex + 1) % waypoints.Length;
    }

    void Chase()
    {
        transform.LookAt(player);
        transform.position += transform.forward * chaseSpeed * Time.deltaTime;
        //Debug.Log("Start chase!");
    }

    void Attack()
    {
        timer = 0f;
        RaycastHit hit;
        transform.LookAt(player);
        //Debug.Log("Attack Player!");
        if (Physics.Raycast(enemyCamera.transform.position, enemyCamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Debug.DrawLine(enemyCamera.transform.position, hit.point);
            PlayerHealth Player = hit.transform.GetComponent<PlayerHealth>();
            if (Player != null)
            {
                Player.TakeDamage(damage);
                Debug.Log("Player is attacked!");
            }
        }
    }
}