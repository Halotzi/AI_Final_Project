using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviorHandler : MonoBehaviour
{
    [SerializeField]private NavMeshAgent agent;

    public Transform[] patrolPoints;
    public float attackRange = 2f;
    public float searchDuration = 5f;
    public float sightRange = 10f;

    private Transform _playerTaTransform;
    private BaseBehavior currentBehavior;
    private AlertOthers alertOthers;

    void Start()
    {
        _playerTaTransform = GameManager.Instance.PlayerManager.transform;
        alertOthers = new AlertOthers();
        SetBehavior(new PatrolBehavior(gameObject, _playerTaTransform, patrolPoints));
    }

    void Update()
    {
        currentBehavior.Execute();

        if (CanSeePlayer() && Vector3.Distance(transform.position, _playerTaTransform.position) > attackRange)
        {
            SetBehavior(new ChaseBehavior(gameObject, _playerTaTransform));
            if (alertOthers != null)
            {
                alertOthers.AlertNearbyEnemies(gameObject, _playerTaTransform);
            }
        }
        else if (Vector3.Distance(transform.position, _playerTaTransform.position) <= attackRange)
        {
            SetBehavior(new AttackBehavior(gameObject, _playerTaTransform, attackRange));
        }
        else if (!CanSeePlayer() && currentBehavior.GetType() != typeof(SearchBehavior))
        {
            SetBehavior(new SearchBehavior(gameObject, _playerTaTransform, searchDuration));
        }
    }

    public void SetBehavior(BaseBehavior newBehavior)
    {
        currentBehavior = newBehavior;
    }

    bool CanSeePlayer()
    {
        // Implement line of sight check logic
        if (Vector3.Distance(transform.position, _playerTaTransform.position) <= sightRange)
        {
            // Add more complex logic here if needed (e.g., field of view, obstacles)
            return true;
        }
        return false;
    }
}