using UnityEngine;

public abstract class BaseBehavior
{
    protected GameObject enemy;
    protected Transform player;

    public BaseBehavior(GameObject enemy, Transform player)
    {
        this.enemy = enemy;
        this.player = player;
    }

    public abstract void Execute();
}