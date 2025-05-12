using UnityEngine;

public class RemoveGroupPoint : BehaviorTree
{

    public override Result Run()
    {
        GameManager.Instance.groupPoint = new Vector3 (0,0,100);
        
        return Result.SUCCESS;
    }

    public RemoveGroupPoint() : base()
    {
    }

    public override BehaviorTree Copy()
    {
        return new RemoveGroupPoint();
    }
}

