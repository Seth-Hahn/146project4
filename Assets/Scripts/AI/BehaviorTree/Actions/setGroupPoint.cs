using UnityEngine;

public class SetGroupPoint : BehaviorTree
{

    public override Result Run()
    {
        Vector3 playerDirection = GameManager.Instance.playerMovementDirection;

        GameManager.Instance.groupPoint = -playerDirection * 25;
        
        return Result.SUCCESS;
    }

    public SetGroupPoint() : base()
    {
    }

    public override BehaviorTree Copy()
    {
        return new SetGroupPoint();
    }
}

