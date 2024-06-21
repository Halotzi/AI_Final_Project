using UnityEngine;

[CreateAssetMenu(fileName = "EnemySettings", menuName = "ScriptableObjects/EnemySettings", order = 1)]
public class EnemySettings : ScriptableObject
{
    public float patrolSpeed;
    public float chaseSpeed;
    public float sightRange;
    public float sightAngle;
    public float attackRange;
    public float hearingRange;
    public float searchDuration;
}