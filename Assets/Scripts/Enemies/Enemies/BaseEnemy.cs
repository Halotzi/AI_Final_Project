using UnityEngine;
using UnityEngine.AI;

public abstract class BaseEnemy : MonoBehaviour
{
    [SerializeField] protected EnemyBehaviorHandler _behaviorHandler;
    [SerializeField] protected Animator _animator;
    
    protected Transform player;
    
    protected virtual void Start()
    {
        player = GameManager.Instance.PlayerManager.transform;
        _behaviorHandler.InitData(this,_animator);
    }
}