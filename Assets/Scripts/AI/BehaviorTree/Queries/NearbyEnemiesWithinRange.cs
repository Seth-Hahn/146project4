public class NearbyEnemiesWithinRange : BehaviorTree
{
    int minCount;
    int maxCount;
    float distance;

    public override Result Run()
    {
        var nearby = GameManager.Instance.GetEnemiesInRange(agent.transform.position, distance);
        if (nearby.Count >= minCount && nearby.Count <= maxCount)
        {
            return Result.SUCCESS;
        }
        return Result.FAILURE;
    }

    public NearbyEnemiesWithinRange(int min_count,int max_count, float distance) : base()
    {
        this.minCount = min_count;
        this.maxCount = max_count;
        this.distance = distance;
    }

    public override BehaviorTree Copy()
    {
        return new NearbyEnemiesWithinRange(minCount,maxCount, distance);
    }
}
