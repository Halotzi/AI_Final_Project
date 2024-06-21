using UnityEngine;
using UnityEngine.AI;

public class ChaseBehavior : BaseBehavior
{
    private NavMeshAgent agent;

    public ChaseBehavior(GameObject enemy, Transform player) : base(enemy, player)
    {
        this.agent = enemy.GetComponent<NavMeshAgent>();
    }

    public override void Execute()
    {
        agent.destination = player.position;
    }
}