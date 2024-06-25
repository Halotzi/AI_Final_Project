using UnityEngine;
using UnityEngine.AI;

public abstract class BaseEnemy : MonoBehaviour
{
    [SerializeField] protected EnemyBehaviorHandler _behaviorHandler;
    [SerializeField] protected Transform _enemyBody;
    [SerializeField] protected Animator _animator;
    
    protected Transform player;

    public Vector3 EnemyPosition => _enemyBody.position;
    
    protected virtual void Start()
    {
        player = GameManager.Instance.PlayerManager.transform;
        _behaviorHandler.InitData(this,_animator);
    }
}