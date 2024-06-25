using UnityEngine;
using UnityEngine.AI;

public class PatrolBehavior : BaseBehavior
{
    private Transform[] _patrolPoints;
    public int LastPatrolIndex { get; private set; } = 0;

    public PatrolBehavior(BaseEnemy enemy, Transform player, Transform[] patrolPoints, EnemySettings settings, NavMeshAgent agent, Animator animator, int patrolIndex) 
        : base(enemy, player, settings,agent, animator)
    {
        _agent = agent;
        _patrolPoints = patrolPoints;
        LastPatrolIndex = patrolIndex;
        _animator.SetTrigger("Chase");
        _agent.destination = _patrolPoints[LastPatrolIndex].position;
    }

    public override void Execute()
    {
        if (_agent.remainingDistance <= _agent.stoppingDistance)
        {
            LastPatrolIndex = (LastPatrolIndex + 1) % _patrolPoints.Length;
            _agent.destination = _patrolPoints[LastPatrolIndex].position;
        }
    }
}