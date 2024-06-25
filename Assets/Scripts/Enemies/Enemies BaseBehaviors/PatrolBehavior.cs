using UnityEngine;
using UnityEngine.AI;

public class PatrolBehavior : BaseBehavior
{
    private NavMeshAgent agent;
    private Transform[] patrolPoints;
    private int patrolIndex = 0;

    public PatrolBehavior(BaseEnemy enemy, Transform player, Transform[] patrolPoints, EnemySettings settings, NavMeshAgent agent, Animator animator) 
        : base(enemy, player, settings,agent, animator)
    {
        this.agent = enemy.GetComponent<NavMeshAgent>();
        this.patrolPoints = patrolPoints;
    }

    public override void Execute()
    {
        if (agent.remainingDistance < agent.stoppingDistance)
        {
            patrolIndex = (patrolIndex + 1) % patrolPoints.Length;
            agent.destination = patrolPoints[patrolIndex].position;
        }
    }
}