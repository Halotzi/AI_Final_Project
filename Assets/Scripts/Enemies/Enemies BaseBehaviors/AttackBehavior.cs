using UnityEngine;

public class AttackBehavior : BaseBehavior
{
    private float attackRange;
    private float attackCooldown = 1f;
    private float lastAttackTime;

    public AttackBehavior(GameObject enemy, Transform player, float attackRange) : base(enemy, player)
    {
        this.attackRange = attackRange;
    }

    public override void Execute()
    {
        if (Vector3.Distance(enemy.transform.position, player.position) <= attackRange && Time.time > lastAttackTime + attackCooldown)
        {
            // Implement attack logic here
            lastAttackTime = Time.time;
        }
    }
}