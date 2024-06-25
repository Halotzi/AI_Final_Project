using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviorHandler : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private EnemySettings settings;  // Reference to the EnemySettings ScriptableObject
    [SerializeField] private Transform[] patrolPoints;

    private Animator _animator;
    private BaseEnemy _enemy;
    private Transform player;
    private BaseBehavior currentBehavior;
    private AlertOthers alertOthers;

    void Update()
    {
        if (currentBehavior==null)
            return;
        
        currentBehavior.Execute();

        if (ShouldChasePlayer())
        {
            if(currentBehavior is ChaseBehavior)
                return;
            
            SetBehavior(new ChaseBehavior(_enemy, player, settings,agent,_animator));
            alertOthers.AlertNearbyEnemies(_enemy, player, settings);
        }
        else if (ShouldAttackPlayer())
        {
            if(currentBehavior is AttackBehavior)
                return;
            
            SetBehavior(new AttackBehavior(_enemy, player, settings.attackRange, settings,agent,_animator));
        }
        else if (ShouldSearchPlayer())
        {
            if(currentBehavior is SearchBehavior)
                return;
            
            SetBehavior(new SearchBehavior(_enemy, player, settings,agent, _animator));
        }
    }


    public void InitData(BaseEnemy enemy,Animator animator)
    {
        _enemy = enemy;
        _animator = animator;
        player = GameManager.Instance.PlayerManager.transform;
        alertOthers = new AlertOthers(settings.alertRange);
        agent.speed = settings.patrolSpeed;  // Set initial speed to patrol speed
        SetBehavior(new PatrolBehavior(_enemy, player, patrolPoints, settings,agent,animator));
    }
    
    public void SetBehavior(BaseBehavior newBehavior)
    {
        currentBehavior = newBehavior;
    }

    private bool CanSeePlayer()
    {
        if (Vector3.Distance(transform.position, player.position) <= settings.sightRange)
        {
            return true;
        }
        return false;
    }

    private bool ShouldChasePlayer()
    {
        if (CanSeePlayer() && Vector3.Distance(transform.position, player.position) > settings.attackRange)
            return true;

        return false;
    }
    
    private bool ShouldAttackPlayer()
    {
        if (Vector3.Distance(transform.position, player.position) <= settings.attackRange)
            return true;

        return false;
    }
    
    private bool ShouldSearchPlayer()
    {
        if (!CanSeePlayer() && currentBehavior.GetType() != typeof(SearchBehavior))
            return true;

        return false;
    }
}