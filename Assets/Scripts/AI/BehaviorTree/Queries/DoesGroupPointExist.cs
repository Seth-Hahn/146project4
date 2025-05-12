using UnityEngine;

public class DoesGroupPointExist : BehaviorTree
{

    Vector3 nullVector;

    public override Result Run()
    {
        nullVector = new Vector3(0,0,100);
        //var nearby = GameManager.Instance.GetEnemiesInRange(agent.transform.position, distance);
        if (GameManager.Instance.groupPoint == nullVector)
        {
            return Result.FAILURE;
        }
        return Result.SUCCESS;
    }

    public DoesGroupPointExist() : base()
    {
    }

    public override BehaviorTree Copy()
    {
        return new DoesGroupPointExist();
    }
}
