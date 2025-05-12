using UnityEngine;

public class IsEnemyInAttackRange : BehaviorTree
{
    float attackDistance;

    public override Result Run()
    {
        float distanceToPlayer = (GameManager.Instance.player.transform.position - agent.transform.position).magnitude;
        if (distanceToPlayer < attackDistance)
        {
            return Result.SUCCESS;
        }
        return Result.FAILURE;
    }

    public IsEnemyInAttackRange(float attackDistance) : base()
    {
        this.attackDistance = attackDistance;
    }

    public override BehaviorTree Copy()
    {
        return new IsEnemyInAttackRange(attackDistance);
    }
}
