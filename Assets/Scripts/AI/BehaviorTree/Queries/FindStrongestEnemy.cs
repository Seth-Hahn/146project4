using UnityEngine;
using System.Collections.Generic;

public class FindStrongestEnemy : BehaviorTree
{
    int count;
    float distance;

    public override Result Run()
    {
        var nearby = GameManager.Instance.GetEnemiesInRange(agent.transform.position, distance);
        if (nearby.Count == 0)
        {
            return Result.FAILURE;
        }

        int indexOfStrongestEnemy = 0;
        float highestStrength = -1f;
        for(int i = 0; i < nearby.Count; i++) {
            float currentEnemyStrength = ((EnemyAttack)nearby[i].GetComponent<EnemyController>().GetAction("attack")).StrengthFactor;
            if(currentEnemyStrength > highestStrength) {
                indexOfStrongestEnemy = i;
                highestStrength = currentEnemyStrength;
            }
        }
        GameManager.Instance.highestStrengthEnemy = nearby[indexOfStrongestEnemy].transform.position;
        return Result.SUCCESS;
    }

    public FindStrongestEnemy(float distance) : base()
    {
        this.distance = distance;
    }

    public override BehaviorTree Copy()
    {
        return new FindStrongestEnemy(distance);
    }
}
