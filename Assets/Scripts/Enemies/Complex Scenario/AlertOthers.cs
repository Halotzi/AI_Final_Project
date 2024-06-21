using UnityEngine;

public class AlertOthers
{
    public float alertRange = 15f; // Range within which enemies can alert each other

    public void AlertNearbyEnemies(GameObject enemy, Transform player)
    {
        Collider[] hitColliders = Physics.OverlapSphere(enemy.transform.position, alertRange);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject != enemy && hitCollider.gameObject.CompareTag("Enemy"))
            {
                EnemyBehaviorManager otherEnemy = hitCollider.GetComponent<EnemyBehaviorManager>();
                if (otherEnemy != null)
                {
                    otherEnemy.SetBehavior(new ChaseBehavior(otherEnemy.gameObject, player));
                }
            }
        }
    }
}