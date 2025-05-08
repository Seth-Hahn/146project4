using UnityEngine;

public class GoToPoint : BehaviorTree
{
    Vector3 target;
    float arrived_distance;

    public override Result Run()
    {
        Vector3 direction = target - agent.transform.position;
        if (direction.magnitude < arrived_distance)
        {
            agent.GetComponent<Unit>().movement = new Vector2(0, 0);
            return Result.SUCCESS;
        }
        else
        {
            agent.GetComponent<Unit>().movement = direction.normalized;
            return Result.IN_PROGRESS;
        }
    }

    public GoToPoint(Vector3 target, float arrived_distance) : base()
    {
        this.target = target;
        this.arrived_distance = arrived_distance;
    }

    public override BehaviorTree Copy()
    {
        return new GoToPoint(target, arrived_distance);
    }
}

