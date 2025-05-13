using UnityEngine;

public class MoveAwayFromPlayer : BehaviorTree
{
    float arrived_distance;

    public override Result Run()
    {
        Vector3 direction = GameManager.Instance.player.transform.position - agent.transform.position;
        if (direction.magnitude < arrived_distance)
        {
            agent.GetComponent<Unit>().movement = -direction.normalized;
            return Result.SUCCESS;
        }
        else
        {
            agent.GetComponent<Unit>().movement = new Vector2(0, 0);
            return Result.IN_PROGRESS;
        }
    }

    public MoveAwayFromPlayer(float arrived_distance) : base()
    {
        this.arrived_distance = arrived_distance;
    }

    public override BehaviorTree Copy()
    {
        return new MoveAwayFromPlayer(arrived_distance);
    }
}
