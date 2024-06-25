using UnityEngine;
using UnityEngine.AI;

public class AttackBehavior : BaseBehavior
{
    private float attackCooldown = 1f;
    private float _attackRange;
    private float lastAttackTime;

    public AttackBehavior(BaseEnemy enemy, Transform player, float attackRange, EnemySettings settings,NavMeshAgent agent, Animator animator) 
        : base(enemy, player, settings, agent, animator)
    {
        attackCooldown = settings.attackCooldown;
        _attackRange = attackRange;
    }

    public override void Execute()
    {
        if (Vector3.Distance(_enemy.transform.position, _player.position) <= _attackRange && Time.time > lastAttackTime + attackCooldown)
        {
            _animator.SetTrigger("Attack");
            lastAttackTime = Time.time;
        }
    }
}