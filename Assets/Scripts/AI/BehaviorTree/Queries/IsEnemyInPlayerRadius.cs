using UnityEngine;

public class IsEnemyInPlayerRadius : BehaviorTree
{
    float radiusSize;

    public override Result Run()
    {
        float distanceToPlayer = (GameManager.Instance.player.transform.position - agent.transform.position).magnitude;
        if (distanceToPlayer < radiusSize)
        {
            return Result.SUCCESS;
        }
        return Result.FAILURE;
    }

    public IsEnemyInPlayerRadius(float radius) : base()
    {
        this.radiusSize = radius;
    }

    public override BehaviorTree Copy()
    {
        return new IsEnemyInPlayerRadius(radiusSize);
    }
}
