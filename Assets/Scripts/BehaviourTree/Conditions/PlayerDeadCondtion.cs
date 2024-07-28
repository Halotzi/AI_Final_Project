using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class PlayerDiedNode : Node
    {
        private AgentState agentState;

        public PlayerDiedNode(AgentState agentState)
        {
            this.agentState = agentState;
        }

        public override NodeState Evaluate()
        {
            if (agentState.health<=0)
            {
                state = NodeState.SUCCESS;
            }
            else
            {
                state = NodeState.FAILURE;
            }
            return state;
        }
    }
}
