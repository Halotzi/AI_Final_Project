using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviorManager : MonoBehaviour
{
    public Transform player;
    public Transform[] patrolPoints;
    public float attackRange = 2f;
    public float searchDuration = 5f;
    public float sightRange = 10f;

    private BaseBehavior currentBehavior;
    private NavMeshAgent agent;
    private AlertOthers alertOthers;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        alertOthers = GetComponent<AlertOthers>();
        SetBehavior(new PatrolBehavior(gameObject, player, patrolPoints));
    }

    void Update()
    {
        currentBehavior.Execute();

        if (CanSeePlayer() && Vector3.Distance(transform.position, player.position) > attackRange)
        {
            SetBehavior(new ChaseBehavior(gameObject, player));
            if (alertOthers != null)
            {
                alertOthers.AlertNearbyEnemies(gameObject, player);
            }
        }
        else if (Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            SetBehavior(new AttackBehavior(gameObject, player, attackRange));
        }
        else if (!CanSeePlayer() && currentBehavior.GetType() != typeof(SearchBehavior))
        {
            SetBehavior(new SearchBehavior(gameObject, player, searchDuration));
        }
    }

    public void SetBehavior(BaseBehavior newBehavior)
    {
        currentBehavior = newBehavior;
    }

    bool CanSeePlayer()
    {
        // Implement line of sight check logic
        if (Vector3.Distance(transform.position, player.position) <= sightRange)
        {
            // Add more complex logic here if needed (e.g., field of view, obstacles)
            return true;
        }
        return false;
    }
}