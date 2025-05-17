using UnityEngine;

public class DoesStrongestEnemyExist : BehaviorTree
{
    Vector3 nullVector = new Vector3(0,0,100);
    public override Result Run()
    {
        //var nearby = GameManager.Instance.GetEnemiesInRange(agent.transform.position, distance);
        if (GameManager.Instance.highestStrengthEnemy == nullVector)
        {
            return Result.FAILURE;
        }
        return Result.SUCCESS;
    }

    public DoesStrongestEnemyExist() : base()
    {
    }

    public override BehaviorTree Copy()
    {
        return new DoesStrongestEnemyExist();
    }
}
