using UnityEngine;
using UnityEngine.AI;

public class ChaseBehavior : BaseBehavior
{
    private NavMeshAgent agent;

    public ChaseBehavior(BaseEnemy enemy, Transform player, EnemySettings settings,NavMeshAgent agent, Animator animator) 
        : base(enemy, player, settings,agent, animator)
    {
        agent.speed = settings.chaseSpeed; 
    }

    public override void Execute()
    {
        agent.destination = _player.position;
    }
}