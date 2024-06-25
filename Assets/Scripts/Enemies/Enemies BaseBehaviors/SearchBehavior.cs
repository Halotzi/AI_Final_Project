using UnityEngine;
using UnityEngine.AI;

public class SearchBehavior : BaseBehavior
{
    private float _startingSearchStartTime;

    public SearchBehavior(BaseEnemy enemy, Transform player, EnemySettings settings,NavMeshAgent agent, Animator animator) 
        : base(enemy, player, settings,agent, animator)
    {
        _startingSearchStartTime = Time.time;
    }

    public override void Execute()
    {
        if (Time.time - _startingSearchStartTime > _settings.searchDuration)
        {
            // Return to patrol or other state
        }
        else
        {
            // Implement search logic
        }
    }
}