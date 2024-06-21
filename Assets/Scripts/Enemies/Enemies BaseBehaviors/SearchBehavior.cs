using UnityEngine;

public class SearchBehavior : BaseBehavior
{
    private float searchDuration;
    private float searchStartTime;

    public SearchBehavior(GameObject enemy, Transform player, float searchDuration) : base(enemy, player)
    {
        this.searchDuration = searchDuration;
        this.searchStartTime = Time.time;
    }

    public override void Execute()
    {
        if (Time.time - searchStartTime > searchDuration)
        {
            // Return to patrol or other state
        }
        else
        {
            // Implement search logic
        }
    }
}