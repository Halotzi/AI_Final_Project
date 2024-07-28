using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace BehaviorTree
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(AgentVision))]
    [RequireComponent(typeof(AgentHearing))]
    [RequireComponent(typeof(AgentState))]
    
    public class AgentNavigation : BehaviorTree
    {
        [SerializeField] private Transform[] patrolPoints;
        [SerializeField] private Transform target;
        [SerializeField] private Animator animator;
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private AgentVision vision;
        [SerializeField] private AgentHearing hearing;
        [SerializeField] private AgentState agentState;

        protected override Node SetupTree()
        {
            Node die = new DieNode(this, animator,agent, agentState);
            Node patrol = new PatrolNode(agent,animator, patrolPoints, agentState);
            Node chase = new ChaseNode(agent,animator,target,agentState);
            Node attack = new AttackNode(agent,animator,target,agentState);
            Node search = new SearchNode(agent,animator,agentState);

            Node playerDeadCondition = new PlayerDiedNode(agentState);
            Node playerSeenCondition = new PlayerSeenNode(vision);
            Node playerHeardCondition = new PlayerHeardNode(hearing);
            Node playerWasSeenCondition = new PlayerWasSeenNode(agentState);
            Node playerWithinChaseRangeCondition = new PlayerWithinChaseRange(agentState,target);

            return new Selector(new List<Node>
            {
                new Sequence(new List<Node> { playerDeadCondition, die}),
                new Sequence(new List<Node> 
                { 
                    new Selector(new List<Node> { playerSeenCondition, playerHeardCondition }),
                    new Selector(new List<Node> { attack,chase })
                }),
                new Sequence(new List<Node> 
                { 
                    playerWasSeenCondition,
                    search 
                }),
                patrol
            });
        }
    }
}

